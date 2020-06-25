using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialApp.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CommercialApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login lc)
        {
            string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string query = "Select email,password from APPLICANT where email=@email and password=@password";
            sqlcon.Open();
            SqlCommand sqlcomm = new SqlCommand(query, sqlcon);
            sqlcomm.Parameters.AddWithValue("@email", lc.useremail);
            sqlcomm.Parameters.AddWithValue("@password", lc.password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                Session["useremail"] = lc.useremail.ToString();
                //return RedirectToAction("welcome");
                return RedirectToAction("ApplicantView","Applicant");

            }
            else
            {
                ViewData["Message"] = "user login failed";
            }
            sqlcon.Close();

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}