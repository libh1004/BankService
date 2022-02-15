using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Bankservice.ViewModel
{
    [DataContract]
    public class TransactionViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public double Fee { get; set; }
        [DataMember]
        public string SenderCode { get; set; }
        [DataMember]
        public string ReceiverCode { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
        [DataMember]
        public DateTime DeletedAt { get; set; }
    }
}