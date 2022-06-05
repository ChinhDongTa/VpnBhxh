using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Text;
using Vpn.WebUI.Data;

namespace Vpn.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RdlcReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RdlcReportController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment=webHostEnvironment;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet]
        [Route("RegistryVpn")]
        public IActionResult RegistryVpn()
        //public IEnumerable<string> RegistryVpn()
        {
            VpnDto vpn = new VpnDto()
            {
                HoTen = "Duong Trong Chinh",
                Email = "a@a.c",
                MacAddress = "mac",
                BatDau = DateTime.Now,
                ChucVu = "ptppt",
                DonVi = "cntt",
                SoThang = 1
            };
            
            
            //var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\RegistryVpn.rdlc";
            var parameters = new[]
            {
                new ReportParameter ( "HoTen", vpn.HoTen ),
                new ReportParameter( "ChucVu", vpn.ChucVu ),
                new ReportParameter( "UngDung", vpn.UngDung ),
                new ReportParameter ("Email", vpn.Email ),
                new ReportParameter ("DonVi", vpn.DonVi ),
                new ReportParameter ("MacAddress", vpn.MacAddress ),
                new ReportParameter ("DienThoai", vpn.DienThoai ),
                new ReportParameter ("BatDau", $"Từ {vpn.BatDau.ToShortDateString()} đến {vpn.BatDau.AddMonths(vpn.SoThang).ToShortDateString()}" )
            };

            using var report = new LocalReport();
            var renderFormat = "PDF";
            string extension = "pdf";
            var mimeType = "application/pdf";
            Reports.Report.Load(report, parameters);
            var pdf = report.Render(renderFormat);
            return File(pdf, mimeType, "DangKyVpn." + extension);


            //var result = localReport.ExecuteReportInCurrentAppDomain(RenderType.Pdf, extension, parameters, mimetype);
            //return File(result.MainStream, "application/pdf");
            //return new string[] { "Registry Vpn", "Registry Vpn" };
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string GetId(int id)
        //{
        //    return $"value {id}";
        //}
    }
}
