using System;
using System.Linq;
using AutoMapper;
using RedSquirrel.Data;

namespace RedSquirrel.Services
{
    public class UserService : DataBackedService
    {
        public UserService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Int64 GetOrCreateUserId(Models.User user)
        {
            var dbUser = Context.Users.FirstOrDefault(u => u.ExternalUserId == user.ExternalUserId);

            if (dbUser == null)
            {
                // TODO - Move to automapper
                dbUser = new Data.Entities.User()
                {
                    Email = user.Email,
                    Name = user.Name,
                    ExternalUserId = user.ExternalUserId
                };

                Context.Users.Add(dbUser);
                Context.SaveChanges();
            }

            return dbUser.UserId;
        }
    }
}