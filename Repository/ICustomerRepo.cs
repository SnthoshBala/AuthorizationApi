using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    public interface ICustomerRepo<Customer>
    {
        public List<Customer> GetCustomerCredentials();
    }
}
