using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Core
{
    public record TaskCreateDTO([Required, StringLength(50)] string Title, string Description, int? AssignedToId);

    public record TaskDTO(int Id, [Required, StringLength(50)] string Title, string Description, int? AssignedToId, State state) : TaskCreateDTO(Title, Description, AssignedToId);
}