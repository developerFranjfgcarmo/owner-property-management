using HealthcareManagement.Api.Auth.Entities;

namespace HealthcareManagement.Api.Auth.Sevices
{
    public interface IUserService
    { 
        User Authenticate(string username, string password);
        User GetById(int id);
    }
}
