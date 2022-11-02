using RestaurantManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.Interfaces
{
    public interface IOrderService
    {
        OrderModel Get(Guid id);
        List<OrderModel> GetAll();
        Task AddAsync(OrderCreateModel user);
        Task<OrderModel> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(OrderModel user);
    }
}
