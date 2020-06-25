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
    public class BeneficiaryBusinessLayer
    {
        public Beneficiary_ownership GetBodata(string bid)
        {
            BeneficiaryDataAccess boDL = new BeneficiaryDataAccess();
            SqlDataReader sdr = boDL.ReadBoDetail(bid);
            Beneficiary_ownership boModel = new Beneficiary_ownership();
            if (sdr.Read())
            {
                boModel.business_id = Convert.ToInt32(sdr["business_id"]);
            }
            BeneficiaryDataAccess.sqlcon.Close();
            return boModel;
        }

        public void InsertBoData(string first_name, string last_name, string email, long phone, string role, int business_id)
        {
            BeneficiaryDataAccess boDA = new BeneficiaryDataAccess();

            boDA.InsertBoDetails(first_name,  last_name,  email,  phone,  role,  business_id);

        }
    }
}
