
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

        public int? AssignedTo { get; set; }
            
        public string Descrption { get; set; }

        [Required]
        public State State { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
