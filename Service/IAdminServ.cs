using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Service
{
    public interface IAdminServ<Admin>
    {
        public List<Admin> GetAdminCredentials();
    }
}
