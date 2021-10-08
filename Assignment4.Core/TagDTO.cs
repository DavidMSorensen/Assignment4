using System.ComponentModel.DataAnnotations;

namespace Assignment4.Core
{
    
    public record TagCreateDTO([Required, StringLength(50)] string Name);

    public record TagDTO(int Id, [Required, StringLength(50)] string Name) : TagCreateDTO(Name);
}