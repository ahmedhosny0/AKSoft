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
    public class CustomerController : BaseController
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult SaveCustomer()
        {
            ViewBag.MaxCode = objContext.HSales.Max(x => x.Code) + 1;
            List<CountryCode> list1 = objContext.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = objContext.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveCustomer(CustomerCode model)
        {
            try
            {
                List<CountryCode> list1 = objContext.CountryCode.ToList();
                ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
                List<TownCode> list2 = objContext.TownCode.ToList();
                ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
                CustomerCode product = new CustomerCode();
                product.Serial = model.Serial;
                product.Code = model.Code;
                product.ArabicName = model.ArabicName;
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
                objContext.CustomerCode.Add(product);
                objContext.SaveChanges();
                int latestEmpId = product.Serial;
                TempData["Al"] = product.ArabicName;
                return RedirectToAction("SaveCustomer");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpGet]
        public ActionResult DisplayCustomers()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select distinct CustomerCode,CustomerCode2,CustomerName,CustomerEname,CustomerAddress1,CustomerTel1,CustomerTel2,CountryName,TownName,Email from RptCustomers", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int? id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM CustomerCode WHere Serial = @Serial";
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
            return RedirectToAction("DisplayCustomers");
        }
        public ActionResult EditCustomer(int? id)
        {
            List<CountryCode> list1 = objContext.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = objContext.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            CustomerCode productModel = new CustomerCode();
            DataTable dtblProduct = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "Select Serial, Code,ArabicName,EnglishName,DescName,Description, Address1,Address2,CountrySerial,TownSerial,Telephone1,Telephone2,Telephone3,Email,Website From CustomerCode WHere Serial = @Serial";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
                    sqlDa.Fill(dtblProduct);
                }
                if (dtblProduct.Rows.Count == 1)
                {
                    productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                    productModel.Code = Convert.ToInt32(dtblProduct.Rows[0][1].ToString());
                    productModel.ArabicName = dtblProduct.Rows[0][2].ToString();
                    productModel.EnglishName = dtblProduct.Rows[0][3].ToString();
                    productModel.DescName = dtblProduct.Rows[0][4].ToString();
                    productModel.Description = dtblProduct.Rows[0][5].ToString();
                    productModel.Address1 = dtblProduct.Rows[0][6].ToString();
                    productModel.Address2 = dtblProduct.Rows[0][7].ToString();
                    productModel.CountrySerial = Convert.ToInt32(dtblProduct.Rows[0][8].ToString());
                    productModel.TownSerial = Convert.ToInt32(dtblProduct.Rows[0][9].ToString());
                    productModel.Telephone1 = dtblProduct.Rows[0][10].ToString();
                    productModel.Telephone2 = dtblProduct.Rows[0][11].ToString();
                    productModel.Telephone3 = dtblProduct.Rows[0][12].ToString();
                    productModel.Email = dtblProduct.Rows[0][13].ToString();
                    productModel.Website = dtblProduct.Rows[0][14].ToString();

                    TempData["As"] = 1;
                    return View(productModel);
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayCustomers");

        }
        [HttpPost]

        public ActionResult EditCustomer(CustomerCode productModel)
        {
            List<CountryCode> list1 = objContext.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = objContext.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "UPDATE CustomerCode SET Code=@Code,ArabicName=@ArabicName,EnglishName=@EnglishName,DescName=@DescName,Description=@Description, Address1=@Address1,Address2=@Address2,CountrySerial=@CountrySerial,TownSerial=@TownSerial,Telephone1=@Telephone1,Telephone2=@Telephone2,Telephone3=@Telephone3,Email=@Email,Website=@Website WHere Serial = @pr";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                    sqlCmd.Parameters.AddWithValue("@Code", productModel.Code);
                    sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                    sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
                    sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
                    sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
                    sqlCmd.Parameters.AddWithValue("@Address1", productModel.Address1);
                    sqlCmd.Parameters.AddWithValue("@Address2", productModel.Address2);
                    sqlCmd.Parameters.AddWithValue("@CountrySerial", productModel.CountrySerial);
                    sqlCmd.Parameters.AddWithValue("@TownSerial", productModel.TownSerial);
                    sqlCmd.Parameters.AddWithValue("@Telephone1", productModel.Telephone1);
                    sqlCmd.Parameters.AddWithValue("@Telephone2", productModel.Telephone2);
                    sqlCmd.Parameters.AddWithValue("@Telephone3", productModel.Telephone3);
                    sqlCmd.Parameters.AddWithValue("@Email", productModel.Email);
                    sqlCmd.Parameters.AddWithValue("@Website", productModel.Website);
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.ExecuteNonQuery();
                    TempData["As"] = "";
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayCustomers");

        }
    }
}