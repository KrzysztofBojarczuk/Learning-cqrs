using CQRS.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.INFRASTRUCTURE.Data
{
    public class AppDbContext : IdentityDbContext<AppUserEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<AddressEntity> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUserEntity>()
                .HasMany(e => e.EmployeeEntities)
                .WithOne(e => e.AppUserEntity)
                .HasForeignKey(e => e.AppUserId)
                .IsRequired();

            modelBuilder.Entity<AppUserEntity>()
                .HasMany(e => e.TaskEntity)
                .WithOne(e => e.AppUserEntity)
                .HasForeignKey(e => e.AppUserId)
                .IsRequired();

            modelBuilder.Entity<AppUserEntity>()
               .HasMany(e => e.AddressEntity)
               .WithOne(e => e.AppUserEntity)
               .HasForeignKey(e => e.AppUserId)
               .IsRequired();
        }
    }
}
