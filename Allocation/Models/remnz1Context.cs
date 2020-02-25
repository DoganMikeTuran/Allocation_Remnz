using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<FoClient> FoClient { get; set; }
        public virtual DbSet<FoRole> FoRole { get; set; }
        public virtual DbSet<FoRoleSubSkill> FoRoleSubSkill { get; set; }
        public virtual DbSet<FoSkill> FoSkill { get; set; }
        public virtual DbSet<FoSubSkill> FoSubSkill { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserSubSkill> UserSubSkill { get; set; }
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
           

            modelBuilder.Entity<FoClient>(entity =>
            {
                entity.ToTable("FO_CLIENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(32)
                    .IsFixedLength();
            });

            modelBuilder.Entity<FoRole>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Id });

                entity.ToTable("FO_ROLE");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FoRole)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_ROLE_FO_CLIENT");
            });

            modelBuilder.Entity<FoRoleSubSkill>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.RoleId, e.SubSkillId });

                entity.ToTable("FO_ROLE_SUB_SKILL");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.SubSkillId).HasColumnName("SUB_SKILL_ID");

                entity.Property(e => e.Proficiency)
                    .HasColumnName("PROFICIENCY")
                    .HasDefaultValueSql("((100))");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FoRoleSubSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_ROLE_SUB_SKILL_FO_CLIENT");

                entity.HasOne(d => d.FoRole)
                    .WithMany(p => p.FoRoleSubSkill)
                    .HasForeignKey(d => new { d.ClientId, d.RoleId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_ROLE_SUB_SKILL_FO_ROLE");

                entity.HasOne(d => d.FoSubSkill)
                    .WithMany(p => p.FoRoleSubSkill)
                    .HasForeignKey(d => new { d.ClientId, d.SubSkillId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_ROLE_SUB_SKILL_FO_SUB_SKILL");
            });

            modelBuilder.Entity<FoSkill>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Id });

                entity.ToTable("FO_SKILL");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FoSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_SKILL_FO_CLIENT");
            });

            modelBuilder.Entity<FoSubSkill>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Id });

                entity.ToTable("FO_SUB_SKILL");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdealProficiency).HasColumnName("IDEAL_PROFICIENCY");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.FoSubSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_SUB_SKILL_FO_CLIENT");

                entity.HasOne(d => d.FoSkill)
                    .WithMany(p => p.FoSubSkill)
                    .HasForeignKey(d => new { d.ClientId, d.SkillId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FO_SUB_SKILL_FO_SKILL");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.Id });

                entity.ToTable("USER");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_FO_CLIENT");
            });

            modelBuilder.Entity<UserSubSkill>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.UserId, e.SubSkillId });

                entity.ToTable("USER_SUB_SKILL");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.SubSkillId).HasColumnName("SUB_SKILL_ID");

                entity.Property(e => e.Proficiency).HasColumnName("PROFICIENCY");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.UserSubSkill)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_SUB_SKILL_FO_CLIENT");

                entity.HasOne(d => d.FoSubSkill)
                    .WithMany(p => p.UserSubSkill)
                    .HasForeignKey(d => new { d.ClientId, d.SubSkillId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_SUB_SKILL_FO_SUB_SKILL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubSkill)
                    .HasForeignKey(d => new { d.ClientId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_SUB_SKILL_USER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
