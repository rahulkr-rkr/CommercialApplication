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
    public class AccountBusinessLayer
    {
        public AccountModel GetAccdata(string bid)
        {
            AccountDataAccess accDL = new AccountDataAccess();
            SqlDataReader sdr = accDL.ReadAccDetail(bid);
            AccountModel accModel = new AccountModel();
            if (sdr.Read())
            {
                accModel.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
                accModel.loan_id = Convert.ToInt32(sdr["loan_id"]);
            }
            AccountDataAccess.sqlcon.Close();
            return accModel;
        }

        public void InsertAccData(string account_number, string bank_name, string account_holder_name, string isfc, string mode_of_transfer, int applicant_id, int loan_id)
        {
            AccountDataAccess accDA = new AccountDataAccess();

            accDA.InsertAccDetails(account_number,  bank_name,  account_holder_name,  isfc,  mode_of_transfer,  applicant_id,  loan_id);

        }
    }
}
