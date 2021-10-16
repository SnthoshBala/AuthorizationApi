using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using AuthorizationAPI.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizationAPI.Provider
{
    public class CustomerAuthProvider:ICustomerAuthProvider<Customer>
    {
        private readonly ICustomerServ<Customer> cus_serv;
        public CustomerAuthProvider(ICustomerServ<Customer> cus_serv)
        {
            this.cus_serv = cus_serv;
        }
        public string GenerateJSONWebToken(Customer customer_info, IConfiguration _config)
        {
            if (customer_info == null)
                return null;
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public dynamic AuthenticateUser(Customer login)
        {
            if (login == null)
            {
                return null;
            }
            try
            {
                Customer user = null;

                List<Customer> ValidUsers = cus_serv.GetCustomerCredentials();

                if (ValidUsers == null)
                    return null;
                else
                {
                    if (ValidUsers.Any(u => u.CustomerMailId == login.CustomerMailId && u.CustomerPassword == login.CustomerPassword))
                    {
                        user = new Customer { CustomerMailId = login.CustomerMailId, CustomerPassword = login.CustomerPassword };
                    }
                }

                return user;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
