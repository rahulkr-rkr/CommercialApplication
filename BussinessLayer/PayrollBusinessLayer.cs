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
    public class PayrollBusinessLayer
    {
        public Payroll GetPayrolldata(string bname)
        {
            PayrollDataAccess payDL = new PayrollDataAccess();
            SqlDataReader sdr = payDL.ReadPayrollDetail(bname);
            Payroll payModel = new Payroll();
            if (sdr.Read())
            {
                payModel.business_id = Convert.ToInt32(sdr["business_id"]);
                payModel.annual_revenue = Convert.ToInt32(sdr["annual_revenue"]);
                payModel.no_of_employees = Convert.ToInt32(sdr["number_of_employees"]);
            }
            PayrollDataAccess.sqlcon.Close();
            return payModel;
        }

        public void InsertPayrollData(int annual_revenue, long no_of_employees, int aggregate_amount, int business_id)
        {
            PayrollDataAccess payDA = new PayrollDataAccess();

            payDA.InsertPayrollDetails(annual_revenue,no_of_employees,aggregate_amount,business_id);

        }
    }
}
