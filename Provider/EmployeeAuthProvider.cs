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
    public class EmployeeAuthProvider:IEmployeeAuthProvider<Employee>
    {
        private readonly IEmployeeServ<Employee> emp_serv;
        public EmployeeAuthProvider(IEmployeeServ<Employee> emp_serv)
        {
            this.emp_serv = emp_serv;
        }
        public string GenerateJSONWebToken(Employee employee_info, IConfiguration _config)
        {
            if (employee_info == null)
                return null;
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public dynamic AuthenticateUser(Employee login)
        {
            if (login == null)
            {
                return null;
            }
            try
            {
                Employee user = null;

                List<Employee> ValidUsers = emp_serv.GetEmployeeCredentials();

                if (ValidUsers == null)
                    return null;
                else
                {
                    if (ValidUsers.Any(u => u.EmployeeMail == login.EmployeeMail && u.EmployeePassword == login.EmployeePassword))
                    {
                        user = new Employee { EmployeeMail = login.EmployeeMail, EmployeePassword = login.EmployeePassword };
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
