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
    string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
    public ActionResult Test(int? id)
    {
        return View();
    }
    
    [HttpGet]
    public ActionResult a()
    {

        return View();
    }
    public ActionResult c()
    {
        return View();
    }
    public ActionResult index()
    {
        return View();
    }
    public ActionResult User()
    {
        return View();
    }

    public ActionResult Worker()
    {
        return View();
    }
    public ActionResult GeneralUser()
    {
        return View();
    }
    public ActionResult Sales()
    {
        return View();
    }

    public ActionResult Home()
    {
        return View();
    }
    public ActionResult AddUser()
    {
        TopSoft db = new TopSoft();
        List<BranchCode> list7 = db.BranchCode.ToList();
        ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName",1);
        List<SectorCode> list8 = db.SectorCode.ToList();
        ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName",1);
        List<UserRole> list9 = db.UserRole.ToList();
        ViewBag.DepartmentList9 = new SelectList(list9, "RoleId", "RoleName");
        return View();
    }
    [HttpPost]

    public ActionResult AddUser(UserInfo model)
    {
        try
        {
            TopSoft db = new TopSoft();
            List<BranchCode> list7 = db.BranchCode.ToList();
            ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName");
            List<SectorCode> list8 = db.SectorCode.ToList();
            ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName");
            List<UserRole> list9 = db.UserRole.ToList();
            ViewBag.DepartmentList9 = new SelectList(list9, "RoleId", "RoleName");
            UserInfo group = new UserInfo();
            group.FirstName = model.FirstName;
            group.MiddleName = model.MiddleName;
            group.LastName = model.LastName;
            group.Email = model.Email;
            group.Password = model.Password;
            group.RePassword = model.RePassword;
            group.AddUserDate = model.AddUserDate;
            group.BranchSerial = model.BranchSerial;
            group.SectorSerial = model.SectorSerial;
            group.Role = model.Role;
            db.UserInfo.Add(group);
            db.SaveChanges();
            TempData["Al"] = "";
            int latestEmpId = group.Id;
            return RedirectToAction("AddUser");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
   
    // Ahmed AKSoft
    public ActionResult Login()
    {
        TopSoft db = new TopSoft();
        List<BranchCode> list7 = db.BranchCode.ToList();
        ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName",1);
        List<SectorCode> list8 = db.SectorCode.ToList();
        ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName",1);
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(UserInfo objUser)
    {
        try
        {
            using (TopSoft db = new TopSoft())
            {
                List<BranchCode> list7 = db.BranchCode.ToList();
                ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName");
                List<SectorCode> list8 = db.SectorCode.ToList();
                ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName");
                UserInfo group = new UserInfo();
                group.BranchSerial = objUser.BranchSerial;
                group.SectorSerial = objUser.SectorSerial;
                var obj = db.UserInfo.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();// && a.BranchSerial.Equals(objUser.BranchSerial) && a.SectorSerial.Equals(objUser.SectorSerial)
                string result = "fail";
                if (obj != null)
                {
                    Session["UserID"] = obj.Id;
                    Session["Role"] = obj.Role;
                    Session["UserName"] = obj.FirstName + " " + obj.LastName;
                    TempData["B"] = obj.SectorCode;
                    if (obj.Role == 1)
                    {
                        return RedirectToAction("Home");
                    }
                    else if (obj.Role == 2)
                    {
                        return RedirectToAction("User");
                    }
                    else if (obj.Role == 3)
                    {
                        return RedirectToAction("Sales");
                    }
                    else if (obj.Role == 4)
                    {
                        return RedirectToAction("GeneralUser");
                    }
                    else if (obj.Role == 5)
                    {
                        return RedirectToAction("Worker");
                    }

                }
                else
                {
                    TempData["A"] = "s";
                    ViewBag.ErrorMessage = "sssss should not begin with Comma ','.";

                    return View();
                }
            }
        }
        catch
        {
            TempData["A"] = "s";
        }
        

        //TempData["A"] = "";   
        return RedirectToAction("login");
    }

    public ActionResult UserDashBoard()
    {
        if (Session["UserID"] != null)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Login");
        }
    }
    //  GET: Test
    public ActionResult Start()
    {
        return View();
    }

    
    public ActionResult SaveProduct()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName",1);
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName",1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName",1);
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        return View();

    }
    public ActionResult SaveInvoiceSales()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName",1);
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName",1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName",1);
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        List<CustomerCode> list5 = db.CustomerCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName",1);
        List<DealerCode> list6 = db.DealerCode.ToList();
        ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName",1);
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
            List<CustomerCode> list5 = db.CustomerCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
            List<DealerCode> list6 = db.DealerCode.ToList();
            ViewBag.DepartmentList6 = new SelectList(list5, "Serial", "ArabicName");
            ViewBag.c = new SelectList(list4, "Serial", "ArabicName");

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
            invo.CustomerSerial = model.CustomerSerial;
            invo.AddUserDate = model.AddUserDate;
            invo.TotalAfterTax = model.TotalAfterTax;
            invo.TaxValue = model.TaxValue;
            invo.AddUserDate = model.AddUserDate;
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

    //INvoice Sales

    [HttpGet]
    public ActionResult DisplayInvoiceSales()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial, StoreSerial, ItemSerial, UnitSerial,GroupSerial,CustomerSerial, Quantity,Price,Total FROM Hsales", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }
    [HttpGet]
    public ActionResult DeleteInSales(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Hsales WHere Serial = @Serial";
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
        return RedirectToAction("DisplayInvoiceSales");
    }


    // Purchase 

    public ActionResult SaveInvoicePurchase()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName",1);
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName",1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName",1);
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        List<SupplierCode> list5 = db.SupplierCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName",1);
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
            List<SupplierCode> list5 = db.SupplierCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
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
            invo2.SupplierSerial = model.SupplierSerial;
            invo2.AddUserDate = model.AddUserDate;
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial, StoreSerial, ItemSerial, UnitSerial,GroupSerial,SupplierSerial, Quantity,Price,Total,AddUserDate FROM HPurchase", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteInPurchase(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM HPurchase WHere Serial = @Serial";
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
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName",1);
            List<StoreCode> list2 = db.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName",1);
            List<GroupCode> list3 = db.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName",1);
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
            product.AddUserDate = model.AddUserDate;
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
        TopSoft db = new TopSoft();
        List<CountryCode> list1 = db.CountryCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
        List<TownCode> list2 = db.TownCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
        List<Employee> list3 = db.Employee.ToList();
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
            stock.EnglishName = model.EnglishName;
            stock.DescName = model.DescName;
            stock.Description = model.Description;
            stock.Address = model.Address;
            stock.AreaStock = model.AreaStock;
            stock.Code = model.Code;
            stock.NumberOfLeans = model.NumberOfLeans;
            stock.Phone1 = model.Phone1;
            stock.Phone2 = model.Phone2;
            stock.Phone3 = model.Phone3;
            stock.Phone4 = model.Phone4;
            stock.StoreKeeper = model.StoreKeeper;
            stock.AddUserDate = model.AddUserDate;
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
            //foreach (var item in UnitCode.cou)
            //            {
            //                OrderDetails orderDetails = new OrderDetails() {
            //                    OrderID = orderID,
            //                    ProductID = item.ProductID,
            //                    Price = item.Price,
            //                    Quantity = item.Quantity,
            //                    TotalPrice = item.TotalPrice
            //                };
            TopSoft db = new TopSoft();
            UnitCode unit = new UnitCode();
            unit.ArabicName = model.ArabicName;
            unit.EnglishName = model.EnglishName;
            unit.DescName = model.DescName;
            unit.Description = model.Description;
            unit.ID = model.ID;
            unit.Code = model.Code;
            unit.AddUserDate = model.AddUserDate;
            db.UnitCode.Add(unit);
            db.SaveChanges();
            int latestEmpId = unit.Serial;

            TempData["Al"] = unit.ArabicName;
            return View();

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
            group.AddUserDate = model.AddUserDate;
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description,AddUserDate,AddUserDate FROM GroupCode", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
        }
        catch
        {
            TempData["A"] = "s";
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
        try
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
                TempData["As"] = "";
            }
        }
        catch
        {
            TempData["A"] = 1;
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

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description,AddUserDate FROM UnitCode", sqlCon);
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

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description,StoreID,SerialGroup,Unit1,PricePurchase1Unit1,[PriceSale1Unit1],[Counts],AddUserDate FROM ItemCode", sqlCon);
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
        try
        { 
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Description,StoreID,SerialGroup,Unit1,PricePurchase1Unit1,PriceSale1Unit1,Counts,AddUserDate FROM ItemCode";
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


    //
    // POST: /Product/Edit/5
    [HttpPost]

    public ActionResult EditUnit(UnitCode productModel)
    {
        try
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
                TempData["As"] = "";
            }
        }
        catch
        {
            TempData["A"] = 1;
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Description,[Address],[NumberOfLeans],[StoreKeeper],[Phone1],[Phone2],[Phone3],AddUserDate FROM StoreCode ", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);

    }
    // Stock Edit
    public ActionResult EditStock(int? id)
    {

        StoreCode productModel = new StoreCode();
        DataTable dtblProduct = new DataTable();
       try
        {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {

            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Description,[Address],[NumberOfLeans],[StoreKeeper],[Phone1],[Phone2],[Phone3],AddUserDate FROM StoreCode Where Serial =@Serial";
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
        try
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
    //Supplier
    public ActionResult SaveSupplier()
    {
        TopSoft db = new TopSoft();
        List<CountryCode> list1 = db.CountryCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<TownCode> list2 = db.TownCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
        return View();
    }
    [HttpPost]
    public ActionResult SaveSupplier(SupplierCode model)
    {
        try
        {
            TopSoft db = new TopSoft();
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = db.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            SupplierCode product = new SupplierCode();
            product.Serial = model.Serial;
            product.Id = model.Id;
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
            product.AddUserDate = model.AddUserDate;
            db.SupplierCode.Add(product);
            db.SaveChanges();
            int latestEmpId = product.Serial;
            TempData["Al"] = product.ArabicName;
            return RedirectToAction("SaveSupplier");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    [HttpGet]
    public ActionResult DisplaySuppliers()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,[ArabicName] ,[EnglishName],[DescName] ,[Description] ,[Address1],[Address2],[Telephone1] ,[Telephone2] ,[Telephone3],[CountrySerial],[TownSerial],[Email],[Website],AddUserDate from SupplierCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteSupplier(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM SupplierCode WHere Serial = @Serial";
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
        return RedirectToAction("DisplaySuppliers");
    }
    // end Suppplier

    //Start Dealer
    public ActionResult SaveDealer()
    {
        TopSoft db = new TopSoft();
        List<CountryCode> list1 = db.CountryCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<TownCode> list2 = db.TownCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
        return View();
    }
    [HttpPost]
    public ActionResult SaveDealer(DealerCode model)
    {
        try
        {
            TopSoft db = new TopSoft();
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = db.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            DealerCode product = new DealerCode();
            product.Serial = model.Serial;
            product.Id = model.Id;
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
            product.AddUserDate = model.AddUserDate;
            db.DealerCode.Add(product);
            db.SaveChanges();
            int latestEmpId = product.Serial;
            TempData["Al"] = product.ArabicName;
            return RedirectToAction("SaveDealer");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }

    [HttpGet]
    public ActionResult DisplayDealers()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,[ArabicName] ,[EnglishName],[DescName] ,[Description] ,[Address1],[Address2],[Telephone1] ,[Telephone2] ,[Telephone3],[CountrySerial],[TownSerial],[Email],[Website] ,AddUserDate from DealerCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteDealer(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM DealerCode WHere Serial = @Serial";
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
        return RedirectToAction("DisplayDealers");
    }
    //End Dealer
    // Customer

    public ActionResult SaveCustomer()
    {
        TopSoft db = new TopSoft();
        List<CountryCode> list1 = db.CountryCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
        List<TownCode> list2 = db.TownCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
        return View();
    }
    [HttpPost]
    public ActionResult SaveCustomer(CustomerCode model)
    {
        try
        {
            TopSoft db = new TopSoft();
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<TownCode> list2 = db.TownCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            CustomerCode product = new CustomerCode();
            product.Serial = model.Serial;
            product.Id = model.Id;
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
            product.AddUserDate = model.AddUserDate;
            db.CustomerCode.Add(product);
            db.SaveChanges();
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,[ArabicName] ,[EnglishName],[DescName] ,[Description] ,[Address1],[Address2],[Telephone1] ,[Telephone2] ,[Telephone3],[CountrySerial],[TownSerial],[Email],[Website] ,AddUserDate from CustomerCode", sqlCon);
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
    //end Customer
    // Employee

    public ActionResult SaveEmployee()
    {
        TopSoft db = new TopSoft();
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
            product.AddUserDate = model.AddUserDate;
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
    // Country

    public ActionResult SaveCountry()
    {
        TopSoft db = new TopSoft();
        List<CountryCode> list1 = db.CountryCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Code", "Code",1);
        return View();
    }
    [HttpPost]
    public ActionResult SaveCountry(UnitCode model, string name)
    {
        try
        {
            TopSoft db = new TopSoft();
            CountryCode unit = new CountryCode();
            List<CountryCode> list1 = db.CountryCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Code", "Code");
            unit.ArabicName = model.ArabicName;
            unit.EnglishName = model.EnglishName;
            unit.DescName = model.DescName;
            unit.Notes = model.Description;
            unit.Id = model.ID;
            unit.Code = model.Code;
            unit.AddUserDate = model.AddUserDate;
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Notes,AddUserDate from CountryCode", sqlCon);
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
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Notes FROM CountryCode Where Serial = @Serial";
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
            productModel.Notes = dtblProduct.Rows[0][4].ToString();
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

                string query = "UPDATE CountryCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Notes=@Description   WHere Serial = @pr";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
                sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
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

    // Town
    public ActionResult SaveTown()
    {
        return View();
    }
    [HttpPost]
    public ActionResult SaveTown(TownCode model, string name)
    {
        try
        {
            TopSoft db = new TopSoft();
            TownCode unit = new TownCode();
            unit.ArabicName = model.ArabicName;
            unit.EnglishName = model.EnglishName;
            unit.DescName = model.DescName;
            unit.Notes = model.Notes;
            unit.Id = model.Id;
            unit.Code = model.Code;
            unit.AddUserDate = model.AddUserDate;
            db.TownCode.Add(unit);
            db.SaveChanges();
            int latestEmpId = unit.Serial;
            TempData["Al"] = unit.ArabicName;
            return RedirectToAction("SaveTown");

        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    [HttpGet]
    public ActionResult DisplayTowns()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Notes,AddUserDate from TownCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteTown(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM TownCode WHere Serial = @Serial";
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
        return RedirectToAction("DisplayTowns");
    }
    public ActionResult EditTown(int? id)
    {
        TownCode productModel = new TownCode();
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Notes  FROM TownCode Where Serial = @Serial";
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
            productModel.Notes = dtblProduct.Rows[0][4].ToString();
            return View(productModel);
        }
        else
            return RedirectToAction("DisplayUnits");

    }
    [HttpPost]

    public ActionResult EditTown(TownCode productModel)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "UPDATE TownCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Notes=@Description   WHere Serial = @pr";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
                sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
                sqlCmd.Parameters.AddWithValue("@Description", productModel.Notes);
                sqlCmd.ExecuteNonQuery();
                TempData["As"] = "";
            }
        }
        catch
        {
            TempData["A"] = 1;
        }
        return RedirectToAction("DisplayTowns");

    }

    //end Town

    // Start Branch
    public ActionResult SaveBranch()
    {
        return View();
    }
    [HttpPost]
    public ActionResult SaveBranch(BranchCode model, string name)
    {
        try
        {
            TopSoft db = new TopSoft();
            BranchCode unit = new BranchCode();
            unit.ArabicName = model.ArabicName;
            unit.EnglishName = model.EnglishName;
            unit.DescName = model.DescName;
            unit.Notes = model.Notes;
            unit.Id = model.Id;
            unit.Code = model.Code;
            unit.AddUserDate = model.AddUserDate;
            db.BranchCode.Add(unit);
            db.SaveChanges();
            int latestEmpId = unit.Serial;
            TempData["Al"] = unit.ArabicName;
            return RedirectToAction("SaveBranch");

        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    [HttpGet]
    public ActionResult DisplayBranches()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Notes,AddUserDate from BranchCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteBranch(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM BranchCode WHere Serial = @Serial";
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
        return RedirectToAction("DisplayBranches");
    }
    public ActionResult EditBranch(int? id)
    {
        BranchCode productModel = new BranchCode();
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Notes  FROM BranchCode Where Serial = @Serial";
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
            productModel.Notes = dtblProduct.Rows[0][4].ToString();
            return View(productModel);
        }
        else
            return RedirectToAction("DisplayBranches");

    }
    [HttpPost]

    public ActionResult EditBranch(BranchCode productModel)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "UPDATE BranchCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Notes=@Description   WHere Serial = @pr";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
                sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
                sqlCmd.Parameters.AddWithValue("@Description", productModel.Notes);
                sqlCmd.ExecuteNonQuery();
                TempData["As"] = "";
            }
        }
        catch
        {
            TempData["A"] = 1;
        }
        return RedirectToAction("DisplayBranches");

    }
    //End Branch

    //Start Sector
    public ActionResult SaveSector()
    {
        return View();
    }
    [HttpPost]
    public ActionResult SaveSector(SectorCode model, string name)
    {
        try
        {
            TopSoft db = new TopSoft();
            SectorCode unit = new SectorCode();
            unit.ArabicName = model.ArabicName;
            unit.EnglishName = model.EnglishName;
            unit.DescName = model.DescName;
            unit.Notes = model.Notes;
            unit.Id = model.Id;
            unit.Code = model.Code;
            unit.AddUserDate = model.AddUserDate;
            db.SectorCode.Add(unit);
            db.SaveChanges();
            int latestEmpId = unit.Serial;
            TempData["Al"] = unit.ArabicName;
            return RedirectToAction("SaveSector");

        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    [HttpGet]
    public ActionResult DisplaySectors()
    {
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Serial,ArabicName,EnglishName,DescName,Notes,AddUserDate from SectorCode", sqlCon);
            sqlDa.Fill(dtblProduct);
        }
        return View(dtblProduct);
    }

    [HttpGet]
    public ActionResult DeleteSector(int? id)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM SectorCode WHere Serial = @Serial";
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
        return RedirectToAction("DisplaySectors");
    }
    public ActionResult EditSector(int? id)
    {
        SectorCode productModel = new SectorCode();
        DataTable dtblProduct = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();
            string query = "SELECT Serial,ArabicName,EnglishName,DescName,Notes FROM SectorCode Where Serial = @Serial";
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
            productModel.Notes = dtblProduct.Rows[0][4].ToString();
            return View(productModel);
        }
        else
            return RedirectToAction("DisplaySectors");

    }
    [HttpPost]

    public ActionResult EditSector(SectorCode productModel)
    {
        try
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string query = "UPDATE SectorCode SET ArabicName = @ArabicName ,EnglishName = @EnglishName ,DescName=@DescName ,Notes=@Description   WHere Serial = @pr";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                sqlCmd.Parameters.AddWithValue("@ArabicName", productModel.ArabicName);
                sqlCmd.Parameters.AddWithValue("@EnglishName", productModel.EnglishName);
                sqlCmd.Parameters.AddWithValue("@DescName", productModel.DescName);
                sqlCmd.Parameters.AddWithValue("@Description", productModel.Notes);
                sqlCmd.ExecuteNonQuery();
                TempData["As"] = "";
            }
        }
        catch
        {
            TempData["A"] = 1;
        }
        return RedirectToAction("DisplaySectors");

    }
    //End Sector
    //Start ConvertBetweenStocks
    public ActionResult ConvertBetweenStocks()
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
        List<SupplierCode> list5 = db.SupplierCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
        List<BranchCode> list7 = db.BranchCode.ToList();
        ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName", 1);
        List<SectorCode> list8 = db.SectorCode.ToList();
        ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName", 1);
        List<UserRole> list9 = db.UserRole.ToList();
        ViewBag.DepartmentList9 = new SelectList(list9, "RoleId", "RoleName");
        return View();
    }
    //End ConvertBetweenStocks

    //Start CashExchange
    public ActionResult CashExchange()
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
        List<SupplierCode> list5 = db.SupplierCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
        List<DealerCode> list6 = db.DealerCode.ToList();
        ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName", 1);
        List<BranchCode> list7 = db.BranchCode.ToList();
        ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName", 1);
        List<SectorCode> list8 = db.SectorCode.ToList();
        ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName", 1);
        List<UserRole> list9 = db.UserRole.ToList();
        ViewBag.DepartmentList9 = new SelectList(list9, "RoleId", "RoleName");
        return View();
    }
    //End CashExchange

    //Start ReceiveCash
    public ActionResult ReceiveCash()
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
        List<SupplierCode> list5 = db.SupplierCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
        List<BranchCode> list7 = db.BranchCode.ToList();
        ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName", 1);
        List<SectorCode> list8 = db.SectorCode.ToList();
        ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName", 1);
        List<UserRole> list9 = db.UserRole.ToList();
        ViewBag.DepartmentList9 = new SelectList(list9, "RoleId", "RoleName");
        List<DealerCode> list6 = db.DealerCode.ToList();
        ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName", 1);
        return View();
    }
    //End ReceiveCash

    //Start Save Safe
    public ActionResult SaveSafe()
    {
        TopSoft db = new TopSoft();
        return View();
    }

    //End Safe

    //Start Save Currency 
    public ActionResult SaveCurrency()
    {
        TopSoft db = new TopSoft();
        return View();
    }
    //End Save Currency 
    //Start AddPermission
    public ActionResult AddPermission()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        List<CustomerCode> list5 = db.CustomerCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName", 1);
        List<DealerCode> list6 = db.DealerCode.ToList();
        ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName", 1); return View();
    }
    [HttpPost]
    public ActionResult AddPermission(HPurchase model)
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
            List<SupplierCode> list5 = db.SupplierCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
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
            invo2.SupplierSerial = model.SupplierSerial;
            invo2.AddUserDate = model.AddUserDate;
            db.HPurchase.Add(invo2);
            db.SaveChanges();
            TempData["Al"] = "";
            int latestEmpId = invo2.Serial;
            return RedirectToAction("AddPermission");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    //End AddPermission
    //Start ExchangePermission
    public ActionResult ExchangePermission()
    {
        TopSoft db = new TopSoft();
        List<UnitCode> list1 = db.UnitCode.ToList();
        ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
        List<StoreCode> list2 = db.StoreCode.ToList();
        ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
        List<GroupCode> list3 = db.GroupCode.ToList();
        ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
        List<ItemCode> list4 = db.ItemCode.ToList();
        ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
        List<CustomerCode> list5 = db.CustomerCode.ToList();
        ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName", 1);
        List<DealerCode> list6 = db.DealerCode.ToList();
        ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName", 1);
        return View();
    }

    [HttpPost]
    public ActionResult ExchangePermission(HSales model)
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
            List<CustomerCode> list5 = db.CustomerCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
            List<DealerCode> list6 = db.DealerCode.ToList();
            ViewBag.DepartmentList6 = new SelectList(list5, "Serial", "ArabicName");
            ViewBag.c = new SelectList(list4, "Serial", "ArabicName");

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
            invo.CustomerSerial = model.CustomerSerial;
            invo.AddUserDate = model.AddUserDate;
            invo.TotalAfterTax = model.TotalAfterTax;
            invo.TaxValue = model.TaxValue;
            invo.AddUserDate = model.AddUserDate;
            db.HSales.Add(invo);
            db.SaveChanges();
            TempData["Al"] = "";
            int latestEmpId = invo.Serial;
            return RedirectToAction("ExchangePermission");
        }

        catch (Exception ex)
        {
            throw ex;

        }
    }
    //End ExchangePermission


}


