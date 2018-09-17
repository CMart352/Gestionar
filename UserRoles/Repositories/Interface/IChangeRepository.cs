using System.Threading.Tasks;

namespace UserRoles.Repositories.Interface
{
    public interface IChangeRepository
    {
        Task SendEmail(string userEmail);
        Task ToggleBlock(string userEmail);
    }
}
