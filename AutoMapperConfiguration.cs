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
            config.CreateMap<Models.Location, RedSquirrel.Data.Entities.Location>().ReverseMap();
            config.CreateMap<Models.Food, RedSquirrel.Data.Entities.Food>().ReverseMap();
            config.CreateMap<Models.User, RedSquirrel.Data.Entities.User>().ReverseMap();
        }
    }
}