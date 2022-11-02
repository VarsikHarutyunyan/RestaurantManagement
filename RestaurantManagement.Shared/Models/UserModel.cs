using RestaurantManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestaurantManagement.Shared.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public Roles Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public DateTime LastUpdateAt { get; set; }
    }
}
