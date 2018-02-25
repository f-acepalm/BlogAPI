using AutoMapper;
using DataAccessLayer.Interfaces;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<Comment> Create(Comment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var serviceModel = Mapper.Map<Models.Comment>(model);
            var result = await _repository.Create(Mapper.Map<DataAccessLayer.Entities.Comment>(serviceModel));
            serviceModel = Mapper.Map<Models.Comment>(result);

            return Mapper.Map<Comment>(serviceModel);
        }

        public virtual async Task Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"{id} is invalid Id.", ex);
            }
        }

        public virtual async Task<Comment> Get(int id)
        {
            var serviceModel = Mapper.Map<Models.Comment>(await _repository.Get(id));
            if (serviceModel == null)
            {
                throw new KeyNotFoundException($"No item with Id = {id}.");
            }

            return Mapper.Map<Comment>(serviceModel);
        }

        public virtual async Task<List<Comment>> GetAll()
        {
            var serviceModels = Mapper.Map<List<Models.Comment>>(await _repository.GetAll());

            return Mapper.Map<List<Comment>>(serviceModels);
        }

        public virtual async Task Update(int id, Comment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.Id = id;

            try
            {
                var serviceModel = Mapper.Map<Models.Comment>(model);
                await _repository.Update(Mapper.Map<DataAccessLayer.Entities.Comment>(serviceModel));
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"{id} is invalid Id.", ex);
            }
        }
    }
}
