using CRMS.Application.DTOs;


namespace CRMS.Application.Common.Interface
{
    public interface IAuthentication
    {
        Task<ResponseDTO> Register(UserRegisterRequestDTO model);
        Task<ResponseDTO> Login(UserLoginRequestDTO model);
        Task<IEnumerable<UserDetailsDTO>> GetUserDetails();
    }
}
