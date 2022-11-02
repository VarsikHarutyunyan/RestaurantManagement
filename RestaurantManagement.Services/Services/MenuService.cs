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
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Menu> _repository;
        private readonly IMapper _mapper;
        public MenuService(IGenericRepository<Menu> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(MenuCreateModel model)
        {
            var user = _mapper.Map<Menu>(model);
            await _repository.InsertAsync(user);
            await _repository.SaveAsync();

        }
        public async Task<MenuModel> GetAsync(Guid id)
        {
            var userModel = await _repository.GetByIdAsync(id);
            if (userModel == null)
            {
                return null;
            }

            var user = _mapper.Map<MenuModel>(userModel);
            return user;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.DeleteAsync(id); ;
            await _repository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(MenuModel model)
        {
            var user = await _repository.GetByIdAsync(model.Id);

            if (user == null)
                return false;

            var entity = _mapper.Map<Menu>(user);
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public MenuModel Get(Guid id)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return null;
            }

            var entity = _mapper.Map<MenuModel>(model);
            return entity;
        }

        public List<MenuModel> GetAll()
        {
            var menus = _repository.GetAll();

            if (menus == null)
                return null;


            return _mapper.Map<List<MenuModel>>(menus);
        }
    }
}
