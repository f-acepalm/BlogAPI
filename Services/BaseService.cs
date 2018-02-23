using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Services.Interfaces;
using Services.Models;
using DataAccessLayer.Interfaces;

namespace Services
{
    public class BaseService<ServiceType, DbType> : IService<ServiceType> 
        where ServiceType : Entity 
        where DbType : DataAccessLayer.Entities.Entity
    {
        private IRepository<DbType> _repository;

        public BaseService(IRepository<DbType> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceType> Create(ServiceType model)
        {
            var result = await _repository.Create(Mapper.Map<DbType>(model));

            return Mapper.Map<ServiceType>(result);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<ServiceType> Get(int id)
        {
            var entity = await _repository.Get(id);
            return Mapper.Map<ServiceType>(entity);
        }

        public async Task<List<ServiceType>> GetAll()
        {
            var entities = await _repository.GetAll();
            return Mapper.Map<List<ServiceType>>(entities);
        }

        public async Task<bool> Update(ServiceType model)
        {
            try
            {
                await _repository.Update(Mapper.Map<DbType>(model));

                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }
        }
    }
}
