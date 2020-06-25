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
    public class LoanController : Controller
    {
        // GET: Loan
        /*public ActionResult LoanView()
        {
            return View();
        }*/
        [HttpGet]
        public ActionResult LoanView(string bid)
        {
            LoanBusinessLayer lBl = new LoanBusinessLayer();
            Loan lModel = lBl.GetLoandata(bid);
            return View(lModel);
        }

        [HttpPost]
        //[ActionName("LoanView")]
        public ActionResult LoanView()
        {
            try
            {
                ViewData["Message"] = " ";
                LoanBusinessLayer lBL = new LoanBusinessLayer();
                Loan lModel = new Loan();
                UpdateModel(lModel);
                lBL.InsertLoanData(lModel.loan_term, lModel.interest_rate, lModel.borrowed_date, lModel.deadline_date, lModel.loan_status, lModel.applicant_id, lModel.business_id);
                //Session["bname"] = buModel.business_name;
                ViewData["Message"] = "Loan Data is submitted Successfully";
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "AccountView",
                    bid = Session["bid"]

                });
               // return RedirectToAction("AccountView", "Account", new { bid = @Session["bid"] });
                //return View(buModel);
            }
            catch
            {
                ViewData["Message"] = "Processing Failed";
                LoanDataAccess.sqlcon.Close();
                return View();
            }
        }
    }
}