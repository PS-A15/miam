﻿using System.Collections.Generic;
using Miam.Domain.Application;
using Miam.Domain.Entities;

namespace Miam.TestUtility.Seed
{
    public class TestData
    {
        #region Resto1 Le chameau pouilleux

        static public Restaurant Restaurant1
        {
            get
            {
                var restaurant = new Restaurant()
                {
                    Name = "Le chameau pouilleux",
                    City = "Lyon",
                    Country = "France",
                    Tags = new List<Tag>()
                    {
                        new Tag() {Title = "Urbain"},
                        new Tag() {Title = "Fast food"}
                    },
                    RestaurantContactDetail =  new RestaurantContactDetail()
                    {
                        WebPage = "www.chameaupouilleux.ca"
                    }
                };

                return restaurant;
            }
        }
        
        #endregion

        #region Resto 2 - Le cochon chevelu

        static public Restaurant Restaurant2
        {
            get
            {
                var restaurant = new Restaurant()
                {
                    Name = "Le cochon chevelu",
                    City = "Montréal",
                    Country = "Canada",
                    Tags = new List<Tag>()
                    {
                        new Tag() {Title = "Fine cuisine"}
                    },
                    RestaurantContactDetail = new RestaurantContactDetail()
                    {
                        WebPage = "www.lecochonchevelu.com"
                    }
                };
                return restaurant;
            }
        }

        #endregion

        #region Resto 3 - Bambine et Bounette
        public static Restaurant Restaurant3
        {
            get
            {
                var newRestaurant = new Restaurant()
                {
                    Name = "Bambine et Bounette",
                    City = "Trois-Rivière",
                    Country = "Canada",
                    RestaurantContactDetail = new RestaurantContactDetail()
                    {
                        Facebook = "BamBounette",
                        OfficePhone = "123-888-4567",
                        FaxPhone = "123-888-4569",
                        TwitterAlias = "BamBou",
                        WebPage = "www.bambinebounette.com"
                    }
                };
                return newRestaurant;
            }
        }
        #endregion

        #region Writers

        static public Writer Writer1
        {
            get
            {
                var writer = new Writer()

                         {
                             Roles = new List<MiamRole>()
                             {
                                 new MiamRole() {RoleName = Role.Writer}
                             },
                             Password = "irma",
                             Name = "Irma Larose",
                             Email = "irma@Larose.fr",
                         };

                return writer;
            }
        }

        static public Writer Writer2
        {
            get
            {
                var writer = new Writer()

                {
                    Roles = new List<MiamRole>()
                             {
                                 new MiamRole() {RoleName = Role.Writer}
                             },
                    Password = "lucien",
                    Name = "Lucien Lafleur",
                    Email = "lucien@lafleur.com",

                };

                return writer;
            }
        }
        #endregion
        
        #region reviews
        public static Review Review1
        {
            get
            {

                var review = new Review()
                {
                    Body = "Service génial",
                    Rating = 4
                };
                return review;
            }
        }

        public static Review Review2
        {
            get
            {

                var review = new Review()
                             {
                                 Body = "Trop familier",
                                 Rating = 2
                             };
                return review;
            }
        }

        public static Review Review3
        {
            get
            {

                var review = new Review()
                {
                    Body = "Super la poutine thai !",
                    Rating = 5
                };
                return review;
            }
        }
        #endregion

        #region Admin (writer with roles admin + writer)
        public static MiamUser MiamUserAdmin
        {
            get
            {
                var user = new Writer()

                {
                    Roles = new List<MiamRole>()
                             {
                                 new MiamRole() {RoleName = Role.Writer},
                                 new MiamRole() {RoleName = Role.Admin}
                             },
                    Password = "admin",
                    Name = "Admin Lafleur",
                    Email = "test@admin.com",
                };

                return user;
            }
        }
        #endregion

        public static string WordFileName
        {
            //Le fichier se trouve dans la dossier TestFiles du projet Miam.Web.AcceptanceTests
            get { return "exemple.docx"; }
        }

        public static MiamRole MiamRoles { get; set; }
    }
}