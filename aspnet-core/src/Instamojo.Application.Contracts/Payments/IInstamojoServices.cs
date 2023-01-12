using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Instamojo.Payments
{
    public interface IInstamojoServices
    {
        Task<string> CreatePaymentRequestInstaMojo(CreatePaymentDTO input,string transactionId);
        Task<string> GetpaymentStatus(string transactionId, string OrderId);
    }
}
