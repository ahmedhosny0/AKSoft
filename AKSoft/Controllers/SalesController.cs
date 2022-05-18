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
    public class SalesController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult SaveInvoiceSales()
        {
            ViewBag.MaxCode = objContext.HSales.Max(x => x.Code) + 1;
            List<UnitCode> list1 = objContext.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName", 1);
            List<StoreCode> list2 = objContext.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName", 1);
            List<GroupCode> list3 = objContext.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName", 1);
            List<ItemCode> list4 = objContext.ItemCode.ToList();
            ViewBag.DepartmentList4 = new SelectList(list4, "Serial", "ArabicName");
            List<CustomerCode> list5 = objContext.CustomerCode.ToList();
            ViewBag.DepartmentList5 = new SelectList(list5, "Serial", "ArabicName", 1);
            List<DealerCode> list6 = objContext.DealerCode.ToList();
            ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName", 2);
            return View();

        }
        [HttpPost]
        public ActionResult SaveInvoiceSales(HSales model)
        {
            try
            {
                HSales invo = new HSales();
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
                ViewBag.c = new SelectList(list4, "Serial", "ArabicName");
                int latestEmpId = 0;
                invo.BranchCode = model.BranchCode;
                invo.Serial = model.Serial; 
                invo.Code = model.Code;
                invo.DealerCode = model.DealerCode;
                invo.CurrencyCode = model.CurrencyCode;
                invo.Date = model.Date;
                invo.Discount = model.Discount;
                invo.DiscValue = model.DiscValue;
                invo.Factor = model.Factor;
                invo.FirstPayment = model.FirstPayment;
                invo.GroupSerial = model.GroupSerial;
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
                objContext.HSales.Add(invo);
                objContext.SaveChanges();
                TempData["Al"] = "";
                latestEmpId = invo.Serial;
                return RedirectToAction("Report1.aspx", "Reports", new { area = "" });

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
                SqlDataAdapter sqlDa = new SqlDataAdapter("select hsalesCode,hsalesCode2,ItemName,StoreName,UnitName,CustomerName,HsalesQuantity,HSalesPrice,(HsalesQuantity*HSalesPrice) from RptSales", sqlCon);
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
        public ActionResult EditInvoiceSales(int? id)
        {


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
            ViewBag.DepartmentList6 = new SelectList(list6, "Serial", "ArabicName");
            HSales productModel = new HSales();
            DataTable dtblProduct = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "select Serial,Code,AddUserDate,StoreSerial,GroupSerial,CustomerSerial,ItemSerial,UnitSerial,DealerCode,Quantity,Price,Total from hsales Where Serial=@Serial";
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
                    productModel.CustomerSerial = Convert.ToInt32(dtblProduct.Rows[0][5].ToString());
                    productModel.ItemSerial = Convert.ToInt32(dtblProduct.Rows[0][6].ToString());
                    productModel.UnitSerial = Convert.ToInt32(dtblProduct.Rows[0][7].ToString());
                    productModel.DealerCode = Convert.ToInt32(dtblProduct.Rows[0][8].ToString());
                    productModel.Quantity = float.Parse(dtblProduct.Rows[0][9].ToString());
                    productModel.Price = float.Parse(dtblProduct.Rows[0][10].ToString());
                    productModel.Total = float.Parse(dtblProduct.Rows[0][10].ToString());

                    TempData["As"] = 1;
                    return View(productModel);

                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayInvoiceSales");

        }
        [HttpPost]

        public ActionResult EditInvoiceSales(HSales productModel)
        {

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

                    string query = "Update Hsales Set  Code=@Code,AddUserDate=@AddUserDate,StoreSerial=@StoreSerial,ItemSerial=@ItemSerial,UnitSerial=@UnitSerial,Quantity=@Quantity,Price=@Price,Total=@Total,CustomerSerial=@CustomerSerial,DealerCode=@DealerCode from hsales WHere Serial = @pr";
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
                    sqlCmd.Parameters.AddWithValue("@CustomerSerial", productModel.CustomerSerial);
                    sqlCmd.Parameters.AddWithValue("@DealerCode", productModel.DealerCode);
                    sqlCmd.ExecuteNonQuery();
                    TempData["As"] = "";
                }
            }
            catch
            {
                TempData["A"] = 1;
            }
            return RedirectToAction("DisplayInvoiceSales");

        }
    }
}