using RestaurantManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.Interfaces
{
    public interface IMenuService
    {
        MenuModel Get(Guid id);
        List<MenuModel> GetAll();
        Task AddAsync(MenuCreateModel user);
        Task<MenuModel> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(MenuModel user);
    }
}
