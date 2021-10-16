using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;

namespace AuthorizationAPI.Repository
{
    public class AdminRepo:IAdminRepo<Admin>
    {
        private readonly IAdmin<Admin> obj_a;
        public AdminRepo(IAdmin<Admin> obj_a)
        {
            this.obj_a = obj_a;
        }
        public List<Admin> GetAdminCredentials()
        {
            return obj_a.GetAdminCredentials();
        }
    }
}
