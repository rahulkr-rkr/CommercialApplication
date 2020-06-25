using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PayrollDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadPayrollDetail(string bname)
        {

            string sqlQuery = "select * from BUSINESS where business_name='" + bname + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

        public void InsertPayrollDetails(int annual_revenue, long no_of_employees, int aggregate_amount, int business_id)
        {
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand("calcul", sqlcon);
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            sqlCmd.Parameters.AddWithValue("@business_id", business_id);
            sqlCmd.Parameters.AddWithValue("@annual_revenue", annual_revenue);
            sqlCmd.Parameters.AddWithValue("@aggregate_amount", aggregate_amount);
            sqlCmd.Parameters.AddWithValue("@no_of_employees", no_of_employees);
            sqlCmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
