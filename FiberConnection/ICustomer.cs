using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.FiberConnection
{
    public interface ICustomer<Customer>
    {
        public List<Customer> GetCustomerCredentials();
    }
}
