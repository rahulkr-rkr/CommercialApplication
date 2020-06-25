using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicantDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public void InsertDetails(string first_name, string last_name, string email, long phone, string role, long ssn)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Hrj_InsertUpdateDelete_Applicant", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;


            sqlCmd.Parameters.AddWithValue("@fname", first_name);
            sqlCmd.Parameters.AddWithValue("@lname", last_name);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@phone", phone);
            sqlCmd.Parameters.AddWithValue("@role", role);
            sqlCmd.Parameters.AddWithValue("@ssn", ssn);
            sqlCmd.Parameters.AddWithValue("@Query", 1);

            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
