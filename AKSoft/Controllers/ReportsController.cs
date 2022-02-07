using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class ReportsController : Controller
{
    string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";

    // GET: Reports
    public ActionResult SupplierAccount()
    {
        return View();
    }
    public ActionResult StocksState()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select StoreName, ItemName, StoreKeeper from StoreState", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult ProfitofItems()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select HPurchase.ItemSerial ,(hp.t-(max(HPurchase.Price) * hp.q))t from HPurchase left join (select itemSerial,sum(hsales.total)t ,sum(hsales.Quantity) q from hsales group by hsales.ItemSerial)hp on hp.ItemSerial=HPurchase.ItemSerial group by HPurchase.ItemSerial,HPurchase.Price , hp.q,hp.t", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult ItemsBalance()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select ArabicName,sum(Q1-Q2)Balance from ItemCode left join (select ItemSerial,sum(Quantity) Q1 from hpurchase group by ItemSerial) HPurchas on HPurchas.ItemSerial=ItemCode.Serial  left join (select ItemSerial,sum(Quantity) Q2 from hsales group by ItemSerial)HSale on HSale.ItemSerial=ItemCode.Serial group by ArabicName", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult ItemsState()
    {
        return View();
    }
    [HttpGet]
    public ActionResult DailySales()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT ItCode,ItemName,StCode,StoreName,UnitName,Quantity,InPrice,Total from RptSales", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }
    public ActionResult DailyPurchases()
    {
        DataTable dt = new DataTable();
        using(SqlConnection sqlCon=new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select StoreCode.ArabicName Store,ItemCode.ArabicName,UnitCode.ArabicName Unit,(hpurchase.Quantity) Q,Price, sum(Total)  from ItemCode left join HPurchase on HPurchase.ItemSerial =ItemCode.Serial left join UnitCode on UnitCode.Serial =ItemCode.Unit1 left join StoreCode on StoreCode.Serial =ItemCode.StoreID group by ItemCode.ArabicName,price,StoreCode.ArabicName,UnitCode.ArabicName,hpurchase.Quantity", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult CustomersData()
    {
        return View();
    }
    public ActionResult CustomerAccount()
    {
        return View();
    }
}
