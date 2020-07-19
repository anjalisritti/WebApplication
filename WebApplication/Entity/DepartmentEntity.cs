using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Entity
{
    public class DepartmentEntity
    {
        public class DepartmentCustom
        {
            public int id { get; set; }
            public string departmentName { get; set; }
            public string departmentDesc { get; set; }
        }
    }
}