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
    public class PayrollInfoBusinessLayer
    {
        public PayrollInfo GetPinfodata(string bid)
        {
            PayrollInfoDataAccess payiDL = new PayrollInfoDataAccess();
            SqlDataReader sdr = payiDL.ReadPinfoDetail(bid);
            PayrollInfo payiModel = new PayrollInfo();
            if (sdr.Read())
            {
                
                payiModel.business_id = Convert.ToInt32(sdr["business_id"]);
                payiModel.annual_payroll = Convert.ToInt32(sdr["annual_payroll"]);
                payiModel.monthly_payroll = Convert.ToInt32(sdr["monthly_payroll"]);
            }
            PayrollInfoDataAccess.sqlcon.Close();
            return payiModel;
        }
    }
}
