using AutoMapper;

namespace Mapping.MappingProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<DataAccessLayer.Entities.Comment, Services.Models.Comment>();
            CreateMap<Services.Models.Comment, DataAccessLayer.Entities.Comment>();

            CreateMap<DataAccessLayer.Entities.Comment, Models.Comment>();
            CreateMap<Models.Comment, DataAccessLayer.Entities.Comment>();

            CreateMap<Models.Comment, Services.Models.Comment>();
            CreateMap<Services.Models.Comment, Models.Comment>();
        }
    }
}
