using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BusinessAddressDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadBuAddDetail(string bname)
        {

            string sqlQuery = "select * from BUSINESS where business_name='" + bname + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;
        }

        public void InsertBuAddDetails(string street_address, string city, string state, int zipcode, int business_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Usp_Insert_Business_Address", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            sqlCmd.Parameters.AddWithValue("@saddress",street_address);
            sqlCmd.Parameters.AddWithValue("@city", city);
            sqlCmd.Parameters.AddWithValue("@state",state);
            sqlCmd.Parameters.AddWithValue("@zipcode", zipcode);
            sqlCmd.Parameters.AddWithValue("@business_id", business_id);
            sqlCmd.Parameters.AddWithValue("@Query", 1);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
