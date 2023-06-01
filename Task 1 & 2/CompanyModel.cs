using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProj.Models
{
    public class CompanyModel
    {
        public class Company
        {
            public int companyID { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
        }

        public class Branch
        {
            public int branchID { get; set; }
            public string name { get; set; }
            public string address { get; set; }
        }

        public class CompanyDetails
        {
            public Company company { get; set; }
            public List<Branch> branches { get; set; }
            public string teamSize { get; set; }
            public string projects { get; set; }
            public string happyClients { get; set; }
        }
    }
}