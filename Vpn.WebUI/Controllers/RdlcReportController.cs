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
        public RdlcReportController()
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet]
        [Route("RegistryVpn/{hoTen}/{chucVu}/{ungDung}/{email}/{donVi}/{macAddress}/{dienThoai}/{batDau}")]
        public IActionResult RegistryVpn( string hoTen, string chucVu,  string ungDung, string email, string donVi,  string macAddress, string dienThoai, string batDau )
        //public IActionResult RegistryVpn()
        //public IActionResult RegistryVpn([FromBody] VpnDto vpn)
        {

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

            //var parameters = new[]
            //{
            //    new ReportParameter ( "HoTen", vpn.HoTen ),
            //    new ReportParameter( "ChucVu", vpn.ChucVu ),
            //    new ReportParameter( "UngDung", vpn.UngDung ),
            //    new ReportParameter ("Email", vpn.Email ),
            //    new ReportParameter ("DonVi", vpn.DonVi ),
            //    new ReportParameter ("MacAddress", vpn.MacAddress ),
            //    new ReportParameter ("DienThoai",vpn.DienThoai ),
            //    new ReportParameter ("BatDau",$"Từ {vpn.BatDau.ToShortDateString()} đến {vpn.BatDau.AddMonths(vpn.SoThang).ToShortDateString()}")
            //};


            using var report = new LocalReport();
            var renderFormat = "PDF";
            string extension = "pdf";
            var mimeType = "application/pdf";
            Reports.Report.Load(report, parameters);
            var pdf = report.Render(renderFormat);
            //return Ok(pdf);
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
