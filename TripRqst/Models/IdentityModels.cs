using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace TripRqst.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // uncomment to test registration
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());

            // uncomment to test
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());

            Database.SetInitializer(new MyDBInitializer());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<TripRequest> TR_requests { get; set; }
        public DbSet<TR_Def_Justif> TR_Justificacoes { get; set; }
        public DbSet<TR_Def_Motivo> TR_Motivos { get; set; }
        public DbSet<TR_Def_Aloc> TR_Alocacoes { get; set; }
        //public DbSet<TripRequest_Alocacao> TR_request_Alocacao { get; set; }
    }

    //public class MyDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    public class MyDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.TR_Alocacoes.Add( new Models.TR_Def_Aloc { Name = "HQ" });
            context.TR_Alocacoes.Add( new Models.TR_Def_Aloc { Name = "Projeto" });
            context.TR_Alocacoes.Add( new Models.TR_Def_Aloc { Name = "CL" });

            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "FDSV", Name = "Project (Construction/installation/maintenance/repair)" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "EXTN", Name = "Meeting Customer (Meeting, Event, Conference or Fair)" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "CONV", Name = "Meeting Non-Customer (Meeting, Event, Conference or Fair)" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "INTM", Name = "Meeting Siemens Internal (Meeting, Conference or Event)" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "TRNG", Name = "Training" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "HOHO", Name = "Delegation (home and host based)" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "HMLV", Name = "Home leave" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "RELO", Name = "Relocation" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "JAPP", Name = "Job applicants" });
            context.TR_Motivos.Add( new Models.TR_Def_Motivo { Code = "SIGU", Name = "Siemens Guest" });

            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Dentro do tempo estipulado", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Avaria/Situação de Obra Urgente ", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Exigência do Cliente", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Ao Abrigo de SLA", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Razão Particular", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Falha Processual Agênciac", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Falha Processual Interna", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Conveniência (melhor preço, falta de vôos, horários, etc)", RequiresEmail = true, RequiresAuthorizedMailSender = false });
            context.TR_Justificacoes.Add( new Models.TR_Def_Justif { Name = "Outro", RequiresEmail = true, RequiresAuthorizedMailSender = false });


            //
            // https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles
            //
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "claudio.pereira@siemens.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "claudio.pereira@siemens.com" };

                manager.Create(user, "wekftW34#$");
                user.EmailConfirmed = true;
                manager.AddToRole(user.Id, "Admin");
            }

            base.Seed(context);
        }
    }
}