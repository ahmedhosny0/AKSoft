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

public class ProductController : Controller
{
    public ActionResult Home()
    {
        return View();
    }
    //  GET: Test
    public ActionResult Start()
    {
        return View();
    }
    public ActionResult Login()
    {
        return View();
    }
    public ActionResult SaveProduct()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        return View();

    }
    public ActionResult SaveInvoiceSales()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        return View();

    }
        [HttpPost]
    public ActionResult SaveInvoiceSales(HSales model)
    {
        try
        {
            TopSoft db = new TopSoft();
            HSales invo = new HSales();
            List<UnitCode> list1 = db.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<StoreCode> list2 = db.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            List<GroupCode> list3 = db.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
            List<ItemCode> list4 = db.ItemCode.ToList();
            ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
            invo.BranchCode = model.BranchCode;
            invo.Code = model.Code;
            invo.CurrencyCode = model.CurrencyCode;
            invo.Date = model.Date;
            invo.DealerCode = model.DealerCode;
            invo.Discount = model.Discount;
            invo.DiscValue = model.DiscValue;
            invo.Factor = model.Factor;
            invo.FirstPayment = model.FirstPayment;
            invo.GroupSerial = model.GroupSerial;
            invo.ID = model.ID;
            invo.ItemSerial = model.ItemSerial;
            invo.Paid = model.Paid;
            invo.Price = model.Price;
            invo.Quantity = model.Quantity;
            invo.RegionCode = model.RegionCode;
            invo.StoreSerial = model.StoreSerial;
            invo.Tax = model.Tax;
            invo.Total = model.Total;
            invo.TotalAfterDisc = model.TotalAfterDisc;
            invo.UnitSerial = model.UnitSerial;
            db.HSales.Add(invo);
            db.SaveChanges();
            TempData["Al"] = "";
            int latestEmpId = invo.Serial;
            return RedirectToAction("SaveInvoiceSales");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }

    //----
    [HttpGet]
    public ActionResult DisplayInvoiceSales()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial, StoreSerial, ItemSerial, UnitSerial,GroupSerial, Quantity,Price,Total FROM Hsales", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }
    [HttpGet]
    public ActionResult DeleteInSales(int? id)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "DELETE FROM Hsales WHere Serial = @Serial";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Serial", id);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayInvoiceSales");
    }

   
    // Purchase 

    public ActionResult SaveInvoicePurchase()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        return View();

    }
    [HttpPost]

    public ActionResult SaveInvoicePurchase(HPurchase model)
    {
        try
        {
            TopSoft db = new TopSoft();
            HPurchase invo2 = new HPurchase();
            List<UnitCode> list1 = db.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<StoreCode> list2 = db.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            List<GroupCode> list3 = db.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
            List<ItemCode> list4 = db.ItemCode.ToList();
            ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
            invo2.BranchCode = model.BranchCode;
            invo2.Code = model.Code;
            invo2.CurrencyCode = model.CurrencyCode;
            invo2.Date = model.Date;
            invo2.DealerCode = model.DealerCode;
            invo2.Discount = model.Discount;
            invo2.DiscValue = model.DiscValue;
            invo2.Factor = model.Factor;
            invo2.GroupSerial = model.GroupSerial;
            invo2.ID = model.ID;
            invo2.ItemSerial = model.ItemSerial;
            invo2.Price = model.Price;
            invo2.Quantity = model.Quantity;
            invo2.RegionCode = model.RegionCode;
            invo2.StoreSerial = model.StoreSerial;
            invo2.Tax = model.Tax;
            invo2.Total = model.Total;
            invo2.TotalAfterDisc = model.TotalAfterDisc;
            invo2.UnitSerial = model.UnitSerial;
            db.HPurchase.Add(invo2);
            db.SaveChanges();
            TempData["Al"] = "";
            int latestEmpId = invo2.Serial;
            return RedirectToAction("SaveInvoicePurchase");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    [HttpGet]
    public ActionResult DisplayInvoicePurchase()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial, StoreSerial, ItemSerial, UnitSerial,GroupSerial, Quantity,Price,Total FROM HPurchase", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteInPurchase(int? id)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "DELETE FROM HPurchase WHere Serial = @Serial";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Serial", id);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayInvoicePurchase");
    }

    // Product

    [HttpPost]

    public ActionResult SaveProduct(ItemCode model)
    {
        try
        {
            TopSoft db = new TopSoft();
            List<UnitCode> list1 = db.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<StoreCode> list2 = db.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            List<GroupCode> list3 = db.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
            ItemCode product = new ItemCode();
            product.StoreID = model.StoreID;
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
    public ActionResult SaveStock()
    {
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
            stock.EnglishName = model.EnglishName;
            stock.DescName = model.DescName;
            stock.Description = model.Description;
            stock.Address = model.Address;
            stock.AreaStock = model.AreaStock;
            stock.ID = model.ID;
            stock.NumberOfLeans = model.NumberOfLeans;
            stock.Phone1 = model.Phone1;
            stock.Phone2 = model.Phone2;
            stock.Phone3 = model.Phone3;
            stock.Phone4 = model.Phone4;
            stock.StoreKeeper = model.StoreKeeper;
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
    public ActionResult SaveUnit()
    {
        ViewBag.mssg = TempData["mssg"] as string;

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
            unit.EnglishName = model.EnglishName;
            unit.DescName = model.DescName;
            unit.Description = model.Description;
            unit.ID = model.ID;
            unit.Code = model.Code;
            db.UnitCode.Add(unit);
            db.SaveChanges();
            int latestEmpId = unit.Serial;

            TempData["Al"] = unit.ArabicName;
            return RedirectToAction("SaveUnit");

        }

        catch (Exception ex)
        {
            throw ex;

        }
    }

    public ActionResult SaveGroup()
    {
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
            group.EnglishName = model.EnglishName;
            group.DescName = model.DescName;
            group.Description = model.Description;
            group.ID = model.ID;
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


    [HttpPost]

   
    //---------------------------------------------------------------------

    public ActionResult Edit(int? id)
    {
        using (TopSoft db = new TopSoft())
        {
            return View(db.GroupCode.Where(x => x.Serial == id).FirstOrDefault());
        }
    }

    [HttpPost]
    public ActionResult Edit(int? id, GroupCode group)
    {
        try
        {
            using (TopSoft db = new TopSoft())
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("d");
        }
        catch
        {
            return View();
        }
    }
    public ActionResult Delete(int? id)
    {
        //if (id==null)
        //{
        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}
        //TopSoft db = new TopSoft();
        //GroupCode group = db.GroupCode.Find(id);
        //if (group ==null)
        //{
        //    return HttpNotFound();
        //}
        //return View(group);
        using (TopSoft db = new TopSoft())
        {
            return View(db.GroupCode.Where(x => x.Serial == id).FirstOrDefault());
        }
    }

    [HttpPost]
    public ActionResult Delete(int? id, FormCollection collection)
    {
        //TopSoft db = new TopSoft();
        //GroupCode group = db.GroupCode.Find(id);
        //db.GroupCode.Remove(group);
        //db.SaveChanges();
        //return RedirectToAction("d");



        //                TopSoft db = new TopSoft();
        try
        {
            using (TopSoft db = new TopSoft())
            {

                GroupCode group = db.GroupCode.Where(x => x.Serial == id).FirstOrDefault();
                db.GroupCode.Remove(group);
                db.SaveChanges();
            }

            return RedirectToAction("d");
        }
        catch
        {
            return View();
        }
    }
    string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
    [HttpGet]
    public ActionResult DisplayCategories()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description FROM GroupCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new GroupCode());
    }
    public ActionResult DeleteCat(int? id)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "DELETE FROM GroupCode WHere Serial = @Serial";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Serial", id);
            sqlCmd.ExecuteNonQuery();
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
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Description FROM GroupCode Where Serial = @Serial";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
           sqlDa.Fill(dtblProduct);
        }
        if (dtblProduct.Rows.Count == 1)
        {
            productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
            productModel.ArabicName = dtblProduct.Rows[0][1].ToString();
            productModel.EnglishName = dtblProduct.Rows[0][2].ToString();
            productModel.DescName = dtblProduct.Rows[0][3].ToString();
            productModel.Description = dtblProduct.Rows[0][4].ToString();
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
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "UPDATE GroupCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Description=@Description   WHere Serial = @pr";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
           sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
            sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
            sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
            sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
          sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
           sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayCategories");
    }

    // Units Action Delete Edit
    [HttpGet]
    public ActionResult DisplayUnits()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description FROM UnitCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    // Edit Items and Display them
    [HttpGet]
    public ActionResult DisplayItems()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description,StoreID,SerialGroup,Unit1,PricePurchase1Unit1,[PriceSale1Unit1],[Counts] FROM ItemCode", sqlCon);
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
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "DELETE FROM UnitCode WHere Serial = @Serial";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Serial", id);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayUnits");
    }
    public ActionResult CreateProduct()
    {
        return View(new GroupCode());
    }
    [HttpGet]
    public ActionResult DeleteItem(int? id)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "DELETE FROM ItemCode WHere Serial = @Serial";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Serial", id);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayItems");
    }
    // Edit Categories
    public ActionResult EditUnit(int? id)
    {
        UnitCode productModel = new UnitCode();
                DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Description FROM UnitCode Where Serial = @Serial";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
            sqlDa.Fill(dtblProduct);
        }
        if (dtblProduct.Rows.Count == 1)
        {
            productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
            productModel.ArabicName = dtblProduct.Rows[0][1].ToString();
            productModel.EnglishName = dtblProduct.Rows[0][2].ToString();
            productModel.DescName = dtblProduct.Rows[0][3].ToString();
            productModel.Description = dtblProduct.Rows[0][4].ToString();
            return View(productModel);
        }
        else
            return RedirectToAction("DisplayUnits");
        
    }
    //---
    public ActionResult EditItem(int? id)
    {
        ItemCode productModel = new ItemCode();
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Description,StoreID,SerialGroup,Unit1,PricePurchase1Unit1,PriceSale1Unit1,Counts FROM ItemCode";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
            sqlDa.Fill(dtblProduct);
        }
        if (dtblProduct.Rows.Count == 1)
        {
            productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
            productModel.ArabicName = dtblProduct.Rows[0][1].ToString();
            productModel.EnglishName = dtblProduct.Rows[0][2].ToString();
            productModel.DescName = dtblProduct.Rows[0][3].ToString();
            productModel.Description = dtblProduct.Rows[0][4].ToString();
            productModel.StoreID = Convert.ToInt32(dtblProduct.Rows[0][5].ToString());
            productModel.SerialGroup = Convert.ToInt32(dtblProduct.Rows[0][6].ToString());
            productModel.PricePurchase1Unit1 = Convert.ToInt32(dtblProduct.Rows[0][7].ToString());
            productModel.PriceSale1Unit1 = Convert.ToInt32(dtblProduct.Rows[0][8].ToString());
            productModel.Counts = Convert.ToInt32(dtblProduct.Rows[0][9].ToString());
            return View(productModel);
        }
        else
            return RedirectToAction("DisplayItems");
    }


    //
    // POST: /Product/Edit/5
    [HttpPost]
 
    public ActionResult EditUnit(UnitCode productModel)
    {
         using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
 
            string query = "UPDATE UnitCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Description=@Description   WHere Serial = @pr";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
            sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
            sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
            sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
            sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayUnits");
     
    }

    [HttpGet]
    public ActionResult DisplayStocks()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description,[Address],[NumberOfLeans],[StoreKeeper],[Phone1],[Phone2],[Phone3] FROM StoreCode ", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);

    }
    // Stock Edit
    public ActionResult EditStock(int? id)
    {
        StoreCode productModel = new StoreCode();
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Description,[Address],[NumberOfLeans],[StoreKeeper],[Phone1],[Phone2],[Phone3] FROM StoreCode Where Serial =@Serial";
            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
            sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
            sqlDa.Fill(dtblProduct);
        }
        if (dtblProduct.Rows.Count == 1)
        {
            productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
            productModel.ArabicName = dtblProduct.Rows[0][1].ToString();
            productModel.EnglishName = dtblProduct.Rows[0][2].ToString();
            productModel.DescName = dtblProduct.Rows[0][3].ToString();
            productModel.Description = dtblProduct.Rows[0][4].ToString();
            productModel.Address = dtblProduct.Rows[0][5].ToString();
            productModel.NumberOfLeans = Convert.ToInt32(dtblProduct.Rows[0][6].ToString());
            productModel.StoreKeeper = dtblProduct.Rows[0][7].ToString();
            productModel.Phone1 = dtblProduct.Rows[0][8].ToString();
            productModel.Phone2 = dtblProduct.Rows[0][9].ToString();
            productModel.Phone3 = dtblProduct.Rows[0][10].ToString();
            return View(productModel);
        }
        else
            return RedirectToAction("DisplayStocks");
    }
    //
    // POST: /Product/Edit/5
    [HttpPost]

    public ActionResult EditStock(StoreCode productModel)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "UPDATE StoreCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Description=@Description ,Address=@Address,StoreKeeper=@StoreKeeper,NumberOfLeans=@NumberOfLeans, Phone1=@Phone1,Phone2=@Phone2, Phone3=@Phone3  WHere Serial = @pr";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
            sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
            sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
            sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
            sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
            sqlCmd.Parameters.AddWithValue("@Address", productModel.Address);
             sqlCmd.Parameters.AddWithValue("@NumberOfLeans", productModel.NumberOfLeans);
             sqlCmd.Parameters.AddWithValue("@StoreKeeper", productModel.StoreKeeper);
            sqlCmd.Parameters.AddWithValue("@Phone1", productModel.Phone1);
            sqlCmd.Parameters.AddWithValue("@Phone2", productModel.Phone2);
            sqlCmd.Parameters.AddWithValue("@Phone3", productModel.Phone3);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayStocks");

    }
    [HttpGet]
    public ActionResult DeleteStock(int? id)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "DELETE FROM StoreCode WHere Serial = @Serial";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@Serial", id);
            sqlCmd.ExecuteNonQuery();
        }
        return RedirectToAction("DisplayStocks");
    }

    public ActionResult CashExchange()
    {
        return View();
    }
    public ActionResult ReceiveCash()
    {
        return View();
    }
    public ActionResult SaveCustomer()
    {
        return View();
    }
    public ActionResult SaveSupplier()
    {
        return View();
    }
}
   











