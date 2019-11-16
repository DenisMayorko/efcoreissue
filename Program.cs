using Issue.Data;
using Issue.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Issue
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var db = new Context())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
                var status = new Data.Models.TaskStatus();
                db.Statuses.Add(status);
                db.Tasks.Add(new AppTask { Status = status });
                db.Tasks.Add(new AppTask { Status = status });
                db.Tasks.Add(new AppTask { Status = status });
                db.SaveChanges();
            }
            using (var db = new Context())
            {
                var result = await db.Statuses.Include(x => x.Tasks).ToListAsync();
                Console.WriteLine(result[0].Tasks.Count);
            }

            using (var db = new Context())
            {
                db.Tasks.Include(x => x.Status).ToList();
                var result = await db.Statuses.Include(x => x.Tasks).ToListAsync();
                Console.WriteLine(result[0].Tasks.Count);
            }

            using (var db = new Context())
            {
                db.Tasks.ToList();
                var result = await db.Statuses.Include(x => x.Tasks).ToListAsync();
                Console.WriteLine(result[0].Tasks.Count);
            }

            using (var db = new Context())
            {
                var result = await db.Statuses.Include(x => x.Tasks).Select(x => new { x.Id, x.Tasks }).ToListAsync();
                Console.WriteLine(result[0].Tasks.Count);
            }
        }
    }
}
