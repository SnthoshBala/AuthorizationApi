using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using AuthorizationAPI.Repository;

namespace AuthorizationAPI.Service
{
    public class CustomerServ:ICustomerServ<Customer>
    {
        private readonly ICustomerRepo<Customer> repo_c;
        public CustomerServ(ICustomerRepo<Customer> repo_c)
        {
            this.repo_c = repo_c;
        }

        public List<Customer> GetCustomerCredentials()
        {
            return repo_c.GetCustomerCredentials();
        }
    }
}
