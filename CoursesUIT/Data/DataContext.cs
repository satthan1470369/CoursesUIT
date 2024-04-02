using Microsoft.EntityFrameworkCore;
using CoursesUIT.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CoursesUIT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Models.CoursesUIT> CoursesUIT { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.CoursesUIT>().HasKey(h => new { h.StudentId, h.CoursesId });
            builder.Entity<Models.CoursesUIT>().HasOne(h => h.Courses).WithMany(h => h.CoursesUIT);
            builder.Entity<Models.CoursesUIT>().HasOne(h => h.Student).WithMany(h => h.CoursesUIT);

            new DbInitializer(builder).Seed();
        }

        public class DbInitializer
        {
            private readonly ModelBuilder _builder;
            public DbInitializer(ModelBuilder builder)
            {
                this._builder = builder;
            }

            public void Seed()
            {
                _builder.Entity<Student>(s =>
                {
                    s.HasData(new Student
                    {
                        StudentId = new Guid("e2397972-8743-431a-9482-60292f08320f"),
                        Name = "Lê Minh Tài"
                    });
                    s.HasData(new Student
                    {
                        StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340e2"),
                        Name = "x TheSpectre x"
                    });
                });
                _builder.Entity<Courses>(c =>
                {
                    c.HasData(new Courses
                    {
                        CourseId = new Guid("9250d994-2557-4573-8465-417248667051"),
                        CourseName = "Toán",
                        Description = "IT thì nên giỏi toán:))"
                    });
                    c.HasData(new Courses
                    {
                        CourseId = new Guid("88738493-3a75-4443-8f6a-313453432192"),
                        CourseName = "Văn",
                        Description = "Tao văn trên 5 là ok rồi",
                    });
                });
                _builder.Entity<Models.CoursesUIT>(sc =>
                {
                    sc.HasData(new Models.CoursesUIT
                    {
                        StudentId = new Guid("e2397972-8743-431a-9482-60292f08320f"),
                        CoursesId = new Guid("88738493-3a75-4443-8f6a-313453432192")
                    });
                    sc.HasData(new Models.CoursesUIT
                    {
                        StudentId = new Guid("4e79044a-988d-4488-97b7-3e474e4340e2"),
                        CoursesId = new Guid("9250d994-2557-4573-8465-417248667051")
                    });
                });
            }
        }
    }
}
