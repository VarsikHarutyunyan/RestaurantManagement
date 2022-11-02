using AutoMapper;
using RestaurantManagement.Data.Entities;
using RestaurantManagement.Data.Repository.Interfaces;
using RestaurantManagement.Services.Interfaces;
using RestaurantManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.Services
{
    public class OrderService: IOrderService
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(OrderCreateModel model)
        {
            var user = _mapper.Map<Order>(model);
            await _repository.InsertAsync(user);
            await _repository.SaveAsync();

        }
        public async Task<OrderModel> GetAsync(Guid id)
        {
            var userModel = await _repository.GetByIdAsync(id);
            if (userModel == null)
            {
                return null;
            }

            var user = _mapper.Map<OrderModel>(userModel);
            return user;
        }

        public async Task RemoveAsync(Guid id)
        {
            await _repository.DeleteAsync(id); ;
            await _repository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(OrderModel model)
        {
            var user = await _repository.GetByIdAsync(model.Id);

            if (user == null)
                return false;

            var entity = _mapper.Map<Order>(user);
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
            return true;
        }

        public OrderModel Get(Guid id)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return null;
            }

            var entity = _mapper.Map<OrderModel>(model);
            return entity;
        }

        public List<OrderModel> GetAll()
        {
            var orders = _repository.GetAll();

            if (orders == null)
                return null;

            return _mapper.Map<List<OrderModel>>(orders);
        }
    }
}
    

