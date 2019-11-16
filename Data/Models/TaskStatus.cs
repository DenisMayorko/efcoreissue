using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Issue.Data.Models
{
    public class TaskStatus
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        public List<AppTask> Tasks { get; set; }
        public TaskStatus()
        {
            Tasks = new List<AppTask>();
        }
    }
}
