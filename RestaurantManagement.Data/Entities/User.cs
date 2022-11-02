using RestaurantManagement.Data.Entities.Base;
using RestaurantManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entities
{
    public class User : BaseEntity, ITrackable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdateAt { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
