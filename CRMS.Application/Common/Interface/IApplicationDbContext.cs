using CRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CRMS.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<Complaint> Complaint { get; set; }
        DbSet<Faculty> Faculty { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
