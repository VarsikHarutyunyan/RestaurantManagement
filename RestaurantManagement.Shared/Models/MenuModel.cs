using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Shared.Models
{
    public class MenuModel
    {
        public Guid Id { get; set; }
        public List<string> Products { get; set; }
    }
}
