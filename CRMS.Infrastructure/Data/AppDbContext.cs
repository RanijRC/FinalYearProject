using CRMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMS.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Complaint> Complaints { get; set;}

        //General Departments/ Faculty / Branch
        public DbSet<GeneralDepartment> GeneralDepartments { get; set;}
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Branch> Branches { get; set;}

        //Country / City/ Town
        public DbSet<Country> Countrys { get; set;}
        public DbSet<City> Cities { get; set;}
        public DbSet<Town> Towns { get; set;}


        //Authentication /Role /System Roles
        public DbSet<ApplicationUser> ApplicationUsers { get; set;}
        public DbSet<SystemRole> SystemRoles { get; set;}
        public DbSet<UserRole> UserRoles { get; set;}
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set;}

        //Other / Pending
        public DbSet<DataPending> DataPendings { get; set;}
    }
}
