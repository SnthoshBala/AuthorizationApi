using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.FiberConnection;
using AuthorizationAPI.Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthorizationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationController));
        private IConfiguration config;
        private readonly IEmployeeAuthProvider<Employee> emp_ap;
        private readonly ICustomerAuthProvider<Customer> cus_ap; 
        private readonly IAdminAuthProvider<Admin> ad_ap;

        public AuthorizationController(IConfiguration config, IEmployeeAuthProvider<Employee> emp_ap, ICustomerAuthProvider<Customer> cus_ap,IAdminAuthProvider<Admin> ad_ap)
        {
            this.config = config;
            this.emp_ap = emp_ap;
            this.cus_ap = cus_ap;
            this.ad_ap = ad_ap;
        }

        [HttpPost]
        [Route("CustomerLogin")]
        public IActionResult Login([FromBody] Customer login)
        {
            _log4net.Info(" Authorization of Token for Customer");
            if (login == null)
            {
                return BadRequest();
            }
            try
            {

                IActionResult response = Unauthorized();
                Customer user = cus_ap.AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = cus_ap.GenerateJSONWebToken(user, config);
                    response = Ok(tokenString);
                }

                return response;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception Occured " + e.Message);
                return StatusCode(500);
            }

        }
        [HttpPost]
        [Route("EmployeeLogin")]
        public IActionResult Login([FromBody] Employee login)
        {

            _log4net.Info(" Authorization of Token for Employee");
            if (login == null)
            {
                return BadRequest();
            }
            try
            {

                IActionResult response = Unauthorized();
                Employee user = emp_ap.AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = emp_ap.GenerateJSONWebToken(user, config);
                    response = Ok(tokenString);

                }

                return response;
            }

            catch (Exception e)
            {
                _log4net.Error("Exception Occured " + e.Message);
                return StatusCode(500);
            }

        }
        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult Login([FromBody] Admin login)
        {
            _log4net.Info(" Authorization of Token for Admin");
            if (login == null)
            {
                return BadRequest();
            }
            try
            {
                IActionResult response = Unauthorized();
                Admin user = ad_ap.AuthenticateUser(login);

                if (user != null)
                {
                    var tokenString = ad_ap.GenerateJSONWebToken(user, config);
                    response = Ok(tokenString);

                }

                return response;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception Occured " + e.Message);
                return StatusCode(500);
            }

        }
        [HttpGet("CheckAuthentication")]
        [Authorize]
        //[AllowAnonymous]
        public IActionResult CheckAuthentication()
        {
            return Ok(true);
        }
    }
}
