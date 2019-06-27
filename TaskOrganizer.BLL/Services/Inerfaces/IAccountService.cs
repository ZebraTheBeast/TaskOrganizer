using System.Threading.Tasks;
using TaskOrganizer.ViewModels;
using TaskOrganizer.ViewModels.Shared;

namespace TaskOrganizer.BLL.Services.Inerfaces
{
    public interface IAccountService
    {
        Task<ResponseUserView> LogIn(UserView userView);
    }
}
