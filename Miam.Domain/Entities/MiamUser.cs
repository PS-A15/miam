using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class MiamUser : Entity
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        //Navigation properties
        [Required]
        public virtual ICollection<MiamRole> Roles { get; set; }

        public MiamUser()
        {
            Roles = new List<MiamRole>();
        }
  
    }
}