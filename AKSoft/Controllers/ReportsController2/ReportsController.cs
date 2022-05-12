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

    // GET: Reports
    TopSoft entities;

    public ReportsController()
        {
            entities = new TopSoft();
        }
            [HttpPost]
    public ActionResult go(string i)
    {
      return View(entities.ItemCode.Where(x =>x.ArabicName.StartsWith(i)|| i ==null).ToList());
    }
  
    public ActionResult ItemLastPurchasePrice(string i)
    {
        return View(entities.ItemCode.Where(x => x.ArabicName.StartsWith(i) || i == null).ToList());
    }
    // Last Sales Price
    public ActionResult ItemLastSalesPrice(string i)
    {
        return View(entities.ItemCode.Where(x => x.ArabicName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult SupplierAccount(string i)
    {
        return View(entities.ItemCode.Where(x => x.ArabicName.StartsWith(i) || i == null).ToList());
    }
    // Items BestSeller
    public ActionResult ItemsBestSeller(string i)
    {
        return View(entities.ItemCode.Where(x => x.ArabicName.StartsWith(i) || i == null).ToList());
    }
    /*
    public ActionResult DealerAccount(string i)
    {
        TopSoft entities = new TopSoft();
        return View(entities.DealerAccount.Where(x => x.ArabicName.StartsWith(i) || i == null).ToList());
    }
     */
    public ActionResult UsersData(string i)
    {
        return View(entities.UsersData.Where(x => x.FirstName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult ItemsState(string i)
    {
        return View(entities.ItemCard.Where(x => x.ItemName.StartsWith(i) || i == null).ToList());
    }
    /*
    public ActionResult SupplierData(string i)
    {
        return View(entities.SupplierData.Where(x => x.SupplierName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult DealerData(string i)
    {
        TopSoft entities = new TopSoft();
        return View(entities.DealerData.Where(x => x.DealerName.StartsWith(i) || i == null).ToList());
    }
   // Start Employee Show Data
    public ActionResult EmployeesData(string i)
    {
        return View(entities.EmployeesData.Where(x => x.EmployeeName.StartsWith(i) || i == null).ToList());
    }
    // End Employee Data
    public ActionResult StocksState(string i)
    {
        return View(entities.StocksState.Where(x => x.StoreName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult ProfitofItems(string i)
    {
        return View(entities.ProfitofItems.Where(x => x.ArabicName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult ItemsBalance(string i)
    {
        TopSoft entities = new TopSoft();
        return View(entities.ItemsBalanc.Where(x => x.ItemName.StartsWith(i) || i == null).ToList());
    }
    
    [HttpGet]
    public ActionResult DailySales(string i)
    {
        return View(entities.DailySales.Where(x => x.ItemName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult DailyPurchases(string i)
    {
        return View(entities.DailyPurchases.Where(x => x.ItemName.StartsWith(i) || i == null).ToList());
    }
    public ActionResult CustomersData(string i)
    {
        return View(entities.CustomerData.Where(x => x.CustomerName.StartsWith(i) || i == null).ToList());
    } 
     public ActionResult CustomerAccount(string i)
    {
        return View(entities.CustomerAccount.Where(x => x.CustomerName.StartsWith(i) || i == null).ToList());
    }
    /*
    public ActionResult CustomerAccount()
    {
        DataTable dt = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select CustomerCode,i,0 Debit,0 Credit,sum(HsalesTotal)TotalSales from RptSales group by i,CustomerCode", sqlCon);
            sqlDa.Fill(dt);
        }
        return View(dt);
    }
     * */
    //    string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";


}
