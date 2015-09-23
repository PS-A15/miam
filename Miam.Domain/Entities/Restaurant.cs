using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Miam.Domain.Entities
{
    public class Restaurant : Entity
    {

        [Required] 
        [MaxLength(250)]
        public string Name { get; set; }
        [Required] 
        public string City { get; set; }
        public string AAA{ get; set; }
        [Required] 
        public string Country { get; set; }
        
        //Navigation properties
        public virtual RestaurantContactDetail RestaurantContactDetail { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Restaurant()
        {
            Reviews = new List<Review>();
            Tags = new List<Tag>();
        }

        public float CalculateReviewsRatingAverage()
        {
            // Solution 1 : avec LinQ
            if (Reviews.Count != 0)
            {
                return (float)Reviews.Select(x => x.Rating).Average();
            }
            return 0;


            /// Solution 2
            //float somme = 0;

            //foreach (var review in Reviews)
            //{
            //    somme = somme + review.Rating;
            //}

            //if (Reviews.Count != 0)
            //{
            //    return somme/(Reviews.Count);
            //} 

            //return 0;
        }

    }
}
