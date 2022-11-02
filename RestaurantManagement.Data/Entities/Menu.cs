using RestaurantManagement.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entities
{
    public class Menu : BaseEntity, ITrackable
    {
        public Menu()
        {
            Products =new List<string>();
        }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdateAt { get; set; }
        public List<string> Products { get; set; }
    }
}
