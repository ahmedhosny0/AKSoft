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
    public class GroupController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult SaveGroup()
        {
            ViewBag.MaxCode = objContext.GroupCode.Max(x => x.Code) + 1;

            return View();

        }
        [HttpPost]

        public ActionResult SaveGroup(GroupCode model)
        {
            try
            {
                TopSoft db = new TopSoft();
                GroupCode group = new GroupCode();
                group.ArabicName = model.ArabicName;
                group.Code = model.Code;
                db.GroupCode.Add(group);
                db.SaveChanges();
                TempData["Al"] = group.ArabicName;
                int latestEmpId = group.Serial;
                return RedirectToAction("SaveGroup");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        //---------------------------------------------------------------------

        [HttpGet]
        public ActionResult DisplayCategories()
        {
            DataTable dtblProduct = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,Code,ArabicName,Description FROM GroupCode", sqlCon);
                    sqlDa.Fill(dtblProduct);
                }
            }
            catch
            {
                TempData["A"] = "s";
            }
            return View(dtblProduct);
        }

        public ActionResult DeleteCat(int? id)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM GroupCode WHere Serial = @Serial";
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
            return RedirectToAction("DisplayCategories");
        }
        // Edit Categories
        public ActionResult EditCat(int? id)
        {
            GroupCode productModel = new GroupCode();
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT Serial,Code,ArabicName,Description FROM GroupCode Where Serial = @Serial";
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
                return RedirectToAction("DisplayCategories");
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult EditCat(GroupCode productModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE GroupCode SET Code=@CodeArabicName = @ArabicName ,Description=@Description   WHere Serial = @pr";
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
            return RedirectToAction("DisplayCategories");
        }

    }
}