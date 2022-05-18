using AKSoft.Controllers;
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

public class ProductController : BaseController
{  

    string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
    TopSoft objContext = new TopSoft();
    public ActionResult SaveProduct()
    {
        TopSoft db = new TopSoft();
        ViewBag.MaxCode = db.ItemCode.Max(x => x.Code) + 1;
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName",1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName",1);
        return View();

    } 
    [HttpPost]

    public ActionResult SaveProduct(ItemCode model)
    {
        try
        {
            TopSoft db = new TopSoft();
            List<UnitCode> list1 = db.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
            List<GroupCode> list3 = db.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
            ItemCode product = new ItemCode();
            if (model.Code == null)
            {
                model.Code = 0;
            }
            product.Code = model.Code;
            product.Serial = model.Serial;
            product.SerialGroup = model.SerialGroup;
            product.Unit1 = model.Unit1;
            product.ArabicName = model.ArabicName;
            product.EnglishName = model.EnglishName;
            product.Counts = model.Counts;
            product.DescName = model.DescName;
            product.Description = model.Description;
            product.PricePurchase1Unit1 = model.PricePurchase1Unit1;
            product.PriceSale1Unit1 = model.PriceSale1Unit1;
            db.ItemCode.Add(product);
            db.SaveChanges();
            int latestEmpId = product.Serial;
            TempData["Al"] = product.ArabicName;
            return RedirectToAction("SaveProduct");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    //Start Item
    [HttpGet]
    public ActionResult DisplayItems()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("select distinct ItemCode,ItemCode2,ItemName,ItemDescription,UnitName,GroupName from ItemCard", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }
   
    public ActionResult EditItem(int? id)
    {

        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
        ItemCode productModel = new ItemCode();
        DataTable dtblProduct = new DataTable();
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "select Serial,Code,Unit1,SerialGroup,ArabicName,EnglishName,DescName,Description,PricePurchase1Unit1,PriceSale1Unit1 from itemcode Where Serial=@Serial";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
                sqlDa.Fill(dtblProduct);
            }
            if (dtblProduct.Rows.Count <= 1)
            {
                productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                productModel.Code = Convert.ToInt32(dtblProduct.Rows[0][1].ToString());
                productModel.Unit1 = Convert.ToInt32(dtblProduct.Rows[0][2].ToString());
                productModel.SerialGroup = Convert.ToInt32(dtblProduct.Rows[0][3].ToString());
                productModel.ArabicName = dtblProduct.Rows[0][4].ToString();
                productModel.EnglishName = dtblProduct.Rows[0][5].ToString();
                productModel.DescName = dtblProduct.Rows[0][6].ToString();
                productModel.Description = dtblProduct.Rows[0][7].ToString();
                productModel.PricePurchase1Unit1 = float.Parse(dtblProduct.Rows[0][8].ToString());
                productModel.PriceSale1Unit1 = float.Parse(dtblProduct.Rows[0][9].ToString());
                TempData["As"] = 1;
                return View(productModel);
            }
        }
        catch
        {
            TempData["A"] = 1;
        }

            return RedirectToAction("DisplayItems");

    }
    [HttpPost]

    public ActionResult EditItem(ItemCode productModel)
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "UPDATE ItemCode SET Code=@Code,ArabicName=@ArabicName,EnglishName=@EnglishName,DescName=@DescName,Description=@Description, SerialGroup=@SerialGroup,Unit1=@Unit1,PricePurchase1Unit1=@PricePurchase1Unit1,PriceSale1Unit1=@PriceSale1Unit1  WHere Serial = @pr";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                sqlCmd.Parameters.AddWithValue("@Code", productModel.Code);
                sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
                sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
                sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
                sqlCmd.Parameters.AddWithValue("@SerialGroup", productModel.SerialGroup);
                sqlCmd.Parameters.AddWithValue("@Unit1", productModel.Unit1);
                sqlCmd.Parameters.AddWithValue("@PricePurchase1Unit1", productModel.PricePurchase1Unit1);
                sqlCmd.Parameters.AddWithValue("@PriceSale1Unit1", productModel.PriceSale1Unit1);
                sqlCmd.ExecuteNonQuery();
                TempData["As"] = "";
            }
        }
        catch
        {
            TempData["A"] = 1;
        }
        return RedirectToAction("DisplayItems");

    }
    [HttpGet]
    public ActionResult DeleteItem(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM ItemCode WHere Serial = @Serial";
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
        return RedirectToAction("DisplayItems");
    }
    public ActionResult Start()
    {
        return View();
    }
}


