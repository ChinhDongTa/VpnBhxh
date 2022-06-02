namespace VpnDomain.Models
{
    public partial class VpnBhxh
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public byte NumMonth { get; set; }
        public DateTime BeginDate { get; set; }
        public string Apps { get; set; }
        public string Note { get; set; }

        public virtual NhanVien Staff { get; set; }
    }
}
