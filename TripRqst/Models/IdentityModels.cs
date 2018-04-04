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

        public DbSet<TripRequest> TR_Requests { get; set; }
        public DbSet<Justificacao_Tr> TR_Justificacoes { get; set; }
        public DbSet<Motivo_Tr> TR_Motivos { get; set; }
        public DbSet<Alocacao_Tr> TR_Alocacoes { get; set; }
        //public DbSet<TripRequest_Alocacao> TR_request_Alocacao { get; set; }
    }

    //public class MyDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    public class MyDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.TR_Alocacoes.Add( new Models.Alocacao_Tr { Code = "HQ", Name = "HQ", Active = true });
            context.TR_Alocacoes.Add( new Models.Alocacao_Tr { Code = "Projeto", Name = "Projeto", Active = true });
            context.TR_Alocacoes.Add( new Models.Alocacao_Tr { Code = "CL", Name = "CL", Active = true });

            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "FDSV", Name = "Project", Info = "(Construction/installation/maintenance/repair)", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "EXTN", Name = "Meeting Customer", Info = "(Meeting, Event, Conference or Fair)", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "CONV", Name = "Meeting Non-Customer", Info = "(Meeting, Event, Conference or Fair)", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "INTM", Name = "Meeting Siemens Internal", Info = "(Meeting, Conference or Event)", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "TRNG", Name = "Training", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "HOHO", Name = "Delegation", Info = "(home and host based)", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "HMLV", Name = "Home leave", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "RELO", Name = "Relocation", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "JAPP", Name = "Job applicants", Active = true });
            context.TR_Motivos.Add( new Models.Motivo_Tr { Code = "SIGU", Name = "Siemens Guest", Active = true });

            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "1", Name = "Dentro do tempo estipulado", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "2", Name = "Avaria/Situação de Obra Urgente ", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "3", Name = "Exigência do Cliente", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "4", Name = "Ao Abrigo de SLA", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "5", Name = "Razão Particular", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "6", Name = "Falha Processual Agênciac", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "7", Name = "Falha Processual Interna", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "8", Name = "Conveniência (melhor preço, falta de vôos, horários, etc)", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });
            context.TR_Justificacoes.Add( new Models.Justificacao_Tr { Code = "9", Name = "Outro", RequiresEmail = true, RequiresEmailFromAuthorizedSender = false, Active = true });


            //
            // https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles
            //
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "assistent"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "assistent" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "claudio.pereira@siemens.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "claudio.pereira@siemens.com" };

                manager.Create(user, "wekftW34#$");
                user.EmailConfirmed = true;
                manager.AddToRole(user.Id, "admin");
            }

            base.Seed(context);
        }
    }
}