using OwnerPropertyManagement.Api.Auth.Entities;
using OwnerPropertyManagement.Api.Auth.ViewModel;

namespace OwnerPropertyManagement.Api.Auth.Service
{
    public interface IUserService
    { 
        User Authenticate(string username, string password);
        User GetById(int id);
    }
}
