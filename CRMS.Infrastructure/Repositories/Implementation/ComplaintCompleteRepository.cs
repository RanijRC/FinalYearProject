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
    public class ComplaintCompleteRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<ComplaintComplete>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.ComplaintCompletes.FirstOrDefaultAsync(eid => eid.Id == id);
            if (item == null) return NotFound();

            appDbContext.ComplaintCompletes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<ComplaintComplete>> GetAll() => await appDbContext
            .ComplaintCompletes
            .AsNoTracking()
            .Include(t => t.ComplaintCompleteType)
            .ToListAsync();

        public async Task<ComplaintComplete> GetById(int id) =>
            await appDbContext.ComplaintCompletes.FirstOrDefaultAsync(eid => eid.ComplaintId == id);

        public async Task<GeneralResponse> Insert(ComplaintComplete item)
        {
            appDbContext.ComplaintCompletes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(ComplaintComplete item)
        {
            var obj = await appDbContext.ComplaintCompletes.FirstOrDefaultAsync(cid => cid.ComplaintId == item.ComplaintId);
            if (obj == null) return NotFound();
            obj.StartDate = item.StartDate;
            obj.NumberOfDays = item.NumberOfDays;
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");
    }
}
