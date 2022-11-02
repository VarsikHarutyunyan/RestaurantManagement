using RestaurantManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Data.Entities;
using RestaurantManagement.Data.Repository.Interfaces;
using AutoMapper;
using RestaurantManagement.Shared.Models;

namespace RestaurantManagement.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryCreateModel model)
        {
            var user = _mapper.Map<Category>(model);
            await _repository.InsertAsync(user);
            await _repository.SaveAsync();

        }
        public async Task<CategoryModel> GetAsync(Guid id)
        {
            var userModel = await _repository.GetByIdAsync(id);
            if (userModel == null)
            {
                return null;
            }

            var user = _mapper.Map<CategoryModel>(userModel);
            return user;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.DeleteAsync(id); ;
            await _repository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(CategoryModel model)
        {
            var user = await _repository.GetByIdAsync(model.Id);

            if (user == null)
                return false;

            var entity = _mapper.Map<Category>(user);
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public CategoryModel Get(Guid id)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return null;
            }

            var entity = _mapper.Map<CategoryModel>(model);
            return entity;
        }

        public List<CategoryModel> GetAll()
        {
            var menus = _repository.GetAll();

            if (menus == null)
                return null;

            return _mapper.Map<List<CategoryModel>>(menus);

        }
    }
    
    
}
