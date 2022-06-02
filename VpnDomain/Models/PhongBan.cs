﻿namespace VpnDomain.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public int MaPhongBan { get; set; }
        public string TenVietTat { get; set; }
        public string TenDayDu { get; set; }
        public string TenVietHoa { get; set; }
        public string DienThoai { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int MaDonViHanhChinh { get; set; }
        public int SortOrder { get; set; }
        public int Score { get; set; }
        public bool? IsActivity { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
