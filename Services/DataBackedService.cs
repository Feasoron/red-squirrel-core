using AutoMapper;
using RedSquirrel.Data;

namespace RedSquirrel.Services
{
    public class DataBackedService
    {
        protected ApplicationDbContext Context { get; }
        protected readonly IMapper Mapper;

        protected DataBackedService(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}