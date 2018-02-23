using AutoMapper;
using Mapping.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(
                conf =>
                {
                    conf.AddProfile<PostMappingProfile>();
                    conf.AddProfile<CommentMappingProfile>();
                });
        }
    }
}
