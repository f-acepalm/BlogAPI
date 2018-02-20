using DataAccessLayer;
using IDataAccessLayer;
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

            return container;
        }
    }
}