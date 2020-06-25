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
    public class LoanBusinessLayer
    {
        public Loan GetLoandata(string bid)
        {
            LoanDataAccess lDL = new LoanDataAccess();
            SqlDataReader sdr = lDL.ReadLoanDetail(bid);
            Loan lModel = new Loan();
            if (sdr.Read())
            {
                lModel.business_id = Convert.ToInt32(sdr["business_id"]);
                lModel.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
            }
            LoanDataAccess.sqlcon.Close();
            return lModel;
        }

        public void InsertLoanData(int loan_term, int interest_rate, string borrowed_date, string deadline_date, string loan_status, int applicant_id, int business_id)
        {
            LoanDataAccess lDA = new LoanDataAccess();

            lDA.InsertLoanDetails(loan_term,interest_rate,borrowed_date,deadline_date,loan_status,applicant_id,business_id);

        }
    }
}
