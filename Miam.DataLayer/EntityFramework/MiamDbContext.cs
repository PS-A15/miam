using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using Miam.Domain.Entities;

namespace Miam.DataLayer
{
    public class MiamDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantContactDetail> RestaurantContactDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Tag> RestaurantTags { get; set; }
        public DbSet<MiamUser> MiamUsers { get; set; }
        public DbSet<MiamRole> MiamRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantContactDetail>().HasKey(c => c.RestaurantId);
            modelBuilder.Entity<RestaurantContactDetail>()
                .HasRequired(c => c.Restaurant)
                .WithOptional(r => r.RestaurantContactDetail)
                .WillCascadeOnDelete();

            //modelBuilder.Entity<Review>()
            //    .HasOptional(r => r.Restaurant)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Review>()
            //.HasOptional(r => r.Writer)
            //.WithMany()
            //.WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            // Wrapper for SaveChanges adding the Validation Messages to the generated exception
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    ); // Add the original exception as the innerException
            }
        }
    }
}