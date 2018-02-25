using AutoMapper;
using DataAccessLayer.Interfaces;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PostService : IPostService
    {
        private IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public virtual async Task<Post> Create(Post model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var serviceModel = Mapper.Map<Models.Post>(model);
            var result = await _repository.Create(Mapper.Map<DataAccessLayer.Entities.Post>(serviceModel));
            serviceModel = Mapper.Map<Models.Post>(result);

            return Mapper.Map<Post>(serviceModel);
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

        public virtual async Task<Post> Get(int id)
        {
            var serviceModel = Mapper.Map<Models.Post>(await _repository.Get(id));
            if (serviceModel == null)
            {
                throw new KeyNotFoundException($"No item with Id = {id}.");
            }

            return Mapper.Map<Post>(serviceModel);
        }

        public virtual async Task<List<Post>> GetAll()
        {
            var serviceModels = Mapper.Map<List<Models.Post>>(await _repository.GetAll());

            return Mapper.Map<List<Post>>(serviceModels);
        }

        public virtual async Task Update(int id, Post model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.Id = id;

            try
            {
                var serviceModel = Mapper.Map<Models.Post>(model);
                await _repository.Update(Mapper.Map<DataAccessLayer.Entities.Post>(serviceModel));
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"{id} is invalid Id.", ex);
            }
        }
    }
}
