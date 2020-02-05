using Forecast.Models;

namespace Forecast.Repositories
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);

        /// <summary>
        /// Returns an authentication token for a user.
        /// </summary>
        /// <param name="tokenValue">The value of the token.</param>
        /// <returns>The authentication token for a user</returns>
        UserToken GetAuthenticationToken(string tokenValue);

        /// <summary>
        /// Find a user by id.
        /// </summary>
        /// <param name="userId">The identifier of a user.</param>
        /// <returns>If the identifier exists, return a user otherwise null.</returns>
        User FindById(string userId);

        /// <summary>
        /// Sets an authentication token for a user.
        /// </summary>
        /// <param name="userId">Identifier of a user.</param>
        /// <param name="loginProvider">The authentication scheme for the provider the token is associated with.</param>
        /// <param name="tokenName">The name of the token.</param>
        /// <param name="tokenValue">The value of the token.</param>
        void SetAuthenticationToken(string userId, string loginProvider, string tokenName, string tokenValue);
    }
}
