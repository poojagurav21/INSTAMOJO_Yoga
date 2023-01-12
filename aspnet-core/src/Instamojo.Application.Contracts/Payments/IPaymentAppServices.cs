using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Instamojo.Payments
{
    public interface IPaymentAppServices:IApplicationService
    {
         Task<string> CreateAsync(CreatePaymentDTO input);
        Task<string> CreatePaymentDetails(PaymentDetailsDTO input);
    }
}
