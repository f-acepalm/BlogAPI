using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Services.Interfaces;
using Models;
using DataAccessLayer.Interfaces;

namespace Services
{
    public abstract class BaseService<TModel, TDbEntity> : IService<TModel> 
        where TModel : BaseModel 
        where TDbEntity : DataAccessLayer.Entities.Entity
    {
        private IRepository<TDbEntity> _repository;

        public BaseService(IRepository<TDbEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TModel> Create(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var result = await _repository.Create(Mapper.Map<TDbEntity>(model));

            return Mapper.Map<TModel>(result);
        }

        public virtual async Task Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{id} is invalid Id.", ex);
            }
        }

        public virtual async Task<TModel> Get(int id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
            {
                throw new ArgumentException($"No item with Id = {id}.");
            }

            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task<List<TModel>> GetAll()
        {
            var entities = await _repository.GetAll();

            return Mapper.Map<List<TModel>>(entities);
        }

        public virtual async Task Update(int id, TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.Id = id;

            try
            {
                await _repository.Update(Mapper.Map<TDbEntity>(model));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{id} is invalid Id.", ex);
            }
        }
    }
}
