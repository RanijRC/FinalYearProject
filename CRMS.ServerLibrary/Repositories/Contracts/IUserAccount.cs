using CRMS.BaseLibrary.DTOs;
using CRMS.BaseLibrary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.ServerLibrary.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(AccountRegister user);
        Task<LoginResponse> SignInAsync(AccountLogin user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
    }
}
