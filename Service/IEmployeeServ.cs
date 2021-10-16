using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Service
{
    public interface IEmployeeServ<Employee>
    {
        public List<Employee> GetEmployeeCredentials();
    }
}
