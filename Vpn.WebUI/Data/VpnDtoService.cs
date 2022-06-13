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
        /// Ghi danh VPN và tải file cam kết
        /// </summary>
        /// <param name="vpn"></param>
        /// <returns></returns>
        public Task RegisterAndDownLoadFile(VpnDto vpn);
    }

    public class VpnDtoService : IVpnDtoService
    {
        readonly IVpnBhxhRepo vpnRepo = new VpnBhxhRepo();

        public IEnumerable<VpnDto> GetFromStaff(IQueryable<NhanVien> staffs)
        {
            IList<VpnDto> vpnDtoList = new List<VpnDto>();
            foreach (var staff in staffs)
            {
                vpnDtoList.Add(Staff2VpnDto(staff));
            }
            return vpnDtoList;
        }

        private static VpnDto Staff2VpnDto(NhanVien staff)
        {
            return new VpnDto()
            {
                StaffId = staff.NhanVienId,

                HoTen = staff.HoTen.ToUpper(),
                Email = staff.Email,
                DienThoai = staff.DienThoai,
                SoThang = 1,
                UngDung = "tst, tcs",
                ChucVu = staff.MaChucVuNavigation.VietTat,
                DonVi = staff.MaPhongBanNavigation.TenVietTat,
                MacAddress=GetMacAddress(staff.NhanVienId)
                //BatDau= DateTime.Now,
            };
        }

        public async Task<IEnumerable<VpnDto>> GetFromStaff()
        {
            return GetFromStaff(vpnRepo.GetStaffs());
        }

        public async Task RegisterAndDownLoadFile(VpnDto vpn)
        {
            //Ghi vào table VpnBhxh
            var vpnBhxh = new VpnBhxh() { Apps = vpn.UngDung, BeginDate =  vpn.BatDau.Value, NumMonth = (byte)vpn.SoThang, StaffId = vpn.StaffId, };
            await vpnRepo.Save(vpnBhxh);
            //Update Email, Sô điên thoại vào table NhanVien
            await vpnRepo.UpdateStaff(vpn.StaffId, vpn.Email, vpn.DienThoai);
        }

        private static string GetMacAddress(int staffId)
        {
            if (staffId > 0)
            {
                var mac = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .Select(nic => nic.GetPhysicalAddress().ToString())
                    .FirstOrDefault();
                return InsertString(mac);
            }
            return string.Empty;
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
    }
}
