using AKSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AKSoft
{
    public class ProductController : Controller
    {
        // GET: Test
        public ActionResult SaveProduct()
        {
            TopSoft db = new TopSoft();
            List<UnitCode> list1 = db.UnitCode.ToList();
            ViewBag.DepartmentList1 = new SelectList(list1, "Serial", "ArabicName");
            List<StoreCode> list2 = db.StoreCode.ToList();
            ViewBag.DepartmentList2 = new SelectList(list2, "Serial", "ArabicName");
            List<GroupCode> list3 = db.GroupCode.ToList();
            ViewBag.DepartmentList3 = new SelectList(list3, "Serial", "ArabicName");
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

                ItemCode emp = new ItemCode();
                emp.StoreID = model.StoreID;
                emp.Unit1 = model.Unit1;
                emp.GroupCode = model.GroupCode;
                emp.ArabicName = model.ArabicName;
                emp.EnglishName = model.EnglishName;
                db.ItemCode.Add(emp);
                db.SaveChanges();
                int latestEmpId = emp.Serial;
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}