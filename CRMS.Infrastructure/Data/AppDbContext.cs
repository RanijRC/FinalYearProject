using CRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMS.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Complaint> Complaints { get; set;}
        public DbSet<GeneralDepartment> GeneralDepartments { get; set;}
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<ApplicationUser> ApplicationUsers { get; set;}
        public DbSet<SystemRole> SystemRoles { get; set;}
        public DbSet<UserRole> UserRoles { get; set;}
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set;}
    }
}
