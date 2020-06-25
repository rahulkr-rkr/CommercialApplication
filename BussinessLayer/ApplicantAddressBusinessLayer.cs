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
    public class ApplicantAddressBusinessLayer
    {
        public Applicant_Address GetAppAdddata(string aname)
        {
            ApplicantAddressDataAccess aaDL = new ApplicantAddressDataAccess();
            SqlDataReader sdr = aaDL.ReadAppAddDetail(aname);
            Applicant_Address aaModel = new Applicant_Address();
            if (sdr.Read())
            {
                aaModel.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
                aaModel.role = Convert.ToString(sdr["role"]);
                aaModel.ssn = Convert.ToInt32(sdr["ssn"]);
            }
            ApplicantAddressDataAccess.sqlcon.Close();
            return aaModel;
        }

        public void InsertAppAddData(string street_address, string city, string state, int zipcode, int applicant_id)
        {
            ApplicantAddressDataAccess aaDA = new ApplicantAddressDataAccess();

            aaDA.InsertAppAddDetails(street_address, city, state, zipcode, applicant_id);

        }
    }
}
