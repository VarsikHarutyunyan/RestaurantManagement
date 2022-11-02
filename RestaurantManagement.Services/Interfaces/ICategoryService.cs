using RestaurantManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.Interfaces
{
    public interface ICategoryService
    {
        CategoryModel Get(Guid id);
        List<CategoryModel> GetAll();
        Task AddAsync(CategoryCreateModel model);
        Task<CategoryModel> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(CategoryModel model);
    }
}
