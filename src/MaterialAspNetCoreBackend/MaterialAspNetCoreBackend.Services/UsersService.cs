using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPNETCore2JwtAuthentication.DataLayer.Context;
using MaterialAspNetCoreBackend.DomainClasses;
using Microsoft.EntityFrameworkCore;

namespace MaterialAspNetCoreBackend.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsersIncludeNotesAsync();
        Task<User> GetUserIncludeNotesAsync(int id);
        Task<User> AddUserAsync(User user);
    }

    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;

        public UsersService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _users = _uow.Set<User>();
        }

        public Task<List<User>> GetAllUsersIncludeNotesAsync()
        {
            return _users.Include(user => user.UserNotes).ToListAsync();
        }

        public Task<User> GetUserIncludeNotesAsync(int id)
        {
            return _users.Include(user => user.UserNotes).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var userEntry = _users.Add(user);
            await _uow.SaveChangesAsync();
            return userEntry.Entity;
        }
    }
}