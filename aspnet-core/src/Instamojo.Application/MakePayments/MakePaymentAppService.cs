using Instamojo;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instamojo.Razorepay;

namespace Instamojo.MakePayments
{
    public class MakePaymentAppService : InstamojoAppService
    {
        private const string _key = "rzp_test_cIXg6NZobtdLs6";
        private const string _secret = "BGb4WKQ1ErVBpv69dw20Nv7s";
        RazorpayClient client;

        public MakePaymentAppService()
        {
            client = new RazorpayClient(_key, _secret);
        }
        public RazorPayOptionsModel GetPayment(ProgramDetailDto programDetailsDto)
        {
            OrderModel order = new OrderModel()
            {
                OrderAmount = programDetailsDto.TotalFee,
                Currency = "INR",
                Payment_Capture = 1,    // 0 - Manual capture, 1 - Auto capture
                Notes = new Dictionary<string, string>()
                {
                    { "note 1", "first note while creating order" }, { "note 2", "you can add max 15 notes" },
                    { "note for account 1", "this is a linked note for account 1" }, { "note 2 for second transfer", "it's another note for 2nd account" }
                }
            };
            var orderId = CreateOrder(order);
            RazorPayOptionsModel razorPayOptions = new RazorPayOptionsModel()
            {
                Key = _key,
                AmountInSubUnits = order.OrderAmountInSubUnits,
                Currency = order.Currency,
                Name = order.Name,
                Description = "for Dotnet",
                ImageLogUrl = "",
                OrderId = orderId,

                //ProfileName = registration.Name,
                //ProfileContact = registration.Mobile,
                //ProfileEmail = registration.Email,
                Notes = new Dictionary<string, string>()
                {
                    { "note 1", "this is a payment note" }, { "note 2", "here also, you can add max 15 notes" }
                }
            };
            return razorPayOptions;
        }
        public string CreateOrder(OrderModel order)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(_key, _secret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", order.OrderAmountInSubUnits);
                options.Add("currency", order.Currency);
                options.Add("payment_capture", order.Payment_Capture);
                options.Add("notes", order.Notes);
                options.Add("receipt", "recpt_442244sqw5");

                var abc = client.Payment.All();
                Order orderResponse = client.Order.Create(options);
                var orderId = orderResponse.Attributes["id"].ToString();
                return orderId;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Paymentdetails AllPayment()
        {
            try
            {
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("count", 50);
                options.Add("skip", 0);
                RazorpayClient client = new RazorpayClient(_key, _secret);
                List<Payment> result = client.Payment.All(options);
                var abc = new List<Items>();
                result.ForEach(x => abc.Add(ObjectExtensions.ToObject<Items>(x.Attributes)));

                return new Paymentdetails { count = result.Count(), items = abc };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RefundReSopnce FullRefund(string paymentId)
        {
            Payment payment = client.Payment.Fetch(paymentId);
            Refund refund = payment.Refund();
            return ObjectExtensions.ToObject<RefundReSopnce>(refund.Attributes); ;

        }

        public RefundReSopnce PartialRefund(string paymentId, RefundData refundData)
        {
            Payment payment = client.Payment.Fetch(paymentId);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("amount", refundData.amount);
            data.Add("notes", refundData.notes);
            Refund refunds = payment.Refund(data);
            return ObjectExtensions.ToObject<RefundReSopnce>(refunds.Attributes);
        }

    }
}
