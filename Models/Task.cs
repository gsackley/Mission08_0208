using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_0208.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }


        [Required]
        public string TaskName { get; set; }
        public string DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }

        // FK Relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool Completed { get; set; }
    }
}
