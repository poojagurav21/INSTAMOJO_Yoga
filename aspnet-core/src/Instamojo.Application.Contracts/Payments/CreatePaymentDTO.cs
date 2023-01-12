using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace Instamojo.Payments
{
    public class CreatePaymentDTO
    {
        [Required]      
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Description { get; set; }
       
        public string PaymentRequest_id { get; set; }


    }
}
