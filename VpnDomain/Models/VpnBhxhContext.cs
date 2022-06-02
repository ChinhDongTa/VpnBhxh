﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VpnDomain.Models
{
    public partial class VpnBhxhContext : DbContext
    {
        public VpnBhxhContext()
        {
        }

        public VpnBhxhContext(DbContextOptions<VpnBhxhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhongBan> PhongBan { get; set; }
        public virtual DbSet<VpnBhxh> VpnBhxh { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.64.208.250;Initial Catalog=ERP_BHXHGL;Persist Security Info=True;User ID=erp_bhxhgl;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasComment("Lí lịch nhân viên");

                entity.HasIndex(e => e.MaNv, "IX_NhanVien")
                    .IsUnique();

                entity.HasIndex(e => e.Cmnd, "IX_StaffResumes")
                    .IsUnique();

                entity.Property(e => e.NhanVienId).HasColumnName("NhanVienID");

                entity.Property(e => e.A28)
                    .HasMaxLength(100)
                    .HasColumnName("A_28");

                entity.Property(e => e.A29)
                    .HasMaxLength(100)
                    .HasColumnName("A_29");

                entity.Property(e => e.AccountNumber).HasMaxLength(20);

                entity.Property(e => e.B28)
                    .HasMaxLength(100)
                    .HasColumnName("B_28");

                entity.Property(e => e.B29)
                    .HasMaxLength(100)
                    .HasColumnName("B_29");

                entity.Property(e => e.BiDanh).HasMaxLength(50);

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasDefaultValueSql("(N'A')");

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CMND");

                entity.Property(e => e.Cmnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("CMNDDate");

                entity.Property(e => e.Cmndplace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CMNDPlace")
                    .HasComment("Nơi cấp CMND");

                entity.Property(e => e.CurrentJob)
                    .HasMaxLength(100)
                    .HasComment("Công tác chính đang làm");

                entity.Property(e => e.Degree)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasComment("Học vị cao nhất");

                entity.Property(e => e.DemobilizeDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày xuất ngũ");

                entity.Property(e => e.DescendedFrom)
                    .HasMaxLength(50)
                    .HasComment("Xuất thân gia đình");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DienThoai).HasMaxLength(30);

                entity.Property(e => e.EducationalBackground)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Trình độ học vấn");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EnlistmentDate)
                    .HasColumnType("datetime")
                    .HasComment("Ngày nhập ngũ");

                entity.Property(e => e.FirstOffice)
                    .HasMaxLength(150)
                    .HasComment("Cơ quan làm việc đầu tiên");

                entity.Property(e => e.Forte)
                    .HasMaxLength(100)
                    .HasComment("Sở trường công tác");

                entity.Property(e => e.GrantedLandS)
                    .HasMaxLength(10)
                    .HasColumnName("GrantedLand_S")
                    .HasComment("Diện tích đất được cấp");

                entity.Property(e => e.HealthStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HouseS)
                    .HasMaxLength(10)
                    .HasColumnName("House_S")
                    .HasComment("Diện tích nhà ở");

                entity.Property(e => e.HouseType).HasMaxLength(20);

                entity.Property(e => e.InDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(((1)/(1))/(1997))");

                entity.Property(e => e.IncomeOther).HasMaxLength(20);

                entity.Property(e => e.IncomeSalary)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsMartyrFamily).HasComment("Gia đình thương binh, liệt sỹ");

                entity.Property(e => e.ItlevelId).HasColumnName("ITLevelID");

                entity.Property(e => e.JobBefore)
                    .HasMaxLength(100)
                    .HasComment("Công việc trước khi tuyển dụng");

                entity.Property(e => e.LongestJob)
                    .HasMaxLength(100)
                    .HasComment("Công việc làm lâu nhất");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MyLandS)
                    .HasMaxLength(10)
                    .HasColumnName("MyLand_S")
                    .HasComment("Diện tích đất của tôi mua");

                entity.Property(e => e.NgayBienChe).HasColumnType("datetime");

                entity.Property(e => e.NgayCachMang).HasColumnType("datetime");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.NgayVaoDang).HasColumnType("date");

                entity.Property(e => e.NgayVaoDangCt)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayVaoDangCT");

                entity.Property(e => e.NgayVaoDoan).HasColumnType("date");

                entity.Property(e => e.NoiSinh)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductiveLand).HasMaxLength(100);

                entity.Property(e => e.PtlevelId).HasColumnName("PTLevelID");

                entity.Property(e => e.QueQuan)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.QuocTich)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rank)
                    .HasMaxLength(50)
                    .HasComment("Quân hàm");

                entity.Property(e => e.SoSoBhxh)
                    .HasMaxLength(23)
                    .HasColumnName("SoSoBHXH");

                entity.Property(e => e.SoTheBhyt)
                    .HasMaxLength(23)
                    .HasColumnName("SoTheBHYT");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((30))");

                entity.Property(e => e.Tall)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.Title)
                    .HasMaxLength(70)
                    .HasComment("Danh hiệu được phong tặng");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.HasOne(d => d.MaPhongBanNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaPhongBan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhanVien_PhongBan");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPhongBan);

                entity.Property(e => e.DienThoai).HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.IsActivity)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((100))");

                entity.Property(e => e.TenDayDu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenVietHoa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'BẢO HIỂM XÃ HỘI HUYỆN')");

                entity.Property(e => e.TenVietTat)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VpnBhxh>(entity =>
            {
                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.VpnBhxh)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VpnBhxh_NhanVien");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
