using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Allocation.Models;

namespace Allocation.Models
{
    public partial class remnz1Context : DbContext
    {
        public remnz1Context()
        {
        }

        public remnz1Context(DbContextOptions<remnz1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpSkill> EmpSkill { get; set; }
        public virtual DbSet<EmpSubSkill> EmpSubSkill { get; set; }
        public virtual DbSet<EmpUser> EmpUser { get; set; }
        public virtual DbSet<FoClient> FoClient { get; set; }
        public virtual DbSet<FoSkill> FoSkill { get; set; }
        public virtual DbSet<FoSubSkill> FoSubSkill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:remnz1.database.windows.net,1433;Initial Catalog=remnz1;Persist Security Info=False;User ID=remnz;Password=Scarface123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpSkill>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ClientId, e.SkillId })
                    .HasName("EMP_SKILL_pk")
                    .IsClustered(false);

                entity.ToTable("EMP_SKILL");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.EmpSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_SKILL_FO_CLIENT_ID_fk");

                entity.HasOne(d => d.FoSkill)
                    .WithMany(p => p.EmpSkill)
                    .HasForeignKey(d => new { d.SkillId, d.ClientId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_SKILL_FO_SKILL_ID_CLIENT_ID_fk");

                entity.HasOne(d => d.EmpUser)
                    .WithMany(p => p.EmpSkill)
                    .HasForeignKey(d => new { d.UserId, d.ClientId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_SKILL_EMP_USER_ID_CLIENT_ID_fk");
            });

 

            modelBuilder.Entity<EmpSubSkill>(entity =>
            {
                entity.HasKey(e => new { e.SubSkillId, e.ClientId, e.UserId })
                    .HasName("EMP_SUB_SKILL_pk")
                    .IsClustered(false);

                entity.ToTable("EMP_SUB_SKILL");

                entity.Property(e => e.SubSkillId).HasColumnName("SUB_SKILL_ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.EmpSubSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_SUB_SKILL_FO_CLIENT_ID_fk");

                entity.HasOne(d => d.FoSubSkill)
                    .WithMany(p => p.EmpSubSkill)

                    .HasForeignKey(d => new { d.SubSkillId, d.ClientId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_SUB_SKILL_FO_SUB_SKILL_ID_CLIENT_ID_fk");

                entity.HasOne(d => d.EmpUser)
                    .WithMany(p => p.EmpSubSkill)
                    .HasForeignKey(d => new { d.UserId, d.ClientId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_SUB_SKILL_EMP_USER_ID_CLIENT_ID_fk");
            });

            modelBuilder.Entity<EmpUser>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClientId })
                    .HasName("EMP_USER_pk")
                    .IsClustered(false);

                entity.ToTable("EMP_USER");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("HIRE_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.JobTitle)
                    .HasColumnName("JOB_TITLE")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasColumnName("NICKNAME")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrgUnit)
                    .HasColumnName("ORG_UNIT")
                    .HasMaxLength(64)
                    .IsUnicode(false);
               
                entity.Property(e => e.Password)
                   .HasColumnName("PASSWORD")
                   .HasMaxLength(45)
                   .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.TAllocation).HasColumnName("T_ALLOCATION");

                entity.Property(e => e.TerminationDate)
                    .HasColumnName("TERMINATION_DATE")
                    .HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.EmpUser)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_USER_FO_CLIENT_ID_fk");
            });

            modelBuilder.Entity<FoClient>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("FO_CLIENT_pk")
                    .IsClustered(false);

                entity.ToTable("FO_CLIENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AutoId).HasColumnName("AUTO_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FoSkill>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClientId })
                    .HasName("FO_SKILL_pk")
                    .IsClustered(false);

                entity.ToTable("FO_SKILL");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FoSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FO_SKILL_FO_CLIENT_ID_fk");
            });
           

            modelBuilder.Entity<FoSubSkill>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ClientId })
                    .HasName("FO_SUB_SKILL_pk")
                    .IsClustered(false);

                entity.ToTable("FO_SUB_SKILL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");

                entity.HasOne(d => d.FoSkill)
                    .WithMany(p => p.FoSubSkill)
                    .HasForeignKey(d => new { d.SkillId, d.ClientId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FO_SUB_SKILL_FO_SKILL_ID_CLIENT_ID_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        
    }
}
