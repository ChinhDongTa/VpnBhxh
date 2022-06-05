using Microsoft.Reporting.NETCore;
using System.Reflection;

namespace Vpn.WebUI.Reports
{
    class Report
    {
		public static void Load(LocalReport report, ReportParameter[] parameters)
		{
			//var items = new[] { new ReportItem { Description = "Widget 6000", Price = widgetPrice, Qty = 1 }, new ReportItem { Description = "Gizmo MAX", Price = gizmoPrice, Qty = 25 } };
			//var parameters = new[] { new ReportParameter("Title", "Invoice 4/2020") };
			using var rs = Assembly.GetExecutingAssembly().GetManifestResourceStream("Vpn.WebUI.Reports.Report.rdlc");
			report.LoadReportDefinition(rs);
			//report.DataSources.Add(new ReportDataSource("Items", items));
			report.SetParameters(parameters);
		}
	}
}
