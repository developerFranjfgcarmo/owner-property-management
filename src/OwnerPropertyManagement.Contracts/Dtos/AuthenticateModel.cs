using System.ComponentModel.DataAnnotations;

namespace OwnerPropertyManagement.Contracts.Dtos
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
