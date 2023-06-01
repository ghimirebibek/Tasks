using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProj.Models
{
    public class EmployeeModel
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string joinDate { get; set; }
        public decimal monthlySalary { get; set; }
        public decimal totalSalary { get; set; }
    }
}