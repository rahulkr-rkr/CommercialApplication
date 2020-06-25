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
    public class BeneficiaryController : Controller
    {
        // GET: Beneficiary
        [HttpGet]
        public ActionResult BeneficiaryOwnerView(string bid)
        {
            BeneficiaryBusinessLayer boBl = new BeneficiaryBusinessLayer();
            Beneficiary_ownership boModel = boBl.GetBodata(bid);
            return View(boModel);
        }

        [HttpPost]
        //[ActionName("BeneficiaryOwnerView")]
        public ActionResult BeneficiaryOwnerView()
        {
            try
            {
                ViewData["Message"] = " ";
                BeneficiaryBusinessLayer boBL = new BeneficiaryBusinessLayer();
                Beneficiary_ownership boModel = new Beneficiary_ownership();
                UpdateModel(boModel);
                boBL.InsertBoData(boModel.first_name, boModel.last_name, boModel.email, boModel.phone, boModel.role, boModel.business_id);
                //Session["bname"] = buModel.business_name;
                ViewData["Message"] = "BeneficiaryOwner  Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "Summary",
                    action = "SummaryView",
                    bid = Session["bid"]

                });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                BeneficiaryDataAccess.sqlcon.Close();
                return View();
            }
        }

    }
}