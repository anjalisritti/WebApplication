using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Entity
{
    public class EmployeeEntity
    {
        public class EmployeeCustom
        {
            public int id { get; set; }
            public string employeeName { get; set; }
            public string employeeNo { get; set; }
            public int departmentId { get; set; }
            public string salary { get; set; }
            public string joiningDate { get; set; }
            
        }

        public class EmployeeDetails
        {
            public int id { get; set; }
            public string employeeName { get; set; }
            public string employeeNo { get; set; }
            public int departmentId { get; set; }
            public string salary { get; set; }
            public string joiningDate { get; set; }
            public string departmentName { get; set; }
        }
    }

    
}