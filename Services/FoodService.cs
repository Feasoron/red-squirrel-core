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
    public class FoodService : DataBackedService
    {
        private ILogger<FoodService> Log { get; }

        public FoodService(ApplicationDbContext context,  ILogger<FoodService> log, IMapper mapper)
            :base(context, mapper)
        {
            Log = log;
        }

        public async Task<List<Food>> GetAll(Int64 userId)
        {
            try
            {
                var all = await Context.Foods
                    .Where(x => x.Owner == null || x.Owner.UserId == userId ).ToListAsync();
                
                return all.Select(food => Mapper.Map<Food>(food)).ToList();
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading All Foods, {Error}", ex);
                return new List<Food>();
            }
        }

        public async Task<Food> GetById(Int32 id)
        {
            try
            {
                var food = await Context.Foods.FirstOrDefaultAsync(f => f.Id == id);
                return Mapper.Map<Food>(food);
            }
            catch(Exception ex)
            {
                Log.LogError("Error Loading Food {Id}, {Error}", id, ex);
                return null;
            }
        }

        public async Task<Int64> AddFood(Food food, Int64 userId)        
        {
            try
            {
                if(food.Id.HasValue && food.Id != 0)
                {
                    throw new InvalidOperationException();
                }
                
                var ent = Mapper.Map<Data.Entities.Food>(food);
                
                var user = await Context.Users.FirstAsync(u => u.UserId == userId);
                ent.Owner = user;
                
                await Context.Foods.AddAsync(ent);
                await Context.SaveChangesAsync();

                return ent.Id;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Adding Food, {Error}",  ex);
                return -1;
            }            
        }

        public async Task<Boolean> UpdateFood(Food food)
        {
            try
            {
                var ent = await Context.Foods.FirstOrDefaultAsync(f => f.Id == food.Id);
                
                if(ent == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                ent.Name = food.Name;
                await Context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Updating Food {Id}, {Error}", food.Id, ex);
                return false;
            }
        }

        public async Task<Boolean> Delete(Int32 id)
        {
            try
            {
                var food = await Context.Foods.FirstOrDefaultAsync(u => u.Id == id);
                
                if(food == null)
                {
                    // TODO replace with a Not Found Exception
                    throw new Exception();
                }

                Context.Foods.Remove(food);
                await Context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Log.LogError("Error Deleting Food {Id}, {Error}", id, ex);
                return false;
            }
        }
    }
}