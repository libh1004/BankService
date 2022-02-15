using Bankservice.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Bankservice
{
    [ServiceContract]
   public interface IService
    {
        [OperationContract]
        bool Register(Account account);
        [OperationContract]
        bool Login(string phone, string password);
        [OperationContract]
        bool Logout();
        [OperationContract]
        double Deposit(double amount);
        [OperationContract]
        double Withdrawal(double amount);
        //[OperationContract]
        //double Tranfer(double amount, string senderCode, string receiverCode);
        //[OperationContract]
        //Transaction TransactionHistory();
    }
}
