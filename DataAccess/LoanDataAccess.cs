using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LoanDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadLoanDetail(string bid)
        {

            string sqlQuery = "select * from BUSINESS where business_id='" + bid + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

        public void InsertLoanDetails(int loan_term, int interest_rate, string borrowed_date, string deadline_date, string loan_status, int applicant_id, int business_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Usp_Insert_loan", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
           
            sqlCmd.Parameters.AddWithValue("@term", loan_term);
            sqlCmd.Parameters.AddWithValue("@rate", interest_rate);
            sqlCmd.Parameters.AddWithValue("@bdate", borrowed_date);
            sqlCmd.Parameters.AddWithValue("@ddate", deadline_date);
            sqlCmd.Parameters.AddWithValue("@status", loan_status);
            sqlCmd.Parameters.AddWithValue("@applicant_id", applicant_id);
            sqlCmd.Parameters.AddWithValue("@business_id", business_id);
            sqlCmd.Parameters.AddWithValue("@Query", 1);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
