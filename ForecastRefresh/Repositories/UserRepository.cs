using Forecast.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Forecast.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly IEnumerable<User> Users = new User[3]
        {
            new User { Id = Guid.NewGuid().ToString("N", null), Username = "damon", Password = "password" },
            new User { Id = Guid.NewGuid().ToString("N", null), Username = "inubb", Password = "password" },
            new User { Id = Guid.NewGuid().ToString("N", null), Username = "charley", Password = "password" }
        };

        private static readonly ICollection<UserToken> UserTokens = new List<UserToken>();

        public User Authenticate(string username, string password)
        {
            // Preconditions
            Contract.Requires(username != null);
            Contract.Requires(password != null);

            return Users.Where(user => user.Username == username && user.Password == password)
                        .FirstOrDefault();
        }

        public User FindById(string userId)
        {
            // Preconditions
            Contract.Requires(userId != null);

            return Users.Where(user => user.Id == userId).FirstOrDefault();
        }

        public UserToken GetAuthenticationToken(string tokenValue)
        {
            // Preconditions
            Contract.Requires(tokenValue != null);

            return UserTokens.Where(ut => ut.TokenValue == tokenValue)
                             .FirstOrDefault();
        }

        public void SetAuthenticationToken(string userId, string loginProvider, string tokenName, string tokenValue)
        {
            UserTokens.Add(new UserToken(userId, loginProvider, tokenName, tokenValue));
        }
    }
}
