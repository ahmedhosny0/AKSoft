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
    public class ConvertBetweenStocksController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
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

    }
}