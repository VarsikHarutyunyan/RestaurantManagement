using RestaurantManagement.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entities
{
    public class Order :BaseEntity, ITrackable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdateAt { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
