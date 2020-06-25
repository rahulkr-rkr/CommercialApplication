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
    public class BusinessAddressBusinessLayer
    {
        public Business_Address Getbadata(string bname)
        {
            BusinessAddressDataAccess baDL = new BusinessAddressDataAccess();
            SqlDataReader sdr = baDL.ReadBuAddDetail(bname);
            Business_Address baModel = new Business_Address();
            if (sdr.Read())
            {
                baModel.business_id = Convert.ToInt32(sdr["business_id"]);
            }
            BusinessAddressDataAccess.sqlcon.Close();
            return baModel;
        }

        public void InsertBaData(string street_address, string city, string state, int zipcode, int business_id)
        {
            BusinessAddressDataAccess baDA = new BusinessAddressDataAccess();

            baDA.InsertBuAddDetails(street_address,city,state,zipcode,business_id);

        }
    }
}
