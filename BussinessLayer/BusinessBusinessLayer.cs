using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data.SqlClient;
using System.Security.Authentication;

namespace BussinessLayer
{
    public class BusinessBusinessLayer
    {
        public Business Getdata(string name)
        {
            BusinessDataAccess buDL = new BusinessDataAccess();
            SqlDataReader sdr = buDL.ReadBuDetail(name);
            Business buModel = new Business();
            if (sdr.Read())
            {
                buModel.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
            }
            BusinessDataAccess.sqlcon.Close();
            return buModel;
        }

        public void InsertBuData(string business_name, string indsustry_type, int tin, int number_of_employees, string business_entity_type, string date_of_establishment, int turnover_amount, int annual_revenue, int applicant_id)
        {
            BusinessDataAccess buDA = new BusinessDataAccess();

            buDA.InsertBuDetails(business_name, indsustry_type, tin, number_of_employees, business_entity_type, date_of_establishment, turnover_amount, annual_revenue, applicant_id);

        }
    }
}
