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
        public string AccountNumber { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public double AccountBalance { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}