using Gestupperware.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestupperware.Api.Data
{
    public class GestupperwareContext : DbContext
    {
        public GestupperwareContext(DbContextOptions<GestupperwareContext> options) : base(options)
        {

        }
        public DbSet<Tupperware> Tupperwares { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Storage> Storages { get; set; }
    }
}