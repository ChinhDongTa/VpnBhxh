// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VpnDomain.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public int MaChucVu { get; set; }
        public string Ten { get; set; }
        public string VietTat { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}