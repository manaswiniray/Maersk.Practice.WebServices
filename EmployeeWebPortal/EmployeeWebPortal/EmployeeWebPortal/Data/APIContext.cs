using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeWebPortal.Model;


namespace EmployeeWebPortal.Data
{
    public class APIContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().HasKey(e=> e.EmployeeId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
