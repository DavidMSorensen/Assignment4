
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Assignment4.Core;

namespace Assignment4.Entities
{
    public class Task
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int? AssignedToId { get; set; }
            
        public string Description { get; set; }

        [Required]
        public State State { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
