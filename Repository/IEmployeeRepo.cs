using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    public interface IEmployeeRepo<Employee>
    {
        public List<Employee> GetEmployeeCredentials();
     }
}
