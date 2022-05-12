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
    public class PurchasesController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        // Purchase 

        public ActionResult SaveInvoicePurchase()
        {

            ViewBag.MaxCode = objContext.HPurchase.Max(x => x.Code) + 1;
            List<UnitCode> list1 = objContext.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
            List<StoreCode> list2 = objContext.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
            List<GroupCode> list3 = objContext.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
            List<ItemCode> list4 = objContext.ItemCode.ToList();
            ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
            List<SupplierCode> list5 = objContext.SupplierCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName", 1);
            return View();

        }
        [HttpPost]

        public ActionResult SaveInvoicePurchase(HPurchase model)
        {
            try
            {
                TopSoft db = new TopSoft();
                HPurchase invo2 = new HPurchase();
                List<UnitCode> list1 = objContext.UnitCode.ToList();
                ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
                List<StoreCode> list2 = objContext.StoreCode.ToList();
                ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
                List<GroupCode> list3 = objContext.GroupCode.ToList();
                ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
                List<ItemCode> list4 = objContext.ItemCode.ToList();
                ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
                List<SupplierCode> list5 = objContext.SupplierCode.ToList();
                ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
                invo2.BranchCode = model.BranchCode;
                invo2.Code = model.Code;
                invo2.DealerCode = model.DealerCode;
                invo2.CurrencyCode = model.CurrencyCode;
                invo2.Date = model.Date;
                invo2.Discount = model.Discount;
                invo2.DiscValue = model.DiscValue;
                invo2.Factor = model.Factor;
                invo2.GroupSerial = model.GroupSerial;
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
                objContext.HPurchase.Add(invo2);
                objContext.SaveChanges();
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("select HpurchaseCode,HpurchaseCode2,ItemName,StoreName,UnitName,SupplierName,HpurchaseQuantity,HpurchasePrice,(HpurchaseQuantity*HpurchasePrice) from RptPurchase", sqlCon);
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
        public ActionResult EditInvoicePurchase(int? id)
        {

            TopSoft db = new TopSoft();
            HPurchase invo2 = new HPurchase();
            List<UnitCode> list1 = objContext.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<StoreCode> list2 = objContext.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            List<GroupCode> list3 = objContext.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
            List<ItemCode> list4 = objContext.ItemCode.ToList();
            ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
            List<SupplierCode> list5 = objContext.SupplierCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
            HPurchase productModel = new HPurchase();
            DataTable dtblProduct = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "select Serial,Code,AddUserDate,StoreSerial,GroupSerial,SupplierSerial,ItemSerial,UnitSerial,Quantity,Price,Total from Hpurchase Where Serial=@Serial";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@Serial", id);
                    sqlDa.Fill(dtblProduct);
                }
                if (dtblProduct.Rows.Count == 1)
                {
                    productModel.Serial = Convert.ToInt32(dtblProduct.Rows[0][0].ToString());
                    productModel.Code = Convert.ToInt32(dtblProduct.Rows[0][1].ToString());
                    productModel.AddUserDate = Convert.ToDateTime(dtblProduct.Rows[0][2]);
                    productModel.StoreSerial = Convert.ToInt32(dtblProduct.Rows[0][3].ToString());
                    productModel.GroupSerial = Convert.ToInt32(dtblProduct.Rows[0][4].ToString());
                    productModel.SupplierSerial = Convert.ToInt32(dtblProduct.Rows[0][5].ToString());
                    productModel.ItemSerial = Convert.ToInt32(dtblProduct.Rows[0][6].ToString());
                    productModel.UnitSerial = Convert.ToInt32(dtblProduct.Rows[0][7].ToString());
                    productModel.Quantity = float.Parse(dtblProduct.Rows[0][8].ToString());
                    productModel.Price = float.Parse(dtblProduct.Rows[0][9].ToString());
                    productModel.Total = float.Parse(dtblProduct.Rows[0][10].ToString());

                    TempData["As"] = 1;
                    return View(productModel);
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayInvoicePurchase");

        }
        [HttpPost]

        public ActionResult EditInvoicePurchase(HPurchase productModel)
        {
            TopSoft db = new TopSoft();
            List<UnitCode> list1 = objContext.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<StoreCode> list2 = objContext.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            List<GroupCode> list3 = objContext.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
            List<ItemCode> list4 = objContext.ItemCode.ToList();
            ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
            List<CustomerCode> list5 = objContext.CustomerCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName");
            List<DealerCode> list6 = objContext.DealerCode.ToList();
            ViewBag.DepartmentList6 = new SelectList(list5, "Serial", "ArabicName");
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "Update Hpurchase Set  Code=@Code,AddUserDate=@AddUserDate,StoreSerial=@StoreSerial,ItemSerial=@ItemSerial,UnitSerial=@UnitSerial,Quantity=@Quantity,Price=@Price,Total=@Total,SupplierSerial=@SupplierSerial from Hpurchase WHere Serial = @pr";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@pr", productModel.Serial);
                    sqlCmd.Parameters.AddWithValue("@Code", productModel.Code);
                    sqlCmd.Parameters.AddWithValue("@AddUserDate", productModel.AddUserDate);
                    sqlCmd.Parameters.AddWithValue("@StoreSerial", productModel.StoreSerial);
                    sqlCmd.Parameters.AddWithValue("@ItemSerial", productModel.ItemSerial);
                    sqlCmd.Parameters.AddWithValue("@UnitSerial", productModel.UnitSerial);
                    sqlCmd.Parameters.AddWithValue("@Quantity", productModel.Quantity);
                    sqlCmd.Parameters.AddWithValue("@Price", productModel.Price);
                    sqlCmd.Parameters.AddWithValue("@Total", productModel.Total);
                    sqlCmd.Parameters.AddWithValue("@SupplierSerial", productModel.SupplierSerial);
                    sqlCmd.ExecuteNonQuery();
                    TempData["As"] = "";
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayInvoicePurchase");

        }
        // End Purchase
    }
}