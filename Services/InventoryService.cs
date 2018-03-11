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
    public class InventoryService : DataBackedService
    {
        private ILogger<InventoryService> Log { get; }

        public InventoryService(ApplicationDbContext context,  ILogger<InventoryService> log, IMapper mapper)
            :base(context, mapper)
        {
            Log = log;
        }

        public List<Inventory> GetAll(Int64 userId)
        {
            try
            {
                var all =  Context.Inventories
                    .Where(x => x.Owner == null || x.Owner.UserId == userId ).ToList();
                return all.Select(inventory => Mapper.Map<Inventory>(inventory)).ToList();
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading All Units, {Error}", ex);
                return new List<Inventory>();
            }
        }

        public Inventory GetById(Int32 id)
        {
            try
            {
                var inventory = Context.Locations.FirstOrDefault(inv => inv.Id == id);
                return Mapper.Map<Inventory>(inventory);
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading Location {Id}, {Error}", id, ex);
                return null;
            }
        }

        public async Task<Int64> AddInventory(Inventory inventory, Int64 userId)
        {
            try
            {
                if(inventory.Id.HasValue && inventory.Id != 0)
                {
                    throw new InvalidOperationException();
                }

                var ent = Mapper.Map<Data.Entities.Inventory>(inventory);

                var user = Context.Users.First(u => u.UserId == userId);
                ent.Owner = user;
                
                Context.Inventories.Add(ent);

                await Context.SaveChangesAsync();

                return ent.Id;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Adding Inventory, {Error}",  ex);
                return -1;
            }            
        }

        public async Task<Boolean> UpdateInventory(Inventory inventory)
        {
            try
            {
                var ent = Context.Locations.FirstOrDefault(u => u.Id == inventory.Id);
                
                if(ent == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }
                
                //create mappings
                throw new NotImplementedException();
               // await Context.SaveChangesAsync();

              //  return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Updating Inventory {Id}, {Error}", inventory.Id, ex);
                return false;
            }
        }

        public async Task<Boolean> Delete(Int32 id)
        {
            try
            {
                var inventory = Context.Inventories.FirstOrDefault(inv => inv.Id == id);

                if(inventory == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                Context.Inventories.Remove(inventory);
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Deleting Inventory {Id}, {Error}", id, ex);
                return false;
            }
        }
    }
}