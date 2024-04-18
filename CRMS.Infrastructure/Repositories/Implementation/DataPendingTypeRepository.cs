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
    public class DataPendingTypeRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<DataPendingType>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.DataPendingTypes.FindAsync(id);
            if (item is null) return NotFound();

            appDbContext.DataPendingTypes.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<DataPendingType>> GetAll() => await appDbContext
            .DataPendingTypes
            .AsNoTracking()
            .ToListAsync();

        public async Task<DataPendingType> GetById(int id) => await appDbContext.DataPendingTypes.FindAsync(id);

        public async Task<GeneralResponse> Insert(DataPendingType item)
        {
            if (!await CheckName(item.Name))
                return new GeneralResponse(false, "Data Pending Type already added");
            appDbContext.DataPendingTypes.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(DataPendingType item)
        {
            var obj = await appDbContext.Branches.FindAsync(item.Id);
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
