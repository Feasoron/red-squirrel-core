using System;
using System.Linq;
using RedSquirrel.Models;
using AutoMapper;
using ApplicationDbContext = RedSquirrel.Data.ApplicationDbContext;
using System.Collections.Generic;

namespace RedSquirrel.Services
{
    public class UnitService
    {
        private readonly Lazy<ApplicationDbContext> _context = new Lazy<ApplicationDbContext>();
        private ApplicationDbContext Context => _context.Value;

    //    private IMapper _mapper { get; }

     //   public UnitService(IMapper mapper)
     //   {
    //        _mapper = mapper;
     //   }

        public List<Unit> GetAll()
        {
            try
            {
                var all =  Context.Units.ToList();
                
                return Context.Units.ToList().Select(unit => Mapper.Map<Unit>(unit)).ToList();
            }
            catch
            {
                return new List<Unit>();
            }
        }

        public Unit GetById(Int32 id)
        {
            try
            {
                var unit = Context.Units.FirstOrDefault(u => u.Id == id);
                return Mapper.Map<Unit>(unit);
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}