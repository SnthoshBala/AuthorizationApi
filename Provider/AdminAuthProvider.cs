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
    public class AdminAuthProvider: IAdminAuthProvider<Admin>
    {
        private readonly IAdminServ<Admin> ap_serv;
        public AdminAuthProvider(IAdminServ<Admin> ap_serv)
        {
            this.ap_serv = ap_serv;
        }
        public string GenerateJSONWebToken(Admin admin_info, IConfiguration _config)
        {
            if (admin_info == null)
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
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public dynamic AuthenticateUser(Admin login)
        {
            if (login == null)
            {
                return null;
            }
            try
            {
                Admin user = null;

                List<Admin> ValidUsers = ap_serv.GetAdminCredentials();

                if (ValidUsers == null)
                    return null;
                else
                {
                    if (ValidUsers.Any(u => u.AdminUserName == login.AdminUserName && u.AdminPassword == login.AdminPassword))
                    {
                        user = new Admin {AdminUserName=login.AdminUserName , AdminPassword=login.AdminPassword};
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
