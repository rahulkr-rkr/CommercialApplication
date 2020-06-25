using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class PayrollInfoDataAccess
    {
        public static string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
        public static SqlConnection sqlcon = new SqlConnection(con);

        public SqlDataReader ReadPinfoDetail(string bid)
        {

            string sqlQuery = "select * from PAYROLL where business_id='" + bid + "'";
            sqlcon.Open();
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            return sdr;

        }

    }
}
