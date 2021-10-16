using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace AuthorizationAPI.FiberConnection
{
    public partial class Customer:ICustomer<Customer>
    {
        private readonly fiber_connectionContext fcc = new fiber_connectionContext();
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAadharNo { get; set; }
        public string CustomerMailId { get; set; }
        public string CustomerPassword { get; set; }
        public List<Customer> GetCustomerCredentials()
        {
            return fcc.Customers.ToList();
        }
    }
}
