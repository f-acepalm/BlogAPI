using AutoMapper;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.MappingProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<IDataAccessLayer.Entities.Comment, IServices.Entities.Comment>();
            CreateMap<IServices.Entities.Comment, IDataAccessLayer.Entities.Comment>();
            
            CreateMap<Models.Comment, IServices.Entities.Comment>();
            CreateMap<IServices.Entities.Comment, Models.Comment>();
        }
    }
}
