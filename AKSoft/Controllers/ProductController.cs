using AKSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKSoft.Controllers
{
    public class ProductController : Controller
    {
       //  GET: Test
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
        public ActionResult SaveInvoicSales()
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
                return RedirectToAction("SaveStock");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
        public ActionResult SaveUnit()
        {
            return View();

        }
        [HttpPost]

        public ActionResult SaveUnit(UnitCode model,string name)
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
                ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:{1}", name, DateTime.Now.ToString());  
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
                int latestEmpId = group.Serial;
                return RedirectToAction("SaveGroup");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpPost]

        public ActionResult SaveInvoicSales(HSales model)
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
                List<GroupCode> list4 = db.GroupCode.ToList();
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
                int latestEmpId = invo.Serial;
                return RedirectToAction("SaveInvoicSales");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}