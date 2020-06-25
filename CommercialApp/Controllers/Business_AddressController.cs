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
    public class Business_AddressController : Controller
    {
        // GET: Business_Address
        [HttpGet]
        public ActionResult BAddressView(string bname)
        {
            BusinessAddressBusinessLayer baBl = new BusinessAddressBusinessLayer();
            Business_Address baModel = baBl.Getbadata(bname);
            return View(baModel);
        }

        [HttpPost]
        //[ActionName("BAddressView")]
        public ActionResult BAddressView()
        {
            try
            {
                ViewData["Message"] = " ";
                BusinessAddressBusinessLayer baBL = new BusinessAddressBusinessLayer();
                Business_Address baModel = new Business_Address();
                UpdateModel(baModel);
                baBL.InsertBaData(baModel.street_address,baModel.city,baModel.state,baModel.zipcode, baModel.business_id);
                //Session["bname"] = buModel.business_name;
                ViewData["Message"] = "Business address Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "Applicant_Address",
                    action = "AAddressView",
                    aname = Session["name"]

                });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                BusinessAddressDataAccess.sqlcon.Close();
                return View();
            }
        }

        public ActionResult BAWelcome()
        {
            return View();
        }
    }
}