using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Instamojo.Payments
{
   public class PaymentTransactionDetail : FullAuditedAggregateRoot<Guid>
    {
        [Required]
        public string PaymentID { get; set; }

        [Required]
        public string PaymentRequestID { get; set; }

        [Required]
        public string CurrentPaymentStatus { get; set; }
        [Required]
        public double PaymentStatus { get; set; }
    }
}
