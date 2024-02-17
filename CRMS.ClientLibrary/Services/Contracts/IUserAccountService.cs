using CRMS.BaseLibrary.DTOs;
using CRMS.BaseLibrary.Response;


namespace CRMS.ClientLibrary.Services.Contracts
{
    public interface IUserAccountService
    {
        Task<GeneralResponse> CreateAsync(AccountRegister user);
        Task<LoginResponse> SignInAsync(AccountLogin user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
        Task<WeatherForecast[]> GetWeatherForecast();
    }
}
