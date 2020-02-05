using Forecast.Factories;
using Forecast.Models;
using Forecast.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Forecast.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenFactory tokenFactory;
        private readonly IUserRepository userRepository;

        public AuthController(ITokenFactory tokenFactory, IUserRepository userRepository)
        {
            this.tokenFactory = tokenFactory;
            this.userRepository = userRepository;
        }

        [HttpGet("refresh/{tokenValue}")]
        public IActionResult GetRefreshToken([FromRoute] string tokenValue)
        {
            // Preconditions
            Contract.Requires(tokenValue != null);

            IActionResult response;
            UserToken userToken = userRepository.GetAuthenticationToken(tokenValue);

            if (userToken != null)
            {
                User user = userRepository.FindById(userToken.UserId);
                string accessToken = tokenFactory.GenerateAccessToken(user);
                string refreshToken = tokenFactory.GenerateRefreshToken();
                userRepository.SetAuthenticationToken(user.Id, JwtBearerDefaults.AuthenticationScheme, "Refresh", refreshToken);
                response = Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
            }
            else
            {
                response = BadRequest(new { Message = "Refresh token not found" });
            }

            return response;
        }

        [HttpGet]
        public IActionResult SignIn([FromBody] User userRequest)
        {
            // Preconditions
            Contract.Requires(userRequest != null);

            IActionResult response;
            User user = userRepository.Authenticate(userRequest.Username, userRequest.Password);

            if (user != null)
            {
                string accessToken = tokenFactory.GenerateAccessToken(user);
                string refreshToken = tokenFactory.GenerateRefreshToken();
                userRepository.SetAuthenticationToken(user.Id,JwtBearerDefaults.AuthenticationScheme, "Refresh", refreshToken);
                response = Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
            }
            else
            {
                response = BadRequest(new { Message = "Username or password invalid" });
            }

            return response;
        }
    }
}