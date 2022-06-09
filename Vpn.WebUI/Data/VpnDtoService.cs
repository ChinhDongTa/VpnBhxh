using VpnDomain;
using VpnDomain.Models;

namespace Vpn.WebUI.Data
{
    public interface IVpnDtoService
    {
        public IEnumerable<VpnDto> GetFromStaff(IEnumerable<NhanVien> staffs);
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
        IVpnBhxhRepo vpnRepo = new VpnBhxhRepo();

        public IEnumerable<VpnDto> GetFromStaff(IEnumerable<NhanVien> staffs)
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
                UngDung = "tst, tcs"
            };
        }

        public async Task<IEnumerable<VpnDto>> GetFromStaff()
        {
            return GetFromStaff(await vpnRepo.GetStaffs());
        }

        public async Task RegisterAndDownLoadFile(VpnDto vpn)
        {
            //Ghi vào table VpnBhxh
            var vpnBhxh = new VpnBhxh() { Apps = vpn.UngDung, BeginDate = vpn.BatDau, NumMonth = (byte)vpn.SoThang, StaffId = vpn.StaffId, };
            await vpnRepo.Save(vpnBhxh);
            //Update Email, Sô điên thoại vào table NhanVien
            //await vpnRepo.UpdateStaff(vpn.StaffId, vpn.Email, vpn.DienThoai);

            //Tải file cam kết sử dụng vpn



            //return Task.CompletedTask;
        }
    }
}
