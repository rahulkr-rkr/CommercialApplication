using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BeneficiaryDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadBoDetail(string bid)
        {

            string sqlQuery = "select * from BUSINESS where business_id='" + bid + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

        public void InsertBoDetails(string first_name, string last_name, string email, long phone, string role, int business_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Usp_Insert_Beneficiary_Ownership", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@fname", first_name);
            sqlCmd.Parameters.AddWithValue("@lname", last_name);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@phone", phone);
            sqlCmd.Parameters.AddWithValue("@role", role);
            sqlCmd.Parameters.AddWithValue("@business_id", business_id);
            sqlCmd.Parameters.AddWithValue("@Query", 1);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
