using Microsoft.EntityFrameworkCore;
using TEKenable_Newsletter.Data.Interfaces;

namespace TEKenable_Newsletter.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddContact(User user)
        {
            user.Email = user.Email.Trim().ToLower();
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetContactByEmail(string email)
        {
            email = email.Trim().ToLower();
            return _dbContext.Users
                .AsNoTracking()
                .FirstOrDefault(m => m.Email == email);
        }
    }
}
