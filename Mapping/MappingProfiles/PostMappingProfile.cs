using AutoMapper;

namespace Mapping.MappingProfiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<DataAccessLayer.Entities.Post, Services.Models.Post>();
            CreateMap<Services.Models.Post, DataAccessLayer.Entities.Post>();

            CreateMap<Models.Post, Services.Models.Post>();
            CreateMap<Services.Models.Post, Models.Post>();
        }
    }
}
