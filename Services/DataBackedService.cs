using AutoMapper;
using RedSquirrel.Data;

namespace RedSquirrel.Services
{
    public class DataBackedService
    {
        protected ApplicationDbContext Context { get; }
        protected readonly IMapper _mapper;
        
        public DataBackedService(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }
    }
}