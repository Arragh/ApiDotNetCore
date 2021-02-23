using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ApiDotNetCore.Models.ContextModels
{
    public class EFUsersRepository : IUsersRepository
    {
        private UsersContext context;
        public EFUsersRepository(UsersContext context) => this.context = context;

        public IQueryable<User> Users => context.Users.AsNoTracking();

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(Guid userId)
        {
            User user = Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public User GetUser(Guid userId) => Users.FirstOrDefault(u => u.UserId == userId);

        public void UpdateUser(User user)
        {
            if (GetUser(user.UserId) != null)
            {
                context.Users.Update(user);
                context.SaveChanges();
            }
        }
    }
}
