using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RedSquirrel.Data;
using RedSquirrel.Models;

namespace RedSquirrel.Services
{
    public class UserService : DataBackedService
    {
        // Todo - this isn't a great cache. Add redis eventually
        private static Dictionary<String, Int64> ExternalIdMap { get; } = new Dictionary<String, Int64>();
        
        public UserService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async  Task<Int64> GetOrCreateUserId(User user)
        {
            var dbUser = await Context.Users.FirstOrDefaultAsync(u => u.ExternalUserId == user.ExternalUserId);
            
            if (dbUser != null)
            {
                return dbUser.UserId;
            }

            dbUser = Mapper.Map<Data.Entities.User>(user);

            await Context.Users.AddAsync(dbUser);
            await Context.SaveChangesAsync();

            return dbUser.UserId;
        }

        public async Task<Int64> GetUserId(String externalId)
        {
            if (ExternalIdMap.ContainsKey(externalId))
            {
                return ExternalIdMap[externalId];
            }
            
            var user = await Context.Users.FirstAsync(u => u.ExternalUserId == externalId);
            ExternalIdMap.Add(externalId, user.UserId);

            return user.UserId;
        }
        
        public Int64 GetUserIdSynchronous(String externalId)
        {
            if (ExternalIdMap.ContainsKey(externalId))
            {
                return ExternalIdMap[externalId];
            }
            
            var user = Context.Users.First(u => u.ExternalUserId == externalId);
            ExternalIdMap.Add(externalId, user.UserId);

            return user.UserId;
        }
    }
}