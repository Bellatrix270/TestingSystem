using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestingSystem.Models.DomainModel
{
    public partial class TestSystem : DbContext
    {
        public TestSystem()
            : base("name=TestSystemEntity")
        {
        }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User_test> User_test { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.ftp_path)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.user_test)
                .WithRequired(e => e.test)
                .HasForeignKey(e => e.test_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.test_field)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.user_test)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
