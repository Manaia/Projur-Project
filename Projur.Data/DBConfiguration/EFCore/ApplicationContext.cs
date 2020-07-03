using Projur.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Projur.Data.DBConfiguration.EFCore
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext() : base() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                string conn = DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection"); 

                dbContextOptionsBuilder.UseSqlServer(conn);

                base.OnConfiguring(dbContextOptionsBuilder);
            }
        }
            
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Escolaridade> Escolaridades { get; set; }
    }
}