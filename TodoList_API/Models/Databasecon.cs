using Microsoft.EntityFrameworkCore;
using TodoListModels;
using System.IO;

namespace TodoAPI.Models
{
    public class Databasecon : DbContext
    {
        public Databasecon(DbContextOptions<Databasecon> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "TODO_DATABASE.db");

        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public string DbPath { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    }
}

