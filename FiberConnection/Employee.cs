using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace AuthorizationAPI.FiberConnection
{
    public partial class Employee:IEmployee<Employee>
    {
        private readonly fiber_connectionContext fcc = new fiber_connectionContext();
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string WorkLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeePassword { get; set; }
        public List<Employee> GetEmployeeCredentials()
        {
            return fcc.Employees.ToList();
        }
    }
}
