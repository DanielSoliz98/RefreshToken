namespace Forecast.Models
{
    public class UserToken
    {
        public string UserId { get; }
        public string LoginProvider { get; }
        public string TokenName { get; }
        public string TokenValue { get; }

        /// <summary>
        /// Class that represents a relationship between a user and a token.
        /// </summary>
        /// <param name="userId">Identifier of a user.</param>
        /// <param name="loginProvider">The authentication scheme for the provider the token is associated with.</param>
        /// <param name="tokenName">The name of the token.</param>
        /// <param name="tokenValue">The value of the token.</param>
        public UserToken(string userId, string loginProvider, string tokenName, string tokenValue)
        {
            UserId = userId;
            LoginProvider = loginProvider;
            TokenName = tokenName;
            TokenValue = tokenValue;
        }
    }
}
