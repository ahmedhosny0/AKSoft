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
    public class UnitController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult SaveUnit()
        {
            ViewBag.MaxCode = objContext.UnitCode.Max(x => x.Code) + 1;
            return View();
        }
        [HttpPost]

        public ActionResult SaveUnit(UnitCode model, string name)
        {

            try
            {
                TopSoft db = new TopSoft();
                UnitCode unit = new UnitCode();
                unit.ArabicName = model.ArabicName;
                unit.Description = model.Description;
                unit.Code = model.Code;
                db.UnitCode.Add(unit); db.SaveChanges();
                int latestEmpId = unit.Serial;
                TempData["Al"] = unit.ArabicName;
                return RedirectToAction("SaveUnit");

            }

            catch (Exception ex)
            {
                throw ex;

            }
        }


        // Units Action Delete Edit
        [HttpGet]
        public ActionResult DisplayUnits()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,Code,ArabicName,Description FROM UnitCode", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }


        [HttpGet]
        public ActionResult CreateUnit()
        {
            return View(new UnitCode());
        }
        public ActionResult DeleteUnit(int? id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM UnitCode WHere Serial = @Serial";
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
            return RedirectToAction("DisplayUnits");
        }
        public ActionResult CreateProduct()
        {
            return View(new GroupCode());
        }

        // Edit Categories
        public ActionResult EditUnit(int? id)
        {
            UnitCode productModel = new UnitCode();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT Serial,Code,ArabicName,Description FROM UnitCode Where Serial = @Serial";
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
                return View(productModel);
            }
            else
                return RedirectToAction("DisplayUnits");

        }
        [HttpPost]

        public ActionResult EditUnit(UnitCode productModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "UPDATE UnitCode SET Code=@Code,ArabicName = @ArabicName ,Description=@Description   WHere Serial = @pr";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                    sqlCmd.Parameters.AddWithValue("@Code", productModel.Code);
                    sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                    sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
                    sqlCmd.ExecuteNonQuery();
                    TempData["As"] = "";
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayUnits");

        }
    }
}