using CRMS.BaseLibrary.DTOs;
using CRMS.BaseLibrary.Responses;

namespace CRMS.ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(AccountRegister user);
        Task<LoginResponse> SignInAsync(AccountLogin user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
    }
}
