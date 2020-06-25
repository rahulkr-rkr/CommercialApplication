using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer.Models;
using BussinessLayer;
using DataAccess;


namespace CommercialApp.Controllers
{
    public class PayrollInfoController : Controller
    {
        // GET: PayrollInfo
        [HttpGet]
        public ActionResult PayrollInfoView(string bid)
        {
            PayrollInfoBusinessLayer payiBl = new PayrollInfoBusinessLayer();
            PayrollInfo payiModel = payiBl.GetPinfodata(bid);
            return View(payiModel);
        }
        [HttpPost]
        public ActionResult PayrollInfoView()
        {
            //return RedirectToAction("LoanView", "Loan", new { bid = @Session["b_id"] });
            return RedirectToRoute(new
            {
                controller = "Loan",
                action = "LoanView",
                bid = Session["bid"]
            });
        }
    }
}