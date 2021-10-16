using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using Microsoft.Extensions.Configuration;

namespace AuthorizationAPI.Provider
{
    public interface IEmployeeAuthProvider<Employee>
    {
        public string GenerateJSONWebToken(Employee employee_info, IConfiguration _config);
        public dynamic AuthenticateUser(Employee login);
    }
}
