using MalaikaSchool.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MalaikaSchool.Data
{
    public class MalaikaDbContext : IdentityDbContext<AppUser>
    {
      

        public MalaikaDbContext(DbContextOptions<MalaikaDbContext> options)
            : base(options)
        {
        }

        public DbSet<GuardianType> GuardianType { get; set; }
        public DbSet<Guardian> Guardian { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Admission> Admission { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamType { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
        public DbSet<AssignRoll> AssignRoll { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<ExamTitle> ExamTitle { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducation { get; set; }
        public DbSet<EmploymentHistory> EmploymentHistory { get; set; }
        public DbSet<JobInfo> JobInfo { get; set; }
        public DbSet<ClassFee> ClassFee { get; set; }
        public DbSet<AccountList> AccountList { get; set; }
        public DbSet<DefaultSetting> DefaultSetting { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Event> Events { get; set; }     
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<StaffAttendance> staffAttendances { get; set; }
        public DbSet<SchedulerEvent> SchedulerEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {

                property.SetColumnType("decimal(18,2)");


            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasOne(b => b.Employee)
                .WithOne(i => i.AppUser)
                .HasForeignKey<Employee>(b => b.AppUserId);

            modelBuilder.Entity<AppUser>()
               .HasOne(b => b.Student)
               .WithOne(i => i.UserStudent)
               .HasForeignKey<Student>(b => b.AppUserId);

            modelBuilder.Entity<AppUser>()
               .HasOne(b => b.Guardian)
               .WithOne(i => i.UserGuardian)
               .HasForeignKey<Guardian>(b => b.AppUserId);

           
            }
    }
}

