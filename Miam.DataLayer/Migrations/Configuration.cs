using System.Collections.Generic;
using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Miam.DataLayer.MiamDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Miam.DataLayer.MiamDbContext";
        }

        protected override void Seed(Miam.DataLayer.MiamDbContext context)
        {
            //  Le seed est execut� � chaque fois qu'une migration est ajout�e. 


            // Ajout dans la BD des r�les. S'ils existent d�j�, ils ne seront pas ajout�s en double.
            context.MiamRoles.AddOrUpdate(x => x.RoleName,
                new MiamRole { RoleName = Role.Writer },
                new MiamRole { RoleName = Role.Admin }
                );

            context.SaveChanges();

            // Cr�ation d'un admin par d�faut 
            var miamUser = new MiamUser()
               {
                   Name = "Administrateur du syst�me",
                   Password = "admin",
                   Email = "admin@admin.com",
               };
            miamUser.Roles.Add(context.MiamRoles.First(x => x.RoleName == Role.Admin));
            miamUser.Roles.Add(context.MiamRoles.First(x => x.RoleName == Role.Writer));

            // Ajout de l'admin si aucun utilisateur dans la BD
            if (!context.MiamUsers.AsQueryable().Any())
            { 
                context.MiamUsers.Add(miamUser);
            }


            //if (!context.MiamRoles.Any(r => r.RoleName == "AppAdmin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //}

            //var roleAdminId = context.MiamRoles.First(x => x.RoleName == Role.Admin).Id;
            //var roleWriterId = context.MiamRoles.First(x => x.RoleName == Role.Writer).Id;



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

            //var userCount = context.MiamUsers.AsQueryable().Count();
            //if  (userCount == 0)
            //{
            //    context.MiamUsers.Add(
            //    new MiamUser
            //    {
            //        Name = "Administrateur du syst�me",
            //        Password = "admin",
            //        Email = "admin@admin.com",
            //        Roles = new List<MiamRole>()
            //                 {
            //                     new MiamRole() {RoleName = Role.Writer},
            //                     new MiamRole() {RoleName = Role.Admin}
            //                 }
            //    }
            //    );
            //}

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

        }
    }
}
