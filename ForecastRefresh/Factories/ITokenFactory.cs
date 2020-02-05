namespace Forecast.Factories
{
    public interface ITokenFactory
    {
        string GenerateAccessToken(Models.User user);
        string GenerateRefreshToken();
    }
}
