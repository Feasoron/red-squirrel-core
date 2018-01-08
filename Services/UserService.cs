using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public Int64 GetOrCreateUserId(User user)
        {
            var dbUser = Context.Users.FirstOrDefault(u => u.ExternalUserId == user.ExternalUserId);
            
            if (dbUser != null)
            {
                return dbUser.UserId;
            }

            dbUser = Mapper.Map<Data.Entities.User>(user);

            Context.Users.Add(dbUser);
            Context.SaveChanges();

            return dbUser.UserId;
        }

        public Int64 GetUserId(String externalId)
        {
            if (ExternalIdMap.ContainsKey(externalId))
            {
                return ExternalIdMap[externalId];
            }
            
            var id = Context.Users.First(u => u.ExternalUserId == externalId).UserId;
            ExternalIdMap.Add(externalId, id);

            return id;
        }
    }
}