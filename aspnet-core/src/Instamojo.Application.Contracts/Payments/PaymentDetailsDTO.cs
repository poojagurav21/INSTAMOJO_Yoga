using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Instamojo.Payments
{
    public class PaymentDetailsDTO
    {
        [Required]
        public string PaymentID { get; set; }

        [Required]
        public string PaymentRequestID { get; set; }
       
        
        public string CurrentPaymentStatus { get; set; }
        [Required]
        public double PaymentStatus { get; set; }
      
    }
}
