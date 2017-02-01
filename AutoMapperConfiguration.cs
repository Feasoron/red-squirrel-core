using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace RedSquirrel
{
    public class AutoMapperConfiguration
    {
        public IMapper CreateMapper()
        {
            var config = new MapperConfiguration(CreateMappings);
            return config.CreateMapper();
        }

        private static void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Models.Unit, Data.Entities.Unit>().ReverseMap();
        }
    }
}