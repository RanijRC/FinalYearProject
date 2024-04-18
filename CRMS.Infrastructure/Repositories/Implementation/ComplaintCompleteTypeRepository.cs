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
    public class ComplaintCompleteTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<ComplaintCompleteType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.ComplaintCompleteTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.ComplaintCompleteTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<ComplaintCompleteType>> GetAll() => await appDbContext
            .ComplaintCompleteTypes
            .AsNoTracking()
            .ToListAsync();

        public async Task<ComplaintCompleteType> GetById(int id) => await appDbContext.ComplaintCompleteTypes.FindAsync(id);

        public async Task<GeneralResponse> Insert(ComplaintCompleteType item)
        {
            if (!await CheckName(item.Name!))
                return new GeneralResponse(false, "Complaint Complete Type already added");
            appDbContext.ComplaintCompleteTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(ComplaintCompleteType item)
        {
            var obj = await appDbContext.ComplaintCompleteTypes.FindAsync(item.Id);
            if (obj is null) return NotFound();
            obj.Name = item.Name;
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private static GeneralResponse NotFound() => new(false, "Sorry overtype not found");

        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.DataPendingTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}



