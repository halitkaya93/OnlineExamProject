using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineExamProject.Models
{
    public partial class DBEXAMContext : DbContext
    {
        public DBEXAMContext()
        {
        }

        public DBEXAMContext(DbContextOptions<DBEXAMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblSetexam> TblSetexam { get; set; }
        public virtual DbSet<TblStudent> TblStudent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LENOVO\\SQLEXPRESS01;Database=DBEXAM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__QUESTION__30BE07AD6F050FA4");

                entity.ToTable("QUESTIONS");

                entity.HasIndex(e => e.Cop)
                    .HasName("UQ__QUESTION__C1FF6E9C4ADBC251")
                    .IsUnique();

                entity.HasIndex(e => e.Opa)
                    .HasName("UQ__QUESTION__CB39639BF7FE0573")
                    .IsUnique();

                entity.HasIndex(e => e.Opb)
                    .HasName("UQ__QUESTION__CB3963988D217544")
                    .IsUnique();

                entity.HasIndex(e => e.Opc)
                    .HasName("UQ__QUESTION__CB396399682B8516")
                    .IsUnique();

                entity.HasIndex(e => e.Opd)
                    .HasName("UQ__QUESTION__CB39639EDA80966B")
                    .IsUnique();

                entity.Property(e => e.QuestionId).HasColumnName("QUESTION_ID");

                entity.Property(e => e.Cop)
                    .IsRequired()
                    .HasColumnName("COP")
                    .HasMaxLength(20);

                entity.Property(e => e.Opa)
                    .IsRequired()
                    .HasColumnName("OPA")
                    .HasMaxLength(20);

                entity.Property(e => e.Opb)
                    .IsRequired()
                    .HasColumnName("OPB")
                    .HasMaxLength(20);

                entity.Property(e => e.Opc)
                    .IsRequired()
                    .HasColumnName("OPC")
                    .HasMaxLength(20);

                entity.Property(e => e.Opd)
                    .IsRequired()
                    .HasColumnName("OPD")
                    .HasMaxLength(20);

                entity.Property(e => e.QText)
                    .IsRequired()
                    .HasColumnName("Q_TEXT");
            });

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__TBL_ADMI__B5B611FB4EB7BE2D");

                entity.ToTable("TBL_ADMIN");

                entity.HasIndex(e => e.AdName)
                    .HasName("UQ__TBL_ADMI__C07C26433E0E465B")
                    .IsUnique();

                entity.Property(e => e.AdId).HasColumnName("AD_ID");

                entity.Property(e => e.AdName)
                    .IsRequired()
                    .HasColumnName("AD_NAME")
                    .HasMaxLength(20);

                entity.Property(e => e.AdPassword)
                    .IsRequired()
                    .HasColumnName("AD_PASSWORD")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblSetexam>(entity =>
            {
                entity.HasKey(e => e.ExamId)
                    .HasName("PK__TBL_SETE__2A3D8F88EE77F4B7");

                entity.ToTable("TBL_SETEXAM");

                entity.Property(e => e.ExamId).HasColumnName("EXAM_ID");

                entity.Property(e => e.ExamDate)
                    .HasColumnName("EXAM_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExamFkStu).HasColumnName("EXAM_FK_STU");

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasColumnName("EXAM_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.ExamStdScore).HasColumnName("EXAM_STD_SCORE");

                entity.HasOne(d => d.ExamFkStuNavigation)
                    .WithMany(p => p.TblSetexam)
                    .HasForeignKey(d => d.ExamFkStu)
                    .HasConstraintName("FK__TBL_SETEX__EXAM___5629CD9C");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__TBL_STUD__A3DFF16DA5DA86C6");

                entity.ToTable("TBL_STUDENT");

                entity.HasIndex(e => e.SName)
                    .HasName("UQ__TBL_STUD__8ADDC2070646920F")
                    .IsUnique();

                entity.Property(e => e.SId).HasColumnName("S_ID");

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("S_NAME")
                    .HasMaxLength(20);

                entity.Property(e => e.SPassword)
                    .IsRequired()
                    .HasColumnName("S_PASSWORD")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
