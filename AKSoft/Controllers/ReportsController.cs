using AKSoft.Models;
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
    // Last Pruchase Price
    public ActionResult ItemLastPurchasePrice(HSales model,int? id)
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "2", "2");
        List<CustomerCode> list5 = db.CustomerCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName", 1);
        List<DealerCode> list6 = db.DealerCode.ToList();
        HSales invo = new HSales();
        DataTable dt = new DataTable(); 
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {

            var i =0;
            sqlCon.Open();
            string query = "SELECT ItemCode from rptsales Where ItemCode = 3";
            SqlDataAdapter sqlDa2 = new SqlDataAdapter(query, sqlCon);
            sqlDa2.SelectCommand.Parameters.AddWithValue("@Serial", i);
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT R1.ItemName,UnitName,R1.HpurchasePrice,HpurchaseDate FROM RptPurchase R1 INNER JOIN (SELECT ItemCode, MAX(Hpurchasedate) AS MaxDateTime FROM RptPurchase GROUP BY ItemCode) groupR2  ON R1.ItemCode = groupR2.ItemCode  AND R1.Hpurchasedate = groupR2.MaxDateTime", sqlCon);
            sqlDa.Fill(dt);

            return View(dt);
        }
    }
    // Last Sales Price
    public ActionResult ItemLastSalesPrice()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT R1.ItemName,UnitName,R1.HSalesPrice,HSalesDate FROM RptSales R1 INNER JOIN (SELECT ItemCode, MAX(HSalesdate) AS MaxDateTime FROM RptSales GROUP BY ItemCode) groupR2  ON R1.ItemCode = groupR2.ItemCode  AND R1.HSalesdate = groupR2.MaxDateTime", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult SupplierAccount()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select SupplierCode,SupplierName,0 Debit,0 Credit,sum(HpurchaseTotal)ToatalPurchase from RptPurchase group by SupplierName,SupplierCode", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    // Items BestSeller
    public ActionResult ItemsBestSeller()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select ItemCode,ItemName,StoreName,UnitName,Sum(HsalesTotal) Total from rptsales group by ItemCode,ItemName,StoreName,UnitName order by Total desc", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult DealerAccount()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select DealerCode,DealerName,0 Debit,0 Credit,sum(HsalesTotal)ToatalSales from RptSales group by DealerName,DealerCode", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult UsersData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select UserId,FirstName,MiddleName,LastName,Email,RoleName,BranchName,SectorName from RptUsers", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult SupplierData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select SupplierCode,SupplierName,SupplierEname,SupplierAddress1,SupplierTel1,SupplierTel2,CountryName,TownName,Email from RptSuppliers", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult DealerData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select DealerCode,DealerName,DealerEname,DealerAddress1,DealerTel1,DealerTel2,CountryName,TownName,Email from RptDealers", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
   // Start Employee Show Data
    public ActionResult EmployeesData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select EmployeeCode,EmployeeName,EmployeeEname,EmployeeAddress1,EmployeeTel1,EmployeeTel2,CountryName,TownName,Email from RptEmployees", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    // End Employee Data
    public ActionResult StocksState()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select StoreCode2,StoreName,StoreAddress,EmployeeName,StoreArea,StorePhone1 from RptStore", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("select ItemCode.Code ItemCode ,ItemCode.ArabicName,(hp.t-(max(HPurchase.Price) * hp.q))t from HPurchase left join ItemCode on ItemCode.Serial=HPurchase.ItemSerial left join (select itemSerial,sum(hsales.total)t ,sum(hsales.Quantity) q from hsales group by hsales.ItemSerial)hp on hp.ItemSerial=HPurchase.ItemSerial group by ItemCode.Code,HPurchase.Price , hp.q,hp.t,ItemCode.ArabicName", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("select StoreName,ItemName,GroupName,UnitName,Balance from RptItemBalance", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("select distinct ItemName,GroupName,UnitName from ItemCard", sqlCon);
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

            SqlDataAdapter sqlDa = new SqlDataAdapter("select hsalesCode,ItemName,StoreName,UnitName,CustomerName,HsalesQuantity,HsalesPrice,(HsalesQuantity*HsalesPrice) from RptSales", sqlCon);
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("select StoreName,ItemName,UnitName,SupplierName,HpurchaseQuantity,HpurchasePrice,(HpurchaseQuantity*HpurchasePrice) from RptPurchase", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult CustomersData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select CustomerCode,CustomerName,CustomerEname,CustomerAddress1,CustomerTel1,CustomerTel2,CountryName,TownName,Email from RptCustomers", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
    public ActionResult CustomerAccount()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select CustomerCode,CustomerName,0 Debit,0 Credit,sum(HsalesTotal)TotalSales from RptSales group by CustomerName,CustomerCode", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
}
