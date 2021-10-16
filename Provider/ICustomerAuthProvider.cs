using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using Microsoft.Extensions.Configuration;

namespace AuthorizationAPI.Provider
{
    public interface ICustomerAuthProvider<Customer>
    {
        public string GenerateJSONWebToken(Customer customer_info, IConfiguration _config);
        public dynamic AuthenticateUser(Customer login);
    }
}
