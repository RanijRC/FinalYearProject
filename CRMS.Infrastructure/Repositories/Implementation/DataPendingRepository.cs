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
    public class DataPendingRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<DataPending>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.DataPendings.FirstOrDefaultAsync(cid => cid.ComplaintId == id);
            if (item == null) return NotFound();

            appDbContext.DataPendings.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<DataPending>> GetAll() => await appDbContext
            .DataPendings
            .AsNoTracking()
            .Include(t => t.DataPendingType)
            .ToListAsync();


        public async Task<DataPending> GetById(int id) =>
            await appDbContext.DataPendings.FirstOrDefaultAsync(cid => cid.ComplaintId == id); 
        

        public async Task<GeneralResponse> Insert(DataPending item)
        {
            appDbContext.DataPendings.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(DataPending item)
        {
            var obj = await appDbContext.DataPendings.FirstOrDefaultAsync(cid => cid.ComplaintId == item.ComplaintId);
            if (obj is null) return NotFound();
            obj.ComplaintDateStart = item.ComplaintDateStart;
            obj.ComplaintDateEnd = item.ComplaintDateEnd;
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");
    }
}
