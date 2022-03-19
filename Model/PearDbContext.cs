using Microsoft.EntityFrameworkCore;
using pear_project.Models;

namespace pear_project
{
    public class PearDbContext : DbContext
    {
        public DbSet<Person>? Persons { get; set; }
        public DbSet<PersonDetail>? PersonDetails { get; set; }
        public DbSet<DutyCategory>? DutyCategories { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<AuthenticateRequest>? AuthenticationRequests { get; set; }
        public DbSet<AuthenticateResponse>? AuthenticateResponses { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            optionsBuilder.UseMySql("server=localhost;database=pearDb;user=root;port=3306;password=toortoor", serverVersion);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            PearDbBuilder.TableBuilder(modelBuilder);
        }
    }
}