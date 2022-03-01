using AKSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKSoft.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
public ActionResult AddOrder()
        {
            return View();
        }
        /*
        [HttpPost]
        public JsonResult AddOrderAndOrderDetials(UnitCode orderViewModel)
        {
            bool status = true;

            var isValidModel = TryUpdateModel(orderViewModel);

            if (isValidModel)
            {
                using (TopSoft db = new TopSoft())
                {
                    UnitCode order = new UnitCode()
                    {
                        AddUserDate = orderViewModel.AddUserDate
                    };
                    db.UnitCode.Add(order);

                    if (db.SaveChanges() > 0)
                    {
                        int orderID = db.UnitCode.Max(o => o.Serial);

                        foreach (var item in orderViewModel)
                        {
                            UnitCode orderDetails = new UnitCode()
                            {
                                Serial = orderID,
                                ArabicName = item.ArabicName,
                                EnglishName = item.EnglishName,
                                DescName = item.DescName,
                                Description = item.Description
                            };
                            db.UnitCode.Add(orderDetails);
                        }

                        if (db.SaveChanges() > 0)
                        {
                            return new JsonResult { Data = new { status = status, message = "Order Added Successfully" } };
                        }
                    }
                }
            }

            status = false;
            return new JsonResult { Data = new { status = status, message = "Error !" } };
        }
              public ActionResult SaveUnit()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SaveUnit(UnitCode model, string name)
        {

            try
            {
                //foreach (var item in UnitCode.cou)
                //            {
                //                OrderDetails orderDetails = new OrderDetails() {
                //                    OrderID = orderID,
                //                    ProductID = item.ProductID,
                //                    Price = item.Price,
                //                    Quantity = item.Quantity,
                //                    TotalPrice = item.TotalPrice
                //                };
                TopSoft db = new TopSoft();
                UnitCode unit = new UnitCode();
                unit.ArabicName = model.ArabicName;
                unit.EnglishName = model.EnglishName;
                unit.DescName = model.DescName;
                unit.Description = model.Description;
                unit.ID = model.ID;
                unit.Code = model.Code;
                unit.AddUserDate = model.AddUserDate;
                db.UnitCode.Add(unit);
                db.SaveChanges();
                int latestEmpId = unit.Serial;

                TempData["Al"] = unit.ArabicName;
                return View();

            }

            catch (Exception ex)
            {
                throw ex;

            }
        }*/
    }
}