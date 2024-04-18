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
    public class FeedbackRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Feedback>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var item = await appDbContext.Feedbacks.FirstOrDefaultAsync(cid => cid.ComplaintId == id);
            if (item is null) return NotFound();

            appDbContext.Feedbacks.Remove(item);
            await Commit();
            return Success();
        }

        public async Task<List<Feedback>> GetAll() => await appDbContext
            .Feedbacks
            .AsNoTracking()
            .ToListAsync();

        public async Task<Feedback> GetById(int id) => 
            await appDbContext.Feedbacks.FirstOrDefaultAsync(cid => cid.ComplaintId == id);

        public async Task<GeneralResponse> Insert(Feedback item)
        {
            appDbContext.Feedbacks.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Feedback item)
        {
            var obj = await appDbContext.Feedbacks.FirstOrDefaultAsync(cid => cid.ComplaintId == item.ComplaintId);
            if(obj is null) return NotFound();
            obj.FeedbackRecomendation = item.FeedbackRecomendation;
            obj.ComplaintFeedback = item.ComplaintFeedback;
            obj.Date = item.Date;
            await Commit();
            return Success();
        }
        
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry data not found");
        private static GeneralResponse Success() => new(true, "Process completed");
    }
}
