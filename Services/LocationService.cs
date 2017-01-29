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
    public class LocationService
    {
        private ApplicationDbContext Context { get; }
        private ILogger<LocationService> Log { get; }
        private readonly IMapper _mapper;

        public LocationService(ApplicationDbContext context,  ILogger<LocationService> log, IMapper mapper)
        {
            Context = context;
            Log = log;
            _mapper = mapper;
        }

        public List<Location> GetAll()
        {
            try
            {
                return Context.Locations.ToList().Select(location => _mapper.Map<Location>(location)).ToList();
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading All Units, {Error}", ex);
                return new List<Location>();
            }
        }

        public Location GetById(Int32 id)
        {
            try
            {
                var location = Context.Locations.FirstOrDefault(loc => loc.Id == id);
                return _mapper.Map<Location>(location);
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading Location {Id}, {Error}", id, ex);
                return null;
            }
        }

        public async Task<Int32> AddLocation(Location location)
        {
            try
            {
                if(location.Id != 0)
                {
                    throw new InvalidOperationException();
                }

                var ent = _mapper.Map<Data.Entities.Location>(location);
                Context.Locations.Add(ent);

                await Context.SaveChangesAsync();

                return ent.Id;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Adding Location, {Error}",  ex);
                return -1;
            }            
        }

        public async Task<Boolean> UpdateULocation(Location location)
        {
            try
            {
                var ent = Context.Locations.FirstOrDefault(u => u.Id == location.Id);
                
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
                var location = Context.Locations.FirstOrDefault(loc => loc.Id == id);

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