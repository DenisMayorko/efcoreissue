using Issue.Data.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace Issue.Data
{
    public class Context:DbContext
    {
        public DbSet<AppTask> Tasks { get; set; }
        public DbSet<TaskStatus> Statuses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;database=sandBox;uid=sa;pwd=<PASSWORD>;");
        }
    }
}
