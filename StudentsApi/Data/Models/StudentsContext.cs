using Microsoft.EntityFrameworkCore;

namespace StudentsApi.Data.Models
{
    public partial class StudentsContext : DbContext
    {
        public StudentsContext()
        {
        }

        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentGroups> StudentGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Group")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(16);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<StudentGroups>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.GroupId });

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGroups_Group");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentGroups)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGroups_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
