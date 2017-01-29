using System;
using System.Threading.Tasks;
using System.Linq;
using RedSquirrel.Models;
using AutoMapper;
using ApplicationDbContext = RedSquirrel.Data.ApplicationDbContext;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace RedSquirrel.Services
{
    public class UnitService
    {
        
        private ApplicationDbContext Context { get; }
        private ILogger<UnitService> Log { get; }
        private readonly IMapper _mapper;

        public UnitService(ApplicationDbContext context,  ILogger<UnitService> log, IMapper mapper)
        {
            Context = context;
            Log = log;
            _mapper = mapper;
        }

        public List<Unit> GetAll()
        {
            try
            {
                var all =  Context.Units.ToList();
                
                return Context.Units.ToList().Select(unit => _mapper.Map<Unit>(unit)).ToList();
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading All Units, {Error}", ex);
                return new List<Unit>();
            }
        }

        public Unit GetById(Int32 id)
        {
            try
            {
                var unit = Context.Units.FirstOrDefault(u => u.Id == id);
                return _mapper.Map<Unit>(unit);
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading Unit {Id}, {Error}", id, ex);
                return null;
            }
        }

        public async Task<Boolean> Delete(Int32 id)
        {
            try
            {
                var unit = Context.Units.FirstOrDefault(u => u.Id == id);
                
                if(unit == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                Context.Units.Remove(unit);
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Deleting Unit {Id}, {Error}", id, ex);
                return false;
            }
        }
    }
}