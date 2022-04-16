using System.Data.Entity;

namespace TestingSystem.Models.EntityDB
{
    public partial class TestSystem : DbContext
    {
        public TestSystem()
            : base("name=TestSystemEntity")
        {
        }

        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<UserTest> UserTest { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.FtpPath)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.UserTest)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.TestId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Patronymic)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TestField)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserTest)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
