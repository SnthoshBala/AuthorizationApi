using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;

namespace AuthorizationAPI.Repository
{
    public class EmployeeRepo:IEmployeeRepo<Employee>
    {
        private readonly IEmployee<Employee> obj_e;
        public EmployeeRepo(IEmployee<Employee> obj_e)
        {
            this.obj_e = obj_e;
        }

        public List<Employee> GetEmployeeCredentials()
        {
            return obj_e.GetEmployeeCredentials();
        }
    }
}
