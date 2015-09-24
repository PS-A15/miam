using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Miam.Domain.Entities
{
    public class MiamRole : Entity
    {

        public string RoleName { get; set; }

        //Navigation properties
        public ICollection<MiamUser> MiamUsers { get; set; }

        public MiamRole()
        {
            MiamUsers = new List<MiamUser>();
        }
    }
}