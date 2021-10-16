using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.FiberConnection
{
    public interface IAdmin<Admin>
    {
        public List<Admin> GetAdminCredentials();
    }
}
