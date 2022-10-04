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
    public class CountryController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();

        public ActionResult SaveCountry()
        {
            ViewBag.MaxCode = objContext.CountryCode.Max(x => x.Code) + 1;
            return View();
        }
        [HttpPost]
        public ActionResult SaveCountry(CountryCode model, string name)
        {
            try
            {
                TopSoft db = new TopSoft();
                CountryCode unit = new CountryCode();
                unit.ArabicName = model.ArabicName;
                unit.Notes = model.Notes;
                unit.Code = model.Code;
                db.CountryCode.Add(unit);
                db.SaveChanges();
                int latestEmpId = unit.Serial;

                TempData["Al"] = unit.ArabicName;
                return RedirectToAction("SaveCountry");

            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpGet]
        public ActionResult DisplayCountries()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,Code,ArabicName,Notes from CountryCode", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        [HttpGet]
        public ActionResult DeleteCountry(int? id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM CountryCode WHere Serial = @Serial";
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
            return RedirectToAction("DisplayCountries");
        }
        public ActionResult EditCountry(int? id)
        {
            CountryCode productModel = new CountryCode();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT Serial,Code,ArabicName,Notes FROM CountryCode Where Serial = @Serial";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
                sqlDa.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count == 1)
            {
                productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                productModel.Code = Convert.ToInt32(dtblProduct.Rows[0][1].ToString());
                productModel.ArabicName = dtblProduct.Rows[0][2].ToString();
                productModel.Notes = dtblProduct.Rows[0][3].ToString();
                return View(productModel);
            }
            else
                return RedirectToAction("DisplayCountries");

        }
        [HttpPost]

        public ActionResult EditCountry(CountryCode productModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "UPDATE CountryCode SET Code=@Code,ArabicName = @ArabicName ,Notes=@Description   WHere Serial = @pr";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                    sqlCmd.Parameters.AddWithValue("@Code", productModel.Code);
                    sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                    sqlCmd.Parameters.AddWithValue("@Description", productModel.Notes);
                    sqlCmd.ExecuteNonQuery();
                    TempData["As"] = "";
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayCountries");

        }
        //end Country
    }
}