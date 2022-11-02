using RestaurantManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Get(Guid id);
        IQueryable<UserModel> GetAll();
        Task AddAsync(UserCreateModel user);
        Task<UserModel> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(UserModel user);
    }
}
