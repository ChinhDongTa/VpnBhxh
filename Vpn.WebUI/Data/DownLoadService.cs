using Microsoft.AspNetCore.Components;

namespace Vpn.WebUI.Data
{
    public interface IDownLoadService
    {
        public void Export(string actionName, IEnumerable<KeyValuePair<string, string>> pairs);
    }

    public class DownLoadService:IDownLoadService
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
            //url = "http://localhost:61949/api/RdlcReport/RegistryVpn/D%C6%AF%C6%A0NG%20TR%E1%BB%8CNG%20CH%C3%8DNH//tst,%20tcs/chinhdt@gialai.vss.gov.vn//fsdaf/0905146799/T%E1%BB%AB%2015-06-2022%20%C4%91%E1%BA%BFn%2015-07-2022/";
            navigationManager.NavigateTo(url, true);
        }
    }
}
