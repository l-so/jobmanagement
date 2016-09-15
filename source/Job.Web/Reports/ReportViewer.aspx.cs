using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Job.WebMvc.ReportView
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DropDownList1.SelectedValue))
                LoadReport(this.DropDownList1.SelectedValue);
        }

        protected void LoadReport(string rptName)
        {
            if (string.IsNullOrWhiteSpace(rptName))
                throw new ArgumentNullException("Report non trovato!");
            string srvUrl = System.Configuration.ConfigurationManager.AppSettings["ReportServerUrl"];
            if (string.IsNullOrWhiteSpace(srvUrl))
                throw new ArgumentNullException("URL Reporting service non trovata!");
            string srvReportPath = System.Configuration.ConfigurationManager.AppSettings["ReportServerPath"];
            if (string.IsNullOrWhiteSpace(srvReportPath))
                srvReportPath = string.Empty;

            rptViewer.ShowParameterPrompts = true;
            rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            rptViewer.ServerReport.ReportServerUrl = new Uri(srvUrl);
            rptViewer.ServerReport.ReportPath = srvReportPath + string.Format("/{0}", rptName);
        }
    }
}