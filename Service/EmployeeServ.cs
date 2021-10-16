using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using AuthorizationAPI.Repository;

namespace AuthorizationAPI.Service
{
    public class EmployeeServ:IEmployeeServ<Employee>
    {
        private readonly IEmployeeRepo<Employee> repo_e;
        public EmployeeServ(IEmployeeRepo<Employee> repo_e)
        {
            this.repo_e = repo_e;
        }

        public List<Employee> GetEmployeeCredentials()
        {
            return repo_e.GetEmployeeCredentials();
        }
    }
}
