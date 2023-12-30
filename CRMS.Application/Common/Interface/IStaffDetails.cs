using CRMS.Application.DTOs;
using CRMS.Domain.Entities;


namespace CRMS.Application.Common.Interface
{
    public interface IStaffDetails
    {
        Task<List<StaffResponseDTO>> GetAllUserAsync();
        Task<List<StaffResponseDTO>> GetAllUser();
        Task<StaffResponseDTO> AddStaffDetails(StaffRequestDTO staff);
    }
}
