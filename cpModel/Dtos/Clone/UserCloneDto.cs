using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cpModel.Models;

namespace cpModel.Dtos.CloneDto
{
    public class UserCloneDto
    {
        public string Address { get; set; }
        public string ApplicationName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string FirstName { get; set; }
        public bool? IsSubscriptionAdmin { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public string Username { get; set; }
        public string Notes { get; set; }
        public bool? InActive { get; set; }
        public int? ProjectId { get; set; }
    }
}
