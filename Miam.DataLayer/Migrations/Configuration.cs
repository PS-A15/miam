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
            //  This method will be called after migrating to the latest version.


            context.MiamUsers.AddOrUpdate(
                new MiamUser
                {
                    Name = "Administrateur du système",
                    Password = "admin",
                    Email = "admin@admin.com",
                    Roles = new List<MiamRole>()
                    {
                        new MiamRole() {RoleName = Role.Writer},
                        new MiamRole() {RoleName = Role.Admin}
                    }
                });

            //var userCount = context.MiamUsers.AsQueryable().Count();
            //if  (userCount == 0)
            //{
            //    context.MiamUsers.Add(
            //    new MiamUser
            //    {
            //        Name = "Administrateur du système",
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
