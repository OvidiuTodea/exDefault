using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exDefault.Models
{
    public class EntitiesDbContext : DbContext
    {
        public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options) : base(options)
        {
        }

        // DbSet = Repository
        // DbSet = O tabela din baza de date
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
