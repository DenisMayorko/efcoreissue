using System;
using System.ComponentModel.DataAnnotations;

namespace Issue.Data.Models
{
    public class AppTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        public AppTask()
        {
            Status = new TaskStatus();
        }
    }
}
