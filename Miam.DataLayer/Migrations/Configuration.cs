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
            //  Le seed est executé à chaque fois qu'une migration est ajoutée. 

            // Ajout dans la BD des rôles. S'ils existent déjà, ils ne seront pas ajoutés en double.
            context.MiamRoles.AddOrUpdate(x => x.RoleName,
                new MiamRole { RoleName = Role.Writer },
                new MiamRole { RoleName = Role.Admin }
                );

            context.SaveChanges();

            // Création d'un admin par défaut 
            var miamUser = new MiamUser()
            {
                Name = "Administrateur du système",
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
        }
    }
}
