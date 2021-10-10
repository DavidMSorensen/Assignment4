using System.ComponentModel.DataAnnotations;

namespace Assignment4.Core
{
        public record UserCreateDTO([Required, StringLength(50)] string Name,[EmailAddress] [Required] [StringLength(100)] string Email);

        public record UserDTO(int Id, [Required, StringLength(50)] string Name,[EmailAddress] [Required] [StringLength(100)] string Email) : UserCreateDTO(Name, Email);
        
        
}