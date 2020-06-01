using OwnerPropertyManagement.Api.Auth.Entities;

namespace OwnerPropertyManagement.Api.Auth.Service
{
    public interface IUserService
    { 
        User Authenticate(string username, string password);
        User GetById(int id);
    }
}
