using System;
using System.Threading.Tasks;
using System.Linq;
using RedSquirrel.Models;
using AutoMapper;
using ApplicationDbContext = RedSquirrel.Data.ApplicationDbContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RedSquirrel.Services
{
    public class UnitService :DataBackedService
    {
        private ILogger<UnitService> Log { get; }

        public UnitService(ApplicationDbContext context,  ILogger<UnitService> log, IMapper mapper)
            :base(context, mapper)
        {
            Log = log;
        }

        public async Task<List<Unit>> GetAll(Int64 userId)
        {
            try
            {
                var all =  await Context.Units.Where(x => x.Owner == null || x.Owner.UserId == userId ).ToListAsync();
                
                return all
                    .Select(unit => Mapper.Map<Unit>(unit))
                    .ToList();
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading All Units, {Error}", ex);
                return new List<Unit>();
            }
        }

        public async Task<Unit> GetById(Int32 id)
        {
            try
            {
                var unit = await Context.Units.FirstOrDefaultAsync(u => u.Id == id);
                return Mapper.Map<Unit>(unit);
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading Unit {Id}, {Error}", id, ex);
                return null;
            }
        }

        public async Task<Int64> AddUnit(Unit unit, Int64 userId)        
        {
            try
            {
                if(unit.Id != null && unit.Id != 0)
                {
                    throw new InvalidOperationException();
                }

                var ent = Mapper.Map<Data.Entities.Unit>(unit);
                
                var user = await Context.Users.FirstAsync(u => u.UserId == userId);
                ent.Owner = user;
                
                await Context.Units.AddAsync(ent);
                await Context.SaveChangesAsync();

                return ent.Id;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Adding Unit, {Error}",  ex);
                return -1;
            }            
        }

        public async Task<Boolean> UpdateUnit(Unit unit)
        {
            try
            {
                var ent = await Context.Units.FirstOrDefaultAsync(u => u.Id == unit.Id);
                
                if(ent == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                ent.Name = unit.Name;
                await Context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Updating Unit {Id}, {Error}", unit.Id, ex);
                return false;
            }
        }

        public async Task<Boolean> Delete(Int32 id)
        {
            try
            {
                var unit = await Context.Units.FirstOrDefaultAsync(u => u.Id == id);
                
                if(unit == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }
                
                Log.LogDebug("About to remove unit " + id);
                Context.Units.Remove(unit);
                await Context.SaveChangesAsync();
                Log.LogDebug("Removed unit " + id);
                
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