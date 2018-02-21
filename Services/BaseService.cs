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

        public async Task Create(ServiceType entity)
        {
            await _repository.Create(Mapper.Map<DbType>(entity));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
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

        public async Task Update(ServiceType entity)
        {
            try
            {
                await _repository.Update(Mapper.Map<DbType>(entity));
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
