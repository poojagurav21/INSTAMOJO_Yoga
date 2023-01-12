using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Instamojo.Payments.Instamojo
{
    public interface IinstamojoHttpClient
    {
        Task<string> CreatePaymentRequest(PaymentRequest input);
        Task<string> GetPaymentStatus(string paymentId);
    }
}
