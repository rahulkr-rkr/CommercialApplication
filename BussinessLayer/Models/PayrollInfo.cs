using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class PayrollInfo
    {
        [Display(Name = "Annual Payroll")]
        public int annual_payroll { get; set; }
        [Display(Name = "Monthly Payroll")]
        public int monthly_payroll { get; set; }
        [Display(Name = "Business_id")]
        public int business_id { get; set; }
    }
}