//         public ActionResult Doc()
//        {
//        //    TopSoft db = new TopSoft();
//            //List<GroupCode> listEmp = db.GroupCode.Select(x => new GroupCode { ArabicName = x.ArabicName, EnglishName = x.EnglishName, DescName = x.DescName, Description = x.Description }).ToList();
////
//         //   ViewBag.EmployeeList = listEmp;

//            return View();
//        }
//        [HttpPost]
//        public ActionResult Doc(GroupCode model)
//        {
//            try
//            {
//                TopSoft db = new TopSoft();
//          //      List<Department> list = db.Department.ToList();
//            //    ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

//                if (model.Serial > 0)
//                {
//                    //update
//                    GroupCode group = db.GroupCode.SingleOrDefault(x => x.Serial == model.Serial && x.IsDeleted == false);

//                group.ArabicName = model.ArabicName;
//                group.EnglishName = model.EnglishName;
//                group.DescName = model.DescName;
//                group.Description = model.Description;
//                group.ID = model.ID;
//                group.Code = model.Code;
//                db.GroupCode.Add(group);
//                    db.SaveChanges();


//                }
//                else
//                {
//                    //Insert
//                    GroupCode group = new GroupCode();
//                group.ArabicName = model.ArabicName;
//                group.EnglishName = model.EnglishName;
//                group.DescName = model.DescName;
//                group.Description = model.Description;
//                group.ID = model.ID;
//                group.Code = model.Code;
//                db.GroupCode.Add(group);
//                    group.IsDeleted = false;
//                    db.GroupCode.Add(group);
//                    db.SaveChanges();

//                }
//                return View(model);

//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }

//        }
/*
        public ActionResult AddEditEmployee(int Serial)
        {
            TopSoft db = new TopSoft();
            //List<Department> list = db.Department.ToList();
            //ViewBag.DepartmentList = new SelectList(list, "DepartmentId", "DepartmentName");

            GroupCode model = new GroupCode();

            if (Serial > 0)
            {

                GroupCode group = db.GroupCode.SingleOrDefault(x => x.Serial == Serial && x.IsDeleted == false);
                model.ArabicName = group.ArabicName;
                model.EnglishName = group.EnglishName;
                model.DescName = group.DescName;
                model.Description = group.Description;
                model.ID = group.ID;
                model.Code = group.Code;
                db.GroupCode.Add(group);
            }
            return PartialView("Partial2", model);
        }
        public JsonResult DeleteEmployee(int Serial)
        {
            TopSoft db = new TopSoft();

            bool result = false;
            GroupCode group = db.GroupCode.SingleOrDefault(x => x.IsDeleted == false && x.Serial == Serial);
            if (group != null)
            {
                group.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }

    */

