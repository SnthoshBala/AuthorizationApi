using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using AuthorizationAPI.Repository;

namespace AuthorizationAPI.Service
{
    public class AdminServ:IAdminServ<Admin>
    {
        private readonly IAdminRepo<Admin> repo_a;
        public AdminServ(IAdminRepo<Admin> repo_a)
        {
            this.repo_a = repo_a;
        }
        public List<Admin> GetAdminCredentials()
        {
            return repo_a.GetAdminCredentials();
        }
    }
}
