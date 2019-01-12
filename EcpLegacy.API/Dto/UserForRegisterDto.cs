using System.ComponentModel.DataAnnotations;

namespace EcpLegacy.API.Dto
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "You must specify a username between 3 and 12 characters")]
        public string Username {get; set; }
        
        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 12 characters")]
        public string Password {get; set; }

        [Required]
        public string Name {get; set; }
        public string Friendlyname {get; set; }

        [EmailAddress]
        public string Email {get; set; }
    }
}