using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace AuthorizationAPI.FiberConnection
{
    public partial class Admin:IAdmin<Admin>
    {
        private readonly fiber_connectionContext fcc = new fiber_connectionContext();
        public int AdminId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public List<Admin> GetAdminCredentials()
        {
            return fcc.Admins.ToList();
        }
    }
}
