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
    public class Applicant_AddressController : Controller
    {
        // GET: Applicant_Address
        [HttpGet]
        public ActionResult AAddressView(string aname)
        {
            ApplicantAddressBusinessLayer aaBl = new ApplicantAddressBusinessLayer();
            Applicant_Address aaModel = aaBl.GetAppAdddata(aname);
            return View(aaModel);
        }


        [HttpPost]
        //[ActionName("AAddressView")]
        public ActionResult AAddressView()
        {
            try
            {
                ViewData["Message"] = " ";
                ApplicantAddressBusinessLayer aaBL = new ApplicantAddressBusinessLayer();
                Applicant_Address aaModel = new Applicant_Address();
                UpdateModel(aaModel);
                aaBL.InsertAppAddData(aaModel.street_address, aaModel.city, aaModel.state, aaModel.zipcode, aaModel.applicant_id);
                //Session["bname"] = buModel.business_name;
                ViewData["Message"] = "Applicant Address Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "Payroll",
                    action = "PayrollView",
                    bname = Session["bname"]

                });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                ApplicantAddressDataAccess.sqlcon.Close();
                return View();
            }
        }


        public ActionResult AWelcome()
        {
            return View();
        }
    }
}