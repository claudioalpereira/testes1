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
        public DbSet<Justificacao_Tr> TR_Justificacoes { get; set; }
        public DbSet<Motivo_Tr> TR_Motivos { get; set; }
        public DbSet<Alocacao_Tr> TR_Alocacoes { get; set; }
        public DbSet<Country_Tr> Countries { get; set; }
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

            context.Countries.Add(new Models.Country_Tr { Code = "", Name = "Other", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AFG", Name = "Afghanistan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ALB", Name = "Albania", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "DZA", Name = "Algeria", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ASM", Name = "American Samoa", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AND", Name = "Andorra", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AGO", Name = "Angola", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AIA", Name = "Anguilla", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ATA", Name = "Antarctica", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ATG", Name = "Antigua and Barbuda", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ARG", Name = "Argentina", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ARM", Name = "Armenia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ABW", Name = "Aruba", IsDomestic = false, Active = true });
            //context.Countries.Add(new Models.Country_Tr { Code = "N/A", Name = "Asia & Pacific", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AUS", Name = "Australia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AUT", Name = "Austria", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "AZE", Name = "Azerbaijan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BHS", Name = "Bahamas", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BHR", Name = "Bahrain", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BGD", Name = "Bangladesh", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BRB", Name = "Barbados", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BLR", Name = "Belarus", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BEL", Name = "Belgium", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BLZ", Name = "Belize", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BEN", Name = "Benin", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BMU", Name = "Bermuda", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BTN", Name = "Bhutan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BOL", Name = "Bolivia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BIH", Name = "Bosnia and Herzegovina", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BWA", Name = "Botswana", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BVT", Name = "Bouvet Island", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BRA", Name = "Brazil", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IOT", Name = "British Indian Ocean Territory", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VGB", Name = "British Virgin Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BRN", Name = "Brunei", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BGR", Name = "Bulgaria", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BFA", Name = "Burkina Faso", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BDI", Name = "Burundi", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KHM", Name = "Cambodia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CMR", Name = "Cameroon", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CAN", Name = "Canada", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CPV", Name = "Cape Verde", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CYM", Name = "Cayman Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CAF", Name = "Central African Republic", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TCD", Name = "Chad", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CHL", Name = "Chile", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CHN", Name = "China", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CXR", Name = "Christmas Island", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CCK", Name = "Cocos Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "COL", Name = "Colombia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "COM", Name = "Comoros", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "COD", Name = "Congo Democratic Republic", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "COG", Name = "Congo Republic", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "COK", Name = "Cook Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CRI", Name = "Costa Rica", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "HRV", Name = "Croatia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CUB", Name = "Cuba", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CYP", Name = "Cyprus", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CZE", Name = "Czech Republic", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "DNK", Name = "Denmark", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "DJI", Name = "Djibouti", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "DMA", Name = "Dominica", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "DOM", Name = "Dominican Republic", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ECU", Name = "Ecuador", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "EGY", Name = "Egypt", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SLV", Name = "El Salvador", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GNQ", Name = "Equatorial Guinea", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ERI", Name = "Eritrea", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "EST", Name = "Estonia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ETH", Name = "Ethiopia", IsDomestic = false, Active = true });
            //context.Countries.Add(new Models.Country_Tr { Code = "N/A", Name = "European Union", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "FLK", Name = "Falkland Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "FRO", Name = "Faroe Islands", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "FJI", Name = "Fiji", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "FIN", Name = "Finland", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "FRA", Name = "France", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PYF", Name = "French Polynesia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ATF", Name = "French Southern Territories", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GAB", Name = "Gabon", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GMB", Name = "Gambia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GEO", Name = "Georgia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "DEU", Name = "Germany", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GHA", Name = "Ghana", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GIB", Name = "Gibraltar", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GRC", Name = "Greece", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GRL", Name = "Greenland", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GRD", Name = "Grenada", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GUM", Name = "Guam", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GTM", Name = "Guatemala", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GGY", Name = "Guernsey", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GIN", Name = "Guinea", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GNB", Name = "Guinea-Bissau", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GUY", Name = "Guyana", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "HTI", Name = "Haiti", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "HMD", Name = "Heard Island and McDonald Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VAT", Name = "Holy See", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "HND", Name = "Honduras", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "HKG", Name = "Hong Kong", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "HUN", Name = "Hungary", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ISL", Name = "Iceland", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IND", Name = "India", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IDN", Name = "Indonesia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IRN", Name = "Iran", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IRQ", Name = "Iraq", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IRL", Name = "Ireland", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "IMN", Name = "Isle of Man", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ISR", Name = "Israel", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ITA", Name = "Italy", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CIV", Name = "Ivory Coast", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "JAM", Name = "Jamaica", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "JPN", Name = "Japan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "JEY", Name = "Jersey", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "JOR", Name = "Jordan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KAZ", Name = "Kazakhstan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KEN", Name = "Kenya", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KIR", Name = "Kiribati", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PRK", Name = "Korea North", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KOR", Name = "Korea South", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KWT", Name = "Kuwait", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KGZ", Name = "Kyrgyzstan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LAO", Name = "Laos", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LVA", Name = "Latvia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LBN", Name = "Lebanon", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LSO", Name = "Lesotho", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LBR", Name = "Liberia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LBY", Name = "Libya", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LIE", Name = "Liechtenstein", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LTU", Name = "Lithuania", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LUX", Name = "Luxembourg", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MAC", Name = "Macao", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MKD", Name = "Macedonia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MDG", Name = "Madagascar", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MWI", Name = "Malawi", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MYS", Name = "Malaysia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MDV", Name = "Maldives", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MLI", Name = "Mali", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MLT", Name = "Malta", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MHL", Name = "Marshall Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MRT", Name = "Mauritania", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MUS", Name = "Mauritius", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MYT", Name = "Mayotte", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MEX", Name = "Mexico", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "FSM", Name = "Micronesia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MDA", Name = "Moldova", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MCO", Name = "Monaco", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MNG", Name = "Mongolia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MNE", Name = "Montenegro", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MSR", Name = "Montserrat", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MAR", Name = "Morocco", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MOZ", Name = "Mozambique", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MMR", Name = "Myanmar", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NAM", Name = "Namibia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NRU", Name = "Nauru", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NPL", Name = "Nepal", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NLD", Name = "Netherlands", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ANT", Name = "Netherlands Antilles", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NCL", Name = "New Caledonia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NZL", Name = "New Zealand", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NIC", Name = "Nicaragua", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NER", Name = "Niger", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NGA", Name = "Nigeria", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NIU", Name = "Niue", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NFK", Name = "Norfolk Island", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MNP", Name = "Northern Mariana Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "NOR", Name = "Norway", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "OMN", Name = "Oman", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PAK", Name = "Pakistan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PLW", Name = "Palau", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PSE", Name = "Palestinian Territory", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PAN", Name = "Panama", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PNG", Name = "Papua New Guinea", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PRY", Name = "Paraguay", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PER", Name = "Peru", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PHL", Name = "Philippines", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PCN", Name = "Pitcairn", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "POL", Name = "Poland", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PRT", Name = "Portugal", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "PRI", Name = "Puerto Rico", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "QAT", Name = "Qatar", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ROU", Name = "Romania", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "RUS", Name = "Russia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "RWA", Name = "Rwanda", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "BLM", Name = "Saint Barthelemy", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SHN", Name = "Saint Helena Ascension and Tristan da Cunha", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "KNA", Name = "Saint Kitts and Nevis", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LCA", Name = "Saint Lucia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "MAF", Name = "Saint Martin", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SPM", Name = "Saint Pierre and Miquelon", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VCT", Name = "Saint Vincent and the Grenadines", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "WSM", Name = "Samoa", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SMR", Name = "San Marino", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "STP", Name = "Sao Tome and Principe", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SAU", Name = "Saudi Arabia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SEN", Name = "Senegal", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SRB", Name = "Serbia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SYC", Name = "Seychelles", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SLE", Name = "Sierra Leone", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SGP", Name = "Singapore", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SVK", Name = "Slovakia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SVN", Name = "Slovenia", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SLB", Name = "Solomon Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SOM", Name = "Somalia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ZAF", Name = "South Africa", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ESP", Name = "Spain", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "LKA", Name = "Sri Lanka", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SDN", Name = "Sudan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SUR", Name = "Suriname", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SJM", Name = "Svalbard", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SWZ", Name = "Swaziland", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SWE", Name = "Sweden", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "CHE", Name = "Switzerland", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "SYR", Name = "Syria", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TWN", Name = "Taiwan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TJK", Name = "Tajikistan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TZA", Name = "Tanzania", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "THA", Name = "Thailand", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TLS", Name = "Timor-Leste", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TGO", Name = "Togo", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TKL", Name = "Tokelau", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TON", Name = "Tonga", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TTO", Name = "Trinidad and Tobago", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TUN", Name = "Tunisia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TUR", Name = "Turkey", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TKM", Name = "Turkmenistan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TCA", Name = "Turks and Caicos Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "TUV", Name = "Tuvalu", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "UGA", Name = "Uganda", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "UKR", Name = "Ukraine", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ARE", Name = "United Arab Emirates", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "GBR", Name = "United Kingdom", IsDomestic = true, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "USA", Name = "United States", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "URY", Name = "Uruguay", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "UZB", Name = "Uzbekistan", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VUT", Name = "Vanuatu", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VEN", Name = "Venezuela", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VNM", Name = "Vietnam", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "VIR", Name = "Virgin Islands", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "WLF", Name = "Wallis and Futuna", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ESH", Name = "Western Sahara", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "YEM", Name = "Yemen", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ZMB", Name = "Zambia", IsDomestic = false, Active = true });
            context.Countries.Add(new Models.Country_Tr { Code = "ZWE", Name = "Zimbabwe", IsDomestic = false, Active = true });

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