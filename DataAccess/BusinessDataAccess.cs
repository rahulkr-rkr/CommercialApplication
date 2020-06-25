using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BusinessDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadBuDetail(string name)
        {

            string sqlQuery = "select * from APPLICANT where first_name='" + name + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

        public void InsertBuDetails(string business_name, string indsustry_type, int tin, int number_of_employees, string business_entity_type, string date_of_establishment, int turnover_amount, int annual_revenue, int applicant_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("Hrj_Insert_Business", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@bname", business_name);
            sqlCmd.Parameters.AddWithValue("@itype", indsustry_type);
            sqlCmd.Parameters.AddWithValue("@tin", tin);
            sqlCmd.Parameters.AddWithValue("@nofemployees", number_of_employees);
            sqlCmd.Parameters.AddWithValue("@bentity", business_entity_type);
            sqlCmd.Parameters.AddWithValue("@date", date_of_establishment);
            sqlCmd.Parameters.AddWithValue("@tamount", turnover_amount);
            sqlCmd.Parameters.AddWithValue("@annual_revenue", annual_revenue);
            sqlCmd.Parameters.AddWithValue("@applicant_id", applicant_id);
            sqlCmd.Parameters.AddWithValue("@Query", 1);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
