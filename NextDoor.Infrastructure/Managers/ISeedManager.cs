using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Managers
{
    public interface ISeedManager
    {
        Task InitializeAsync();
    }
}
