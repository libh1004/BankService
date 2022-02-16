using Bankservice.Entity;
using Bankservice.ViewModel;
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
        bool Register(AccountViewModel account);
        [OperationContract]
        bool Login(string phone, string password);
        [OperationContract]
        bool Logout();
        [OperationContract]
        double Deposit(double amount);
        [OperationContract]
        double Withdrawal(double amount);
        [OperationContract]
        Transaction Transfer(Transaction transaction);
        //[OperationContract]
        //Transaction TransactionHistory();
    }
}
