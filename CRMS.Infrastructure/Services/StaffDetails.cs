using CRMS.Application.Common.Interface;
using CRMS.Application.DTOs;
using CRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Infrastructure.Services
{
    public class StaffDetails : IStaffDetails
    {
        private readonly IApplicationDbContext _dbContext;
        public StaffDetails(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StaffResponseDTO> AddStaffDetails(StaffRequestDTO staff)
        {
            var staffDetails = new Staff()
            {
                JoinDate = staff.JoinDate,
                FacultyId = staff.FacultyId
            };
            await _dbContext.Staff.AddAsync(staffDetails);
            await _dbContext.SaveChangesAsync(default(CancellationToken));

            var result = new StaffResponseDTO()
            {
                Status = staffDetails.Status,
                FacultyId = staffDetails.FacultyId
            };
            return result;
        }

        public Task<List<StaffResponseDTO>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<List<StaffResponseDTO>> GetAllUserAsync()
        {
            var data = (from staffData in _dbContext.Staff
                        join facult in _dbContext.Faculty
                            on staffData.FacultyId equals facult.Id
                        select new StaffResponseDTO()
                        {
                            Status = staffData.Status,
                        }).ToList();


            return Task.FromResult(data);
        }
    }
}
