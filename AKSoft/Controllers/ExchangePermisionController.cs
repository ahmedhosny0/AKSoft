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
    public class ExchangePermisionController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
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
}