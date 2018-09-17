using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserRoles.Models;

namespace UserRoles.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaFisica> PersonaFisicas { get; set; }
        public DbSet<PersonaJuridica> PersonaJuridicas { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<TypoDocumento> TypoDocumentos { get; set; } //not needed this bdset using enums 
        public DbSet<CaracterRepresentante> Caracters { get; set; } //not needed this bdset using enums 


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
