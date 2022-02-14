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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select ArabicName,Address,NumberOfLeans,StoreKeeper,AreaStock,Phone1 from StoreCode", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("select storecode.ArabicName,ItemCode.arabicname Name,UnitCode.ArabicName ,sum(s.a) from itemcode left join (select itemserial, sum(case when type =1 then (Quantity) else (Quantity)*-1  end) a from ( select ItemSerial,HPurchase.Quantity,1 as type from HPurchase union select ItemSerial,Quantity,0 as type from HSales ) ss group by ItemSerial)s on s.ItemSerial = itemcode.serial left join StoreCode on StoreCode.serial =ItemCode.StoreID left join UnitCode on UnitCode.serial =ItemCode.Unit1 group by Itemcode.ArabicName,storecode.ArabicName,UnitCode.ArabicName", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult ItemsState()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select distinct ItemName,StoreName,GroupName,UnitName from ItemCard", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
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
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select StoreName,ItemName,UnitName,HpurchaseQuantity,HpurchasePrice,HpurchaseTotal from RptPurchase", sqlCon);
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
