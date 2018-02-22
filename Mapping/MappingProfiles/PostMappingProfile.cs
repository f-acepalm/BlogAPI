using AutoMapper;
using Models;
using IDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.MappingProfiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<IDataAccessLayer.Entities.Post, IServices.Entities.Post>();
            CreateMap<IServices.Entities.Post, IDataAccessLayer.Entities.Post>();

            CreateMap<Models.Post, IServices.Entities.Post>();
            CreateMap<IServices.Entities.Post, Models.Post>();
        }
    }
}
