using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Repository
{
    public interface IAdminRepo<Admin>
    {
        public List<Admin> GetAdminCredentials();
    }
}
