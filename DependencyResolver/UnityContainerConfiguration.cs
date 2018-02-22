using DataAccessLayer;
using IDataAccessLayer;
using IServices;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Exceptions;
using Unity.Lifetime;

namespace BlogAPI
{
    public static class UnityContainerConfiguration 
    {
        public static UnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IPostRepository, PostRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IPostService, PostService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentService, CommentService>(new HierarchicalLifetimeManager());

            container.RegisterType<IBlogDbContext, BlogDbContext>(new HierarchicalLifetimeManager());
            
            return container;
        }
    }
}