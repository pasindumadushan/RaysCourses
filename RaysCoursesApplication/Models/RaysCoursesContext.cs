using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RaysCoursesWebAPI.Models
{
    public partial class RaysCoursesContext : DbContext
    {
        public RaysCoursesContext()
        {
        }

        public RaysCoursesContext(DbContextOptions<RaysCoursesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RaysCourses;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Ccategory)
                    .IsRequired()
                    .HasColumnName("CCategory");

                entity.Property(e => e.CdateOfIntake)
                    .HasColumnName("CDateOfIntake")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.Cfaculty)
                    .IsRequired()
                    .HasColumnName("CFaculty");

                entity.Property(e => e.Cfee)
                    .HasColumnName("CFee")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("CName");

                entity.Property(e => e.Cyears)
                    .HasColumnName("CYears")
                    .HasMaxLength(50);

                entity.HasOne(d => d.UniRef)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.UniRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Course__UniRefId__38996AB5");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.UniId);

                entity.Property(e => e.UniAddr).IsRequired();

                entity.Property(e => e.UniName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UniPnum)
                    .IsRequired()
                    .HasColumnName("UniPNum")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid).HasColumnName("UId");

                entity.Property(e => e.Uaddress)
                    .HasColumnName("UAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.Umail)
                    .IsRequired()
                    .HasColumnName("UMail")
                    .HasMaxLength(50);

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasColumnName("UName")
                    .HasMaxLength(50);

                entity.Property(e => e.Upassword)
                    .IsRequired()
                    .HasColumnName("UPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.UphoneNo)
                    .HasColumnName("UPhoneNo")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
