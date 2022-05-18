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

    public class MainPagesController : Controller
    {
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

        //  GET: Test
        public ActionResult Start()
        {
            return View();
        }
    }
