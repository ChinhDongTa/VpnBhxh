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
            if (pairs != null && pairs.Count() > 0)
            {
                // url = $"{apiBasse}/{actionName}/";
                foreach (var item in pairs)
                {
                    url += $"{item.Value}/";
                }
            }

            navigationManager.NavigateTo(url, true);
        }
    }
}
