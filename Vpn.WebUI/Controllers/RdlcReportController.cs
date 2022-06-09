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

        [HttpGet("{hoTen}/{chucVu}/{ungDung}/{email}/{donVi}/{macAddress}/{dienThoai}/{batDau}")]
        [Route("RegistryVpn")]
        public IActionResult RegistryVpn(string hoTen, string chucVu, string ungDung,string email, string donVi, string macAddress, string dienThoai, string batDau )
        //public IEnumerable<string> RegistryVpn()
        {
            //var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\RegistryVpn.rdlc";
            var parameters = new[]
            {
                new ReportParameter ( "HoTen", hoTen ),
                new ReportParameter( "ChucVu", chucVu ),
                new ReportParameter( "UngDung", ungDung ),
                new ReportParameter ("Email", email ),
                new ReportParameter ("DonVi", donVi ),
                new ReportParameter ("MacAddress", macAddress ),
                new ReportParameter ("DienThoai",dienThoai ),
                new ReportParameter ("BatDau", batDau )
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
