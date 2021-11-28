using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentCRUD.Models;

namespace StudentCRUD.Helper
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) :  base(options)
        {

        }

        public DbSet<ClassEntities> ClassEntities { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Student> Student { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntities && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entitychange in entries)
            {
                var entity = (BaseEntities)entitychange.Entity;

                entity.ModifiedDate = DateTime.Now;

                if (entitychange.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }


    }
}