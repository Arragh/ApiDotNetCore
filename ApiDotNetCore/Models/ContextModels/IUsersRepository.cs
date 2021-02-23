using System;
using System.Linq;

namespace ApiDotNetCore.Models.ContextModels
{
    public
        interface IUsersRepository
    {
        IQueryable<User> Users { get; }
        User GetUser(Guid userId);
        void AddUser(User user);
        void DeleteUser(Guid userId);
        void UpdateUser(User user);
    }
}
