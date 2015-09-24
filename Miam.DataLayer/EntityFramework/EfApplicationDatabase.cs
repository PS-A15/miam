using System.Data.Entity;
using System.Data.SqlClient;
//using Miam.DataLayer.Migrations;

namespace Miam.DataLayer.EntityFramework
{
    public class EfApplicationDatabase : IApplicationDatabase
    {
        private readonly MiamDbContext _context;

        public EfApplicationDatabase(MiamDbContext miamDbContext)
        {
            _context = miamDbContext;
        }
        
        public void DropCreateDatabaseIfModelChanges()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseIfModelChanges<MiamDbContext>();
            // Pour mettre des données non sensibles à la création de la BDdans la BD, utiliser 
            //var initializer = new EfDropCreateIfModelChangesSeeder()
            Database.SetInitializer(initializer); 
            
        }

        public void DropCreateDatabaseAlways()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseAlways<MiamDbContext>();
            // Pour mettre des données non sensibles à la création de la BD, utiliser 
            //var initializer = new EfDropCreateDatabaseAlwaysSeeder();
            Database.SetInitializer(initializer); 
            
        }

        public void MigrateDatabaseToLatestVersion()
        {
            //var initializer = new MigrateDatabaseToLatestVersion<MiamDbContext, Configuration>();
            //Database.SetInitializer(initializer);
        }

        public void CreatedatabaseIfNotExists()
        {
            SqlConnection.ClearAllPools();

            var initializer = new CreateDatabaseIfNotExists<MiamDbContext>();

            Database.SetInitializer(initializer); 
        }


        public void ClearAllTables()
        {
            MigrateDatabaseToLatestVersion();

            //var context = new MiamDbContext();

            _context.Writers.RemoveRange(_context.Writers);
            _context.Restaurants.RemoveRange(_context.Restaurants);
            _context.Reviews.RemoveRange(_context.Reviews);
            _context.RestaurantTags.RemoveRange(_context.RestaurantTags);
            _context.MiamUsers.RemoveRange(_context.MiamUsers);
            _context.MiamRoles.RemoveRange(_context.MiamRoles);
            _context.SaveChanges();


             //Autre méthode pour tout effacer: supprimer la BD et la recréer, mais est plus lent.
            //SqlConnection.ClearAllPools();
            //context.Database.Initialize(false);
            //context.Database.Delete();
            //context.Database.CreateIfNotExists();
            //context.SaveChanges();
        }
    }
}

