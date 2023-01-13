
using PayPal.OpenIdConnect;
using PayPal.v1.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal;
using PayPalHttp;
using System.Configuration;

namespace Instamojo.PaymentPaypals
{
    public partial class PaymentWithPayPal : InstamojoAppService
    {
        protected override void RunSample()
        {

            var apiContext = Configuration.GetAPIContext();

            string payerId = Request.Params["PayerID"];
            if (string.IsNullOrEmpty(payerId))
            {

                var itemList = new ItemList()
                {
                     items = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Item Name",
                            Currency = "USD",
                            Price = "15",
                            Quantity = "5",
                            Sku = "sku"
                        }
                    }
                };
                var payer = new Payer() { PaymentMethod = "paypal" };
                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPayPal.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;
                var redirUrls = new RedirectUrls()
                {
                    CancelUrl = redirectUrl + "&cancel=true",
                    ReturnUrl = redirectUrl
                };


                var details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                };


                var amount = new Amount()
                {
                    Currency = "USD",
                    Total = "100.00", // Total must be equal to sum of shipping, tax and subtotal.
                    Details = details
                };

                var transactionList = new List<Transaction>();

                transactionList.Add(new Transaction()
                {
                    Description = "Transaction description.",
                    InvoiceNumber = Common.GetRandomInvoiceNumber(),
                    Amount = amount,
                    ItemList = itemList
                });

                var payment = new Payment()
                {
                    Intent = "sale",
                    Payer = payer,
                    Transactions = transactionList,
                    RedirectUrls = redirUrls
                };

                var createdPayment = payment.Create(apiContext);
                var links = createdPayment.links.GetEnumerator();
                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        this.flow.RecordRedirectUrl("Redirect to PayPal to approve the payment...", link.href);
                    }
                }
                Session.Add(guid, createdPayment.id);
                Session.Add("flow-" + guid, this.flow);
            }
            else
            {
                var guid = Request.Params["guid"];

                var paymentId = Session[guid] as string;
                var paymentExecution = new PaymentExecution() { payer_id = payerId };
                var payment = new Payment() { id = paymentId };

                var executedPayment = payment.Execute(apiContext, paymentExecution);

            }

        }

        /// <summary>
        /// Code example for creating a future payment object.
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="authorizationCode"></param>
        private Payment CreateFuturePayment(string correlationId, string authorizationCode, string redirectUrl)
        {

            Payer payer = new Payer()
            {
                PaymentMethod = "paypal"
            };

            var amount = new Amount()
            {
                Currency = "USD",

                Total = "100",

                details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                }
            };

            var redirUrls = new RedirectUrls()
            {
                CancelUrl = redirectUrl,
                ReturnUrl = redirectUrl
            };

            var itemList = new ItemList() { items = new List<Item>() };
            itemList.items.Add(new Item()
            {
                Name = "Item Name",
                Currency = "USD",
                Price = "15",
                Quantity = "5",
                Sku = "sku"
            });

            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                Description = "Transaction description.",
                Amount = amount,
                ItemList = itemList
            });

            var authorizationCodeParameters = new CreateFromAuthorizationCodeParameters();
            authorizationCodeParameters.setClientId(Configuration.ClientId);
            authorizationCodeParameters.setClientSecret(Configuration.ClientSecret);
            authorizationCodeParameters.SetCode(authorizationCode);

            var apiContext = Configuration.GetAPIContext();


            var tokenInfo = Tokeninfo.CreateFromAuthorizationCodeForFuturePayments(apiContext, authorizationCodeParameters);
            var accessToken = string.Format("{0} {1}", tokenInfo.token_type, tokenInfo.access_token);

            var futurePaymentApiContext = Configuration.GetAPIContext(accessToken);

            var futurePayment = new FuturePayment()
            {
                intent = "authorize",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return futurePayment.Create(futurePaymentApiContext, correlationId);
        }
    }
}
