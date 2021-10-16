using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;

namespace AuthorizationAPI.Repository
{
    public class CustomerRepo:ICustomerRepo<Customer>
    {
        private readonly ICustomer<Customer> obj_c;
        public CustomerRepo(ICustomer<Customer> obj_c)
        {
            this.obj_c = obj_c;
        }

        public List<Customer> GetCustomerCredentials()
        {
            return obj_c.GetCustomerCredentials();
        }
    }
}
