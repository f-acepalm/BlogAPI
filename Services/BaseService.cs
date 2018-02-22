using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;
using IServices.Entities;
using IDataAccessLayer;
using AutoMapper;

namespace Services
{
    public class BaseService<ServiceType, DbType> : IService<ServiceType> 
        where ServiceType : Entity 
        where DbType : IDataAccessLayer.Entities.Entity
    {
        private IRepository<DbType> _repository;

        public BaseService(IRepository<DbType> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceType> Create(ServiceType entity)
        {
            var result = await _repository.Create(Mapper.Map<DbType>(entity));

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

        public async Task<bool> Update(ServiceType entity)
        {
            try
            {
                await _repository.Update(Mapper.Map<DbType>(entity));

                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }
        }
    }
}
