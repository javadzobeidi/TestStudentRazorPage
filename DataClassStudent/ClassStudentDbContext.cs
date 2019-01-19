using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration.Memory;

namespace DataClassStudent
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassStudentDbContext>
    //{
    //    public ClassStudentDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = new DbContextOptionsBuilder<ClassStudentDbContext>();

    //      //  var connectionString = "Server=(localdb)\\mssqllocaldb;Database=ClassStudentDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";

    //       // builder.UseSqlServer(connectionString);
    //      //  return new ClassStudentDbContext(builder.Options);
    //    }
    //}

    public   class ClassStudentDbContext:DbContext
    {
        public DbSet<Student> Students { set; get; }
        public DbSet<ClassRoom> ClassRooms { set; get; }
        public ClassStudentDbContext(DbContextOptions<ClassStudentDbContext> options) : base(options)
        {

        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClassRoom>()
                .HasMany<Student>(g => g.Students).WithOne(d => d.ClassRoom).HasForeignKey(d => d.ClassRoomId);

            
        }
    }
}
