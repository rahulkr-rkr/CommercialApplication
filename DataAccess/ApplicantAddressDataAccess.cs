using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicantAddressDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadAppAddDetail(string aname)
        {

            string sqlQuery = "select * from APPLICANT where first_name='" + aname + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;
        }

        public void InsertAppAddDetails(string street_address, string city, string state, int zipcode, int applicant_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Usp_Insert_Applicant_Address", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@saddress", street_address);
            sqlCmd.Parameters.AddWithValue("@city", city);
            sqlCmd.Parameters.AddWithValue("@state", state);
            sqlCmd.Parameters.AddWithValue("@zipcode", zipcode);
            sqlCmd.Parameters.AddWithValue("@applicant_id", applicant_id);
            sqlCmd.Parameters.AddWithValue("@Query", 1);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
