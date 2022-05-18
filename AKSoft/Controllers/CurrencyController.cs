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
    public class CurrencyController : Controller
    {
        string connectionString = @"Data Source = .; Initial Catalog = TopSoft; Integrated Security=True";
        TopSoft objContext = new TopSoft();
        //Start Save Currency 
        public ActionResult SaveCurrency()
        {
            TopSoft db = new TopSoft();
            return View();
        }
        //End Save Currency 

    }
}