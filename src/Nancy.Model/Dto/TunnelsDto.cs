using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nancy.Model.Dto
{
    [XmlRoot(ElementName = "Response")]
    public class TunnelsDto
    {
        public TunnelsDto()
        {
            Tunnels = new List<Tunnel>();
        }

        public List<Tunnel> Tunnels { get; set; } 
    }
}