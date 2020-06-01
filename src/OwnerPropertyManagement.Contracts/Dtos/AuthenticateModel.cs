using System.ComponentModel.DataAnnotations;

namespace OwnerPropertyManagement.Contracts.Dtos
{
    public class AuthenticateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
