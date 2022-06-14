using Microsoft.AspNetCore.Components;

namespace Vpn.WebUI.Data
{
    public interface IDownLoadService
    {
        public void Export(string actionName, IEnumerable<KeyValuePair<string, string>> pairs);
        
        public void Export(string actionName, VpnDto vpnDto);
    }

    public class DownLoadService : IDownLoadService
    {
        private readonly NavigationManager navigationManager;
        private const string apiBasse = "/api/RdlcReport";
        public DownLoadService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        /// <summary>
        /// Xuất dữ liệu ra file Excel / CSV. Hiện tại chỉ làm excel vì CSV nhìn ko rõ với nhiều cột và hàng
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="type">2 gia trị Excel/CSV</param>
        /// <param name="pairs"></param>
        public void Export(string actionName, IEnumerable<KeyValuePair<string, string>> pairs)
        {
            //https://localhost:7170/api/exporthgd/DsBhytXa/24042/false
            string url = $"{apiBasse}/{actionName}/";
            if (pairs != null && pairs.Any())
            {
                // url = $"{apiBasse}/{actionName}/";
                foreach (var item in pairs)
                {
                    url += $"{item.Value}/";
                }
            }
            navigationManager.NavigateTo(url, true);
        }

        public void Export(string actionName, VpnDto vpnDto)
        {
            Export(actionName, VpnDtoTo(vpnDto));
        }

        /// <summary>
        /// Tham số cho RdlcReport chỉ cần <string, string> 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<KeyValuePair<string, string>> VpnDtoTo(VpnDto vpn)
        {
            var pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("HoTen", vpn.HoTen));
            pairs.Add(new KeyValuePair<string, string>("ChucVu", vpn.ChucVu));
            pairs.Add(new KeyValuePair<string, string>("UngDung", vpn.UngDung));
            pairs.Add(new KeyValuePair<string, string>("Email", vpn.Email));
            pairs.Add(new KeyValuePair<string, string>("DonVi", vpn.DonVi));
            pairs.Add(new KeyValuePair<string, string>("MacAddress", vpn.MacAddress));
            pairs.Add(new KeyValuePair<string, string>("DienThoai", vpn.DienThoai));
            pairs.Add(new KeyValuePair<string, string>("BatDau", Common.FormatDate2BatDau(vpn.BatDau.Value, vpn.SoThang)));
            return pairs;
        }
    }
}