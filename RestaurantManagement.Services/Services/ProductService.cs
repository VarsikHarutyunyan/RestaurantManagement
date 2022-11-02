using AutoMapper;
using RestaurantManagement.Data.Entities;
using RestaurantManagement.Data.Repository.Interfaces;
using RestaurantManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Shared.Models;

namespace RestaurantManagement.Services.Services
{
    public class ProductService: IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductCreateModel model)
        {
            var user = _mapper.Map<Product>(model);
            await _repository.InsertAsync(user);
            await _repository.SaveAsync();

        }
        public async Task<ProductModel> GetAsync(Guid id)
        {
            var userModel = await _repository.GetByIdAsync(id);
            if (userModel == null)
            {
                return null;
            }

            var user = _mapper.Map<ProductModel>(userModel);
            return user;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.DeleteAsync(id); ;
            await _repository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(ProductModel model)
        {
            var user = await _repository.GetByIdAsync(model.Id);

            if (user == null)
                return false;

            var entity = _mapper.Map<Product>(user);
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public ProductModel Get(Guid id)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return null;
            }

            var entity = _mapper.Map<ProductModel>(model);
            return entity;
        }

        public List<ProductModel> GetAll()
        {
            var products = _repository.GetAll();

            if (products == null)
                return null;

          return  _mapper.Map<List<ProductModel>>(products);
           
        }
    }
}
