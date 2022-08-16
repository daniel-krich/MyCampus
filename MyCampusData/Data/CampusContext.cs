using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCampusData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Data
{
    public class CampusContext : DbContext
    {
#nullable disable
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<ClassAssignmentEntity> ClassAssignments { get; set; }
        public DbSet<ClassAssignmentSubmissionEntity> ClassAssignmentSubmissions { get; set; }
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<ClassMeetingEntity> ClassMeetings { get; set; }
        public DbSet<UserClassEntity> UserClasses { get; set; }
        public DbSet<SessionEntity> Sessions { get; set; }

        protected readonly IConfiguration Configuration;

        public CampusContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer(Configuration.GetConnectionString("CampusDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Sessions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Classes)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);

            modelBuilder.Entity<SessionEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<CourseEntity>()
               .HasMany(x => x.Classes)
               .WithOne(x => x.Course)
               .HasForeignKey(x => x.CourseId);

            modelBuilder.Entity<ClassEntity>()
               .HasMany(x => x.Students)
               .WithOne(x => x.Class)
               .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassEntity>()
               .HasMany(x => x.Meetings)
               .WithOne(x => x.Class)
               .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassEntity>()
               .HasMany(x => x.Assignments)
               .WithOne(x => x.Class)
               .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassEntity>()
                .HasOne(x => x.Lecturer)
                .WithMany(x => x.LecturingClasses)
                .HasForeignKey(x => x.LecturerId);

            modelBuilder.Entity<ClassAssignmentEntity>()
                .HasOne(x => x.Class)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.ClassId);

            modelBuilder.Entity<ClassAssignmentEntity>()
                .HasMany(x => x.AssignmentSubmissions)
                .WithOne(x => x.Assignment)
                .HasForeignKey(x => x.AssignmentId);

            modelBuilder.Entity<ClassAssignmentSubmissionEntity>()
                .HasOne(x => x.Assignment)
                .WithMany(x => x.AssignmentSubmissions)
                .HasForeignKey(x => x.AssignmentId);
        }
    }
}
