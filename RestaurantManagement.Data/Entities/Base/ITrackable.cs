using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entities.Base
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        DateTime LastUpdateAt { get; set; }
    }
}
