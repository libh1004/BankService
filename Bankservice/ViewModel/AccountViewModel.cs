using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bankservice.ViewModel
{
    [DataContract]
    public class AccountViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public double AccountBalance { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public DateTime? CreatedAt { get; set; }
        [DataMember]
        public DateTime? UpdatedAt { get; set; }
    }
}