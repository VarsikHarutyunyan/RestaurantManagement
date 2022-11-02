using RestaurantManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.Interfaces
{
    public interface IProductService
    {
        ProductModel Get(Guid id);
        List<ProductModel> GetAll();
        Task AddAsync(ProductCreateModel model);
        Task<ProductModel> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task<bool> UpdateAsync(ProductModel model);
    }
}
