using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLayer;
using BussinessLayer.Models;
using DataAccess;


namespace CommercialApp.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult ApplicantView()
        {
            return View();
        }


        [HttpPost]
        [ActionName("ApplicantView")]
        public ActionResult ApplicantView_post()
        {
            try
            {
                ViewData["Message"] = " ";
                ApplicantBusinessLayer appBL = new ApplicantBusinessLayer();
                Applicant appModel = new Applicant();
                UpdateModel(appModel);
                appBL.InsertAppData(appModel.first_name, appModel.last_name, appModel.email, appModel.phone, appModel.role, appModel.ssn);
                Session["name"] = appModel.first_name;
                ViewData["Message"] = "Applicant Data is submitted Successfully";
                return RedirectToRoute(new
                {
                 controller = "Business",
                 action = "BusinessView",
                 name = Session["name"]

                 });
                //return View(appModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                ApplicantDataAccess.sqlcon.Close();
                return View();
            }

        }

        /*
        [HttpPost]
        public ActionResult ApplicantView(Applicant applicant)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DA_Applicant objDB = new DA_Applicant();
                string result = objDB.InsertApplicantData(applicant);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                //return View();
                return RedirectToAction("BusinessView", "Business", new { name = @Session["first_name"] });
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
        */

        public ActionResult Welcome()
        {
            return View();
        }
    }
}