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
            CreateMap<IDataAccessLayer.Entities.Post, Models.Post>();
            CreateMap<Models.Post, IDataAccessLayer.Entities.Post>();
        }
    }
}
