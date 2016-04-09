using System.Collections.ObjectModel;
using Nancy.Model;

namespace Nancy.Repository
{
    public interface ITunnelRepository
    {
        ReadOnlyCollection<Tunnel> Tunnels { get; }
        Tunnel Get(int id);
        Tunnel Add(Tunnel tunnel);
        bool Delete(int id);
    }
}