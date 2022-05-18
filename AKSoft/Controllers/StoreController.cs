using AKSoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace AKSoft.Controllers
{
    public class StoreController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult SaveStock()
        {
            ViewBag.MaxCode = objContext.StoreCode.Max(x => x.Code) + 1;
            List<CountryCode> list1 = objContext.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
            List<TownCode> list2 = objContext.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
            List<Employee> list3 = objContext.Employee.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
            return View();

        }
        [HttpPost]

        public ActionResult SaveStock(StoreCode model)
        {
            try
            {
                TopSoft db = new TopSoft();
                StoreCode stock = new StoreCode();
                stock.ArabicName = model.ArabicName;
                stock.Address = model.Address;
                stock.AreaStock = model.AreaStock;
                stock.Code = model.Code;
                stock.Phone1 = model.Phone1;
                stock.Phone2 = model.Phone2;
                stock.Phone3 = model.Phone3;
                stock.Phone4 = model.Phone4;
                stock.Description = model.Description;
                stock.EmployeeSerial = model.EmployeeSerial;
                stock.TownSerial = model.TownSerial;
                stock.CountrySerial = model.CountrySerial;
                db.StoreCode.Add(stock);
                db.SaveChanges();
                int latestEmpId = stock.Serial;
                TempData["Al"] = stock.ArabicName;
                return RedirectToAction("SaveStock");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
        [HttpGet]
        public ActionResult DisplayStocks()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,Code,ArabicName,Description,[Address],[EmployeeSerial],[CountrySerial],TownSerial,[Phone1],[Phone2],[Phone3],AreaStock FROM StoreCode ", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);

        }
        // Stock Edit
        public ActionResult EditStock(int? id)
        {
            TopSoft db = new TopSoft();
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
            List<TownCode> list2 = db.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
            List<Employee> list3 = db.Employee.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
            StoreCode productModel = new StoreCode();
            DataTable dtblProduct = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {

                    sqlCon.Open();
                    string query = "SELECT Serial,Code,ArabicName,Description,[Address],EmployeeSerial,CountrySerial,TownSerial,[Phone1],[Phone2],[Phone3],AreaStock FROM StoreCode Where Serial =@Serial";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
                    sqlDa.Fill(dtblProduct);
                }

                if (dtblProduct.Rows.Count == 1)
                {
                    productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                    productModel.Code = Convert.ToInt32(dtblProduct.Rows[0][1].ToString());
                    productModel.ArabicName = dtblProduct.Rows[0][2].ToString();
                    productModel.Description = dtblProduct.Rows[0][3].ToString();
                    productModel.Address = dtblProduct.Rows[0][4].ToString();
                    productModel.EmployeeSerial = Convert.ToInt32(dtblProduct.Rows[0][5].ToString());
                    productModel.CountrySerial = Convert.ToInt32(dtblProduct.Rows[0][6].ToString());
                    productModel.TownSerial = Convert.ToInt32(dtblProduct.Rows[0][7].ToString());
                    productModel.Phone1 = dtblProduct.Rows[0][8].ToString();
                    productModel.Phone2 = dtblProduct.Rows[0][9].ToString();
                    productModel.Phone3 = dtblProduct.Rows[0][10].ToString();
                    productModel.AreaStock = dtblProduct.Rows[0][11].ToString();
                    TempData["As"] = "";
                    return View(productModel);

                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayStocks");


        }
        //
        // POST: /Product/Edit/5
        [HttpPost]

        public ActionResult EditStock(StoreCode productModel)
        {
            TopSoft db = new TopSoft();
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
            List<TownCode> list2 = db.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
            List<Employee> list3 = db.Employee.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE StoreCode SET Code=@Code,ArabicName = @ArabicName ,Description=@Description ,Address=@Address,EmployeeSerial=@EmployeeSerial,CountrySerial=@CountrySerial,TownSerial=@TownSerial, Phone1=@Phone1,Phone2=@Phone2, Phone3=@Phone3,AreaStock=@AreaStock  Where Serial =@Serial";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Serial", productModel.Serial);
                    sqlCmd.Parameters.AddWithValue("@Code", productModel.Code);
                    sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                    sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
                    sqlCmd.Parameters.AddWithValue("@Address", productModel.Address);
                    sqlCmd.Parameters.AddWithValue("@EmployeeSerial", productModel.EmployeeSerial);
                    sqlCmd.Parameters.AddWithValue("@CountrySerial", productModel.CountrySerial);
                    sqlCmd.Parameters.AddWithValue("@TownSerial", productModel.TownSerial);
                    sqlCmd.Parameters.AddWithValue("@Phone1", productModel.Phone1);
                    sqlCmd.Parameters.AddWithValue("@Phone2", productModel.Phone2);
                    sqlCmd.Parameters.AddWithValue("@Phone3", productModel.Phone3);
                    sqlCmd.Parameters.AddWithValue("@AreaStock", productModel.AreaStock);
                    sqlCmd.ExecuteNonQuery();
                    TempData["As"] = "";
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayStocks");

        }
        [HttpGet]
        public ActionResult DeleteStock(int? id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM StoreCode WHere Serial = @Serial";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Serial", id);
                    sqlCmd.ExecuteNonQuery();
                    TempData["Al"] = "";
                }
            }
            catch
            {
                TempData["A"] = "s";
            }

            return RedirectToAction("DisplayStocks");
        }
    
   
    }
}