using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadAccDetail(string bid)
        {
            string sqlQuery = "select * from LOAN where business_id='" + bid + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;
        }

        public void InsertAccDetails(string account_number, string bank_name, string account_holder_name, string isfc, string mode_of_transfer, int applicant_id, int loan_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Usp_Insert_Account", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            sqlCmd.Parameters.AddWithValue("@acc_no", account_number);
            sqlCmd.Parameters.AddWithValue("@bname", bank_name);
            sqlCmd.Parameters.AddWithValue("@ahname", account_holder_name);
            sqlCmd.Parameters.AddWithValue("@ifsc", isfc);
            sqlCmd.Parameters.AddWithValue("@mtransfer", mode_of_transfer);
            sqlCmd.Parameters.AddWithValue("@applicant_id", applicant_id);
            sqlCmd.Parameters.AddWithValue("@loan_id", loan_id);
            sqlCmd.Parameters.AddWithValue("@Query", 1);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
