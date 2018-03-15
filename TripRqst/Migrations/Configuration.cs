namespace TripRqst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TripRqst.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TripRqst.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.TR_Alocacoes.AddOrUpdate(a => a.Name, new Models.TR_Def_Aloc { Name = "HQ" });
            //context.TR_Alocacoes.AddOrUpdate(a => a.Name, new Models.TR_Def_Aloc { Name = "Projeto" });
            //context.TR_Alocacoes.AddOrUpdate(a => a.Name, new Models.TR_Def_Aloc { Name = "CL" });

            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "FDSV", Name = "Project (Construction/installation/maintenance/repair)" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "EXTN", Name = "Meeting Customer (Meeting, Event, Conference or Fair)" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "CONV", Name = "Meeting Non-Customer (Meeting, Event, Conference or Fair)" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "INTM", Name = "Meeting Siemens Internal (Meeting, Conference or Event)" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "TRNG", Name = "Training" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "HOHO", Name = "Delegation (home and host based)" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "HMLV", Name = "Home leave" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "RELO", Name = "Relocation" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "JAPP", Name = "Job applicants" });
            //context.TR_Motivos.AddOrUpdate(m => m.Name, new Models.TR_Def_Motivo { Code = "SIGU", Name = "Siemens Guest" });

            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Dentro do tempo estipulado", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Avaria/Situação de Obra Urgente ", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Exigência do Cliente", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Ao Abrigo de SLA", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Razão Particular", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Falha Processual Agênciac", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Falha Processual Interna", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Conveniência (melhor preço, falta de vôos, horários, etc)", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            //context.TR_Justificacoes.AddOrUpdate(m => m.Name, new Models.TR_Def_Justif { Name = "Outro", RequiresEmail= true, RequiresAuthorizedMailSender = false });
            


        }
    }
}
