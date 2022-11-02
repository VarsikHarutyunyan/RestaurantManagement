using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Shared.Models
{
    public class ProductCreateModel
    {
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
        public double Name { get; set; }
    }
}
