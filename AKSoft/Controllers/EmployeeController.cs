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
    public class EmployeeController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult SaveEmployee()
        {
            TopSoft db = new TopSoft();
            ViewBag.MaxCode = objContext.Employee.Max(x => x.Code) + 1;
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = db.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveEmployee(Employee model)
        {
            try
            {
                TopSoft db = new TopSoft();
                List<CountryCode> list1 = db.CountryCode.ToList();
                ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
                List<TownCode> list2 = db.TownCode.ToList();
                ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
                Employee product = new Employee();
                product.Serial = model.Serial;
                product.Code = model.Code;
                product.ArabicName = model.ArabicName;
                product.EnglishName = model.EnglishName;
                product.DescName = model.DescName;
                product.Description = model.Description;
                product.Address1 = model.Address1;
                product.Address2 = model.Address2;
                product.Telephone1 = model.Telephone1;
                product.Telephone2 = model.Telephone2;
                product.Telephone3 = model.Telephone3;
                product.CountrySerial = model.CountrySerial;
                product.TownSerial = model.TownSerial;
                product.Email = model.Email;
                product.Website = model.Website;
                db.Employee.Add(product);
                db.SaveChanges();
                int latestEmpId = product.Serial;
                TempData["Al"] = product.ArabicName;
                return RedirectToAction("SaveEmployee");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpGet]
        public ActionResult DisplayEmployees()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,[ArabicName] ,[EnglishName],[DescName] ,[Description] ,[Address1],[Address2],[Telephone1] ,[Telephone2] ,[Telephone3],[CountrySerial],[TownSerial],[Email],[Website] ,AddUserDate from Employee", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Employee WHere Serial = @Serial";
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
            return RedirectToAction("DisplayEmployees");
        }
        //end Employee
    }
}