using CRMS.Application.Common.Interface;
using CRMS.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMS.WebAPI.Controllers
{
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffDetails _staffDetails;

        public StaffController(IStaffDetails staffDetails)
        {
            _staffDetails = staffDetails;
        }

        [HttpGet]
        [Route("/api/staff/all-staff")]
        public async Task<List<StaffResponseDTO>> GetAllstaffDetails()
        {
            var data = await _staffDetails.GetAllUserAsync();
            return data;
        }

        [HttpPost]
        [Route("/api/staff/add-staff")]
        public async Task<StaffResponseDTO> AddstaffDetails(StaffRequestDTO staff)
        {
            var data = await _staffDetails.AddStaffDetails(staff);
            return data;
        }
    }
}
