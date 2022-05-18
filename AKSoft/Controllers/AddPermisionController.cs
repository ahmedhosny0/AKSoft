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
    public class AddPermisionController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
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
    }
}