﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using IDataAccessLayer;
using IDataAccessLayer.Entities;

namespace BlogAPI.Controllers
{
    public class PostsController : ApiController
    {
        private IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<IDataAccessLayer.Entities.Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public IHttpActionResult GetPosts(int id)
        {
            var post = _postRepository.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}