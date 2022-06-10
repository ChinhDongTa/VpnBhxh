using System.ComponentModel.DataAnnotations;

namespace Vpn.WebUI.Data
{
    public class VpnDto
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public int StaffId { get; set; }
        [Required]
        public string? HoTen { get; set; }
        /// <summary>
        /// Email công vụ
        /// </summary>
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        /// <summary>
        /// Chức vụ
        /// </summary>
        public string? ChucVu { get; set; }
        /// <summary>
        /// Đon vị công tác
        /// </summary>
        public string? DonVi { get; set; }
        /// <summary>
        /// Điện thoại
        /// </summary>
        public string? DienThoai { get; set; }
        /// <summary>
        /// Địa chỉ Mac card mạng
        /// </summary>
        [Required]
        public string? MacAddress { get; set; }
        /// <summary>
        /// Các ứng dụng đăng ký để đăng nhập = VPN. Các tên dc viết tắt : tst, tcs,...
        /// </summary>
        [Required]
        public string? UngDung { get; set; }
        /// <summary>
        /// Số tháng đăng ký sử dụng VPN
        /// </summary>
        [Required]
        [Range(1, 6)]
        public int SoThang { get; set; }
        /// <summary>
        /// Thời gian bắt đầu có hiệu lực sử dụng VPN
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime BatDau { get; set; }
    }
}
