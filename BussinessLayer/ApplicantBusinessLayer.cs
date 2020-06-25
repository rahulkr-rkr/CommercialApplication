using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BussinessLayer.Models;
using System.Data;

namespace BussinessLayer
{
    public class ApplicantBusinessLayer
    {
        public void InsertAppData(string first_name, string last_name, string email, long phone, string role, long ssn)
        {
            ApplicantDataAccess appDA = new ApplicantDataAccess();

            appDA.InsertDetails(first_name, last_name, email, phone, role, ssn);

        }
    }
}
