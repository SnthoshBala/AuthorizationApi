using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using Microsoft.Extensions.Configuration;

namespace AuthorizationAPI.Provider
{
    public interface IAdminAuthProvider<Admin>
    {
        public string GenerateJSONWebToken(Admin admin_info, IConfiguration _config);
        public dynamic AuthenticateUser(Admin login);
    }
}
