using AKSoft.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AKSoft.Reports
{
    public partial class Report1 : System.Web.UI.Page
    {
        public TopSoft db = new TopSoft();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                var rs = db.RptSales.OrderByDescending(a => a.HSalesCode).Select(a => a.HSalesCode).First();
                GetReport(Convert.ToInt32(rs));
            }
        }
        private void GetReport(int Invo)
        {
            var r = (from a in db.Re()
                     select a);
            ReportDataSource rd = new ReportDataSource("DataSet2", r.OrderByDescending(g => g.HSalesCode).Where(g => g.HSalesCode == Invo).ToList());
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sales/SaveInvoiceSales"); 


        }


    }
}