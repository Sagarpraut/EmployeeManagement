using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoviesApp.Models
{
    public partial class EmpDBContext : DbContext
    {
        public EmpDBContext()
        {
        }

        public EmpDBContext(DbContextOptions<EmpDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=FSIND-LT-08\\SQLEXPRESS;Database=EmpDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMPLOYEE__14CCF2EEE989676C");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Firstnme)
                    .IsRequired()
                    .HasColumnName("FIRSTNME")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Middle)
                    .IsRequired()
                    .HasColumnName("MIDDLE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno)
                    .HasColumnName("PHONENO")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Workdept)
                    .HasColumnName("WORKDEPT")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
