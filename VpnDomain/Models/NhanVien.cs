﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpnDomain.Models
{
    /// <summary>
    /// Lí lịch nhân viên
    /// </summary>
    public partial class NhanVien
    {
        public NhanVien()
        {
            VpnBhxh = new HashSet<VpnBhxh>();
        }

        public int NhanVienId { get; set; }
        public string MaNv { get; set; }
        public string HoTen { get; set; }
        public string BiDanh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Cmnd { get; set; }
        public DateTime Cmnddate { get; set; }
        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        public string Cmndplace { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string QueQuan { get; set; }
        public string QuocTich { get; set; }
        public int MaDanToc { get; set; }
        public int MaTonGiao { get; set; }
        public int MaTrinhDo { get; set; }
        public int MaNgach { get; set; }
        public DateTime? NgayVaoDoan { get; set; }
        public DateTime? NgayVaoDang { get; set; }
        public int MaLoaiTuyenDung { get; set; }
        public int MaPhongBan { get; set; }
        public int MaChucVu { get; set; }
        public bool HonNhan { get; set; }
        public bool NghiViec { get; set; }
        public int MaChuyenNganh { get; set; }
        public int MaNgachCoBan { get; set; }
        public DateTime? NgayVaoDangCt { get; set; }
        public DateTime? NgayBienChe { get; set; }
        public string SoSoBhxh { get; set; }
        public string SoTheBhyt { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public int SortOrder { get; set; }
        public string AccountNumber { get; set; }
        public int ItlevelId { get; set; }
        public int PtlevelId { get; set; }
        public string Weight { get; set; }
        public string Tall { get; set; }
        public string HealthStatus { get; set; }
        public string BloodGroup { get; set; }
        /// <summary>
        /// Công tác chính đang làm
        /// </summary>
        public string CurrentJob { get; set; }
        /// <summary>
        /// Sở trường công tác
        /// </summary>
        public string Forte { get; set; }
        /// <summary>
        /// Công việc làm lâu nhất
        /// </summary>
        public string LongestJob { get; set; }
        /// <summary>
        /// Công việc trước khi tuyển dụng
        /// </summary>
        public string JobBefore { get; set; }
        /// <summary>
        /// Gia đình thương binh, liệt sỹ
        /// </summary>
        public bool IsMartyrFamily { get; set; }
        /// <summary>
        /// Xuất thân gia đình
        /// </summary>
        public string DescendedFrom { get; set; }
        /// <summary>
        /// Ngày nhập ngũ
        /// </summary>
        public DateTime? EnlistmentDate { get; set; }
        /// <summary>
        /// Ngày xuất ngũ
        /// </summary>
        public DateTime? DemobilizeDate { get; set; }
        /// <summary>
        /// Quân hàm
        /// </summary>
        public string Rank { get; set; }
        /// <summary>
        /// Trình độ học vấn
        /// </summary>
        public string EducationalBackground { get; set; }
        /// <summary>
        /// Học vị cao nhất
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// Danh hiệu được phong tặng
        /// </summary>
        public string Title { get; set; }
        public string A28 { get; set; }
        public string B28 { get; set; }
        public string A29 { get; set; }
        public string B29 { get; set; }
        public string IncomeSalary { get; set; }
        public string IncomeOther { get; set; }
        public string HouseType { get; set; }
        /// <summary>
        /// Diện tích nhà ở
        /// </summary>
        public string HouseS { get; set; }
        /// <summary>
        /// Diện tích đất của tôi mua
        /// </summary>
        public string MyLandS { get; set; }
        /// <summary>
        /// Diện tích đất được cấp
        /// </summary>
        public string GrantedLandS { get; set; }
        public string ProductiveLand { get; set; }
        public DateTime InDate { get; set; }
        /// <summary>
        /// Cơ quan làm việc đầu tiên
        /// </summary>
        public string FirstOffice { get; set; }
        public DateTime? NgayCachMang { get; set; }

        public virtual PhongBan MaPhongBanNavigation { get; set; }
        public virtual ICollection<VpnBhxh> VpnBhxh { get; set; }
    }
}