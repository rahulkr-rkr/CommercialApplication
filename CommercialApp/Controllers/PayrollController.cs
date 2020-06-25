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
    public class PayrollController : Controller
    {
        // GET: Payroll
        [HttpGet]
        public ActionResult PayrollView(string bname)
        {
            PayrollBusinessLayer payBl = new PayrollBusinessLayer();
            Payroll payModel = payBl.GetPayrolldata(bname);
            return View(payModel);
        }

        [HttpPost]
        //[ActionName("PayrollView")]
        public ActionResult PayrollView()
        {
            try
            {
                ViewData["Message"] = " ";
                PayrollBusinessLayer payBL = new PayrollBusinessLayer();
                Payroll payModel = new Payroll();
                UpdateModel(payModel);
                payBL.InsertPayrollData(payModel.annual_revenue,payModel.no_of_employees,payModel.aggregate_amount,payModel.business_id);
                Session["bid"] = payModel.business_id;
                ViewData["Message"] = "Payroll Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "PayrollInfo",
                    action = "PayrollInfoView",
                    bid = Session["bid"]

                });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                PayrollDataAccess.sqlcon.Close();
                return View();
            }
        }

        public ActionResult PWelcome()
        {
            return View();
        }
    }
}