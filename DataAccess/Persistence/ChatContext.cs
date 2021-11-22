using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Persistence
{
    public class ChatContext : DbContext
    {


        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = chats.db");
        }
    }
}