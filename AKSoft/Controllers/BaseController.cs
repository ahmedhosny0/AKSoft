using AKSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKSoft.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        TopSoft objContext = new TopSoft();
    }
}