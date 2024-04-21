using CRMS.Application.Responses;
using CRMS.Domain.Entities;
using CRMS.Infrastructure.Data;
using CRMS.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMS.Infrastructure.Repositories.Implementation
{
    public class ComplaintRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Complaint>
    {
        public async Task<List<Complaint>> GetAll()
        {
            var complaints = await appDbContext.Complaints
            .AsNoTracking()
            .Include(t => t.Town)
            .ThenInclude(ci => ci.City)
            .ThenInclude(c => c.Country)
            .Include(b => b.Branch)
            .ThenInclude(f => f.Faculty)
            .ThenInclude(gd => gd.GeneralDepartment).ToListAsync();
            return complaints;
        }

        public async Task<Complaint> GetById(int id)
        {
            var complaint = await appDbContext.Complaints
                .Include(t => t.Town)
                .ThenInclude(ci => ci.City)
                .ThenInclude(c => c.Country)
                .Include(b => b.Branch)
                .ThenInclude(f => f.Faculty)
                .ThenInclude(gd => gd.GeneralDepartment).FirstOrDefaultAsync(ei => ei.Id == id)!;
                return complaint!;
        }

        public async Task<GeneralResponse> Insert(Complaint item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Complaint already added!");

            appDbContext.Complaints.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Complaint item)
        {
            var findComplaint = await appDbContext.Complaints.FirstOrDefaultAsync(e => e.Id == item.Id);
            if (findComplaint is null) return new GeneralResponse(false, "Complaint does not exist!!");

            findComplaint.Name = item.Name;
            findComplaint.Other = item.Other;
            findComplaint.CustomerTelephoneNumber = item.CustomerTelephoneNumber;
            findComplaint.ComplaintType = item.ComplaintType;
            findComplaint.ComplaintIssue = item.ComplaintIssue;
            findComplaint.BranchId = item.BranchId;
            findComplaint.TownId = item.TownId;
            findComplaint.CustomerNumber = item.CustomerNumber;
            findComplaint.FeedbackComments = item.FeedbackComments;
            findComplaint.Photo = item.Photo;

            await appDbContext.SaveChangesAsync();
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Complaints.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.Complaints.Remove(item);
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry branch not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Complaints.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null? true: false;
        }
    }
}
