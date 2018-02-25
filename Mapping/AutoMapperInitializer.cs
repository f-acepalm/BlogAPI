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
        private static bool _isInitialized = false;

        public static void Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(
                        conf =>
                        {
                            conf.AddProfile<PostMappingProfile>();
                            conf.AddProfile<CommentMappingProfile>();
                        });

                _isInitialized = true;
            }
        }
    }
}
