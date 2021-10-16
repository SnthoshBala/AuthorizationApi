using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.FiberConnection
{
    public interface IEmployee<Employee>
    {
        public List<Employee> GetEmployeeCredentials();
    }
}
