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
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult AccountView(string bid)
        {
            AccountBusinessLayer accBl = new AccountBusinessLayer();
            AccountModel accModel = accBl.GetAccdata(bid);
            return View(accModel);
        }

        [HttpPost]
        //[ActionName("AccountView")]
        public ActionResult AccountView()
        {
            try
            {
                ViewData["Message"] = " ";
                AccountBusinessLayer accBL = new AccountBusinessLayer();
                AccountModel accModel = new AccountModel();
                UpdateModel(accModel);
                accBL.InsertAccData(accModel.account_number, accModel.bank_name, accModel.account_holder_name, accModel.isfc, accModel.mode_of_transfer, accModel.applicant_id, accModel.loan_id);
                //Session["bname"] = buModel.business_name;
                ViewData["Message"] = "Account Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "Beneficiary",
                    action = "BeneficiaryOwnerView",
                    bid = Session["bid"]

                });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                AccountDataAccess.sqlcon.Close();
                return View();
            }
        }

    }
}