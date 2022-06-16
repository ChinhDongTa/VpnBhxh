using System.Net.NetworkInformation;
using VpnDomain;
using VpnDomain.Models;

namespace Vpn.WebUI.Data
{
    public interface IVpnDtoService
    {
        public IEnumerable<VpnDto> GetFromStaff(IQueryable<NhanVien> staffs);

        public Task<IEnumerable<VpnDto>> GetFromStaff();

        /// <summary>
        /// Lấy danh sách đang sử dụng Vpn => chuyển sang vpndto
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<VpnDto>> GetFromVpnBHXHInUse();

        /// <summary>
        /// Ghi danh VPN và tải file cam kết
        /// </summary>
        /// <param name="vpn"></param>
        /// <returns></returns>
        public Task RegisterAndDownLoadFile(VpnDto vpn);

        /// <summary>
        /// Lấy địa chỉ MAC client
        /// </summary>
        /// <returns></returns>
        public string GetMacAddress();
    }

    public class VpnDtoService : IVpnDtoService
    {
        private readonly IVpnBhxhRepo vpnRepo = new VpnBhxhRepo();
        readonly IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

        public IEnumerable<VpnDto> GetFromStaff(IQueryable<NhanVien> staffs)
        {
            IList<VpnDto> vpnDtoList = new List<VpnDto>();
            foreach (var staff in staffs)
            {
                vpnDtoList.Add(Staff2VpnDto(staff));
            }
            return vpnDtoList;
        }

        private  VpnDto Staff2VpnDto(NhanVien staff)
        {
            return new VpnDto()
            {
                StaffId = staff.NhanVienId,

                HoTen = staff.HoTen.ToUpper(),
                Email = staff.Email,
                DienThoai = staff.DienThoai,
                SoThang = 1,
                UngDung = "tst, tcs",
                ChucVu = staff.MaChucVuNavigation.Ten,
                DonVi = staff.MaPhongBanNavigation.TenVietTat
                //MacAddress=GetMacAddress(staff.NhanVienId) => ko nên lấy chỗ này tốn time rất nhiều
                //BatDau= DateTime.Now,
            };
        }

        public async Task<IEnumerable<VpnDto>> GetFromStaff()
        {
            return  GetFromStaff(vpnRepo.GetStaffs());
        }

        public async Task RegisterAndDownLoadFile(VpnDto vpn)
        {
            //Ghi vào table VpnBhxh
            var vpnBhxh = new VpnBhxh()
            {
                Apps = vpn.UngDung,
                BeginDate = vpn.BatDau.Value,
                NumMonth = (byte)vpn.SoThang,
                StaffId = vpn.StaffId,
                MacAdddress = vpn.MacAddress
            };
            await vpnRepo.Save(vpnBhxh);
            //Update Email, Sô điên thoại vào table NhanVien
            await vpnRepo.UpdateStaff(vpn.StaffId, vpn.Email, vpn.DienThoai);
        }

        public string GetMacAddress()
        {
            var ipAddress = httpContextAccessor.HttpContext.Connection?.RemoteIpAddress.MapToIPv4();
            if (ipAddress == null)
                return "ko tìm thấy MacAddress";
            else
            {
                var macAddress = NetworkTool.NetworkMacAddress.GetMacAddress(ipAddress);
                return InsertString(macAddress.ToString()) + ipAddress.ToString();
            }
        }

        private static string InsertString(string macAddress)
        {
            int next = 2;
            int count=macAddress.Length/2;//số lẻ là sai MacAddress 
            for (int i = 1; i < count; i++)
            {
                
                macAddress = macAddress.Insert(next, "-");
                next += 3;
            }
            return macAddress;
        }

        public async Task<IEnumerable<VpnDto>> GetFromVpnBHXHInUse()
        {
            var vpnBhxhs= await vpnRepo.GetInUse();
            var vpnDtos = new List<VpnDto>();
            foreach (var item in vpnBhxhs)
            {
                var dto = new VpnDto()
                {
                    StaffId = item.StaffId,
                    HoTen = item.Staff.HoTen,
                    BatDau =item.BeginDate,// cho ra 1 hàm static
                    Email=item.Staff.Email,
                    MacAddress = item.MacAdddress,
                    ChucVu = item.Staff.MaChucVuNavigation.Ten,
                    DonVi = item.Staff.MaPhongBanNavigation.TenVietTat,
                    UngDung=item.Apps,
                    DienThoai = item.Staff.DienThoai, 
                    SoThang=item.NumMonth
                };
                vpnDtos.Add(dto);
            }
            return vpnDtos;
        }
    }
}
