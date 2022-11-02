using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Shared.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual UserModel User { get; set; }
    }
}
