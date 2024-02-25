using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace _2001
{
    public class GroupContext : DbContext
    {
        private readonly string _connectionString;
        public GroupContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        public DbSet<Group> group { get; set; }
    }
}
