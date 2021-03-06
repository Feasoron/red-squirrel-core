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
    public class LocationService : DataBackedService
    {
        private ILogger<LocationService> Log { get; }

        public LocationService(ApplicationDbContext context,  ILogger<LocationService> log, IMapper mapper)
            :base(context, mapper)
        {
            Log = log;
        }

        public async Task<List<Location>> GetAll(Int64 userId)
        {
            try
            {
                var all = await Context.Locations
                    .Where(x => x.Owner == null || x.Owner.UserId == userId ).ToListAsync();
                return all.Select(location => Mapper.Map<Location>(location)).ToList();
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading All Units, {Error}", ex);
                return new List<Location>();
            }
        }

        public async Task<Location> GetById(Int32 id)
        {
            try
            {
                var location = await Context.Locations.FirstOrDefaultAsync(loc => loc.Id == id);
                return Mapper.Map<Location>(location);
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading Location {Id}, {Error}", id, ex);
                return null;
            }
        }

        public async Task<Int64> AddLocation(Location location, Int64 userId)
        {
            try
            {
                if(location.Id.HasValue && location.Id != 0)
                {
                    throw new InvalidOperationException();
                }

                var ent = Mapper.Map<Data.Entities.Location>(location);

                var user = await Context.Users.FirstAsync(u => u.UserId == userId);
                ent.Owner = user;
                
                await Context.Locations.AddAsync(ent);
                await Context.SaveChangesAsync();

                return ent.Id;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Adding Location, {Error}",  ex);
                return -1;
            }            
        }

        public async Task<Boolean> UpdateLocation(Location location)
        {
            try
            {
                var ent = await Context.Locations.FirstOrDefaultAsync(u => u.Id == location.Id);
                
                if(ent == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                ent.Name = location.Name;
                await Context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Updating Location {Id}, {Error}", location.Id, ex);
                return false;
            }
        }

        public async Task<Boolean> Delete(Int32 id)
        {
            try
            {
                var location = await Context.Locations.FirstOrDefaultAsync(loc => loc.Id == id);

                if(location == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                Context.Locations.Remove(location);
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Deleting Location {Id}, {Error}", id, ex);
                return false;
            }
        }
    }
}