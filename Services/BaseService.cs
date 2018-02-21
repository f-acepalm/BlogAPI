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

        public void Create(ServiceType entity)
        {
            _repository.Create(Mapper.Map<DbType>(entity));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ServiceType Get(int id)
        {
            return Mapper.Map<ServiceType>(_repository.Get(id));
        }

        public List<ServiceType> GetAll()
        {
            return Mapper.Map<List<ServiceType>>(_repository.GetAll());
        }

        public void Update(ServiceType entity)
        {
            try
            {
                _repository.Update(Mapper.Map<DbType>(entity));
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }
    }
}
