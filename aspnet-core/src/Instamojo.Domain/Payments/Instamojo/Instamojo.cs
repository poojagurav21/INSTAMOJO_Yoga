using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Instamojo.Payments.Instamojo
{
    public class InstamojoConfig: ITransientDependency
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
    public class AuthenticationResponse
    {
        public string access_token { get; set; }
    }

    public class PaymentReq:ITransientDependency
    {
        public string purpose { get; set; }
        public string amount { get; set; }
        public string buyer_name { get; set; }

        public string email { get; set; }
        public string phone { get; set; }
        public string redirect_url { get; set; }
        public string webhook { get; set; }
        public string allow_repeated_payments { get; set; }
        


    }

    public class CreatePaymentResponse
    {
        public string id { get; set; }
        public string email { get; set; }
        public string longurl { get; set; }
    }
    public class CreatePaymentResponses
    {
        public string id { get; set; }
        
    }
    public class PaymentStatus
    {
        public bool status { get; set; }
    }
}
