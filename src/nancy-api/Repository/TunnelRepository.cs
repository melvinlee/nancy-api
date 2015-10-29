using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NancyApi.Model;

namespace nancyapi.Repository
{
    public class TunnelRepository
    {
        private IList<Tunnel> _tunnels;

        public ReadOnlyCollection<Tunnel> Tunnels
        {
            get
            {
                if (_tunnels == null)
                    SeedData();
                return new ReadOnlyCollection<Tunnel>(_tunnels);
            }
        }

        private void SeedData()
        {
            _tunnels = new List<Tunnel>
                {
                    new Tunnel()
                        {
                            Id = 0,
                            Name = "Delaware Aqueduct",
                            Location = "New York state, United States",
                            Length = 137000,
                            Type = "Water supply",
                            Year = "1945"
                        },
                    new Tunnel()
                        {
                            Id = 1,
                            Name = "Päijänne Water Tunnel",
                            Location = "Southern Finland, Finland",
                            Length = 120000,
                            Type = "Water supply",
                            Year = "1982"
                        },
                    new Tunnel()
                        {
                            Id = 2,
                            Name = "Seikan Tunnel",
                            Location = "Tsugaru Strait, Japan",
                            Length = 53850,
                            Type = "Railway Single Tube",
                            Year = "1988"
                        },
                    new Tunnel()
                        {
                            Id = 3,
                            Name = "Seoul Subway: Line 3",
                            Location = "Seoul, South Korea",
                            Length = 38200,
                            Type = "Metro",
                            Year = "1985-2010"
                        },
                    new Tunnel()
                        {
                            Id = 4,
                            Name = "Tooma-Tumut Tunnel",
                            Location = "NSW, Australia",
                            Length = 14200,
                            Type = "Water supply",
                            Year = "1961"
                        }
                };
        }

        public Tunnel Get(int id)
        {
            return Tunnels.SingleOrDefault(x => x.Id == id);
        }
    }
}