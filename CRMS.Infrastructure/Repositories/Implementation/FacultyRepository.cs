using CRMS.Application.Responses;
using CRMS.Domain.Entities;
using CRMS.Infrastructure.Data;
using CRMS.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;


namespace CRMS.Infrastructure.Repositories.Implementation
{
    public class FacultyRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Faculty>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Faculties.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Faculties.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Faculty>> GetAll() => await appDbContext
            .Faculties.AsNoTracking()
            .Include(gd => gd.GeneralDepartment)
            .ToListAsync();

        public async Task<Faculty> GetById(int id) => await appDbContext.Faculties.FindAsync(id);


        public async Task<GeneralResponse> Insert(Faculty item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Faculty already added");
            appDbContext.Faculties.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Faculty item)
        {
            var dep = await appDbContext.Faculties.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            dep.GeneralDepartmentId = item.GeneralDepartmentId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry faculty not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Faculties.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
