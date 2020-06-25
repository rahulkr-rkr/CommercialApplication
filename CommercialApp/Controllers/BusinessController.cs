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
    public class BusinessController : Controller
    {

        [HttpGet]
        public ActionResult BusinessView(string name)
        {
            BusinessBusinessLayer buBl = new BusinessBusinessLayer();
            Business buModel = buBl.Getdata(name);
            return View(buModel);
        }

        [HttpPost]
        //[ActionName("BusinessView")]
        public ActionResult BusinessView()
        {
            try
            {
                ViewData["Message"] = " ";
                BusinessBusinessLayer buBL = new BusinessBusinessLayer();
                Business buModel = new Business();
                UpdateModel(buModel);
                buBL.InsertBuData(buModel.business_name, buModel.indsustry_type, buModel.tin, buModel.number_of_employees, buModel.business_entity_type, buModel.date_of_establishment, buModel.turnover_amount, buModel.annual_revenue, buModel.applicant_id);
                Session["bname"] = buModel.business_name;
                ViewData["Message"] = "Business Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "Business_Address",
                    action = "BAddressView",
                    bname = Session["bname"]

                });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                ApplicantDataAccess.sqlcon.Close();
                return View();
            }
        }

        public ActionResult BWelcome()
        {
            return View();
        }
    }
}