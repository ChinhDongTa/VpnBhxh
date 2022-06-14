namespace Vpn.WebUI.Data
{
    /// <summary>
    /// Lớp static dùng chung để ép kiểu,...
    /// </summary>
    public static class Common
    {
        public static string  FormatDate2BatDau(DateTime date, int numMonth)
        {
            return $"Từ {date.ToShortDateString()} đến {date.AddMonths(numMonth).ToShortDateString()}";
        }
    }
}