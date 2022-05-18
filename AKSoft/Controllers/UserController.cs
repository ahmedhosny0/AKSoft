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
    public class UserController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        public ActionResult AddUser()
        {
            TopSoft db = new TopSoft();
            List<BranchCode> list7 = db.BranchCode.ToList();
            ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName", 1);
            List<SectorCode> list8 = db.SectorCode.ToList();
            ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName", 1);
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
                if (!ModelState.IsValid)
                {
                    return View();
                }


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
            ViewBag.DepartmentList7 = new SelectList(list7, "Serial", "ArabicName", 1);
            List<SectorCode> list8 = db.SectorCode.ToList();
            ViewBag.DepartmentList8 = new SelectList(list8, "Serial", "ArabicName", 1);
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
                            return RedirectToAction("Home", "MainPages");
                        }
                        else if (obj.Role == 2)
                        {
                            return RedirectToAction("User", "MainPages");
                        }
                        else if (obj.Role == 3)
                        {
                            return RedirectToAction("Sales", "MainPages");
                        }
                        else if (obj.Role == 4)
                        {
                            return RedirectToAction("GeneralUser", "MainPages");
                        }
                        else if (obj.Role == 5)
                        {
                            return RedirectToAction("Worker", "MainPages");
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
            return RedirectToAction("login", "User");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "User");
            }
        }
    }
}