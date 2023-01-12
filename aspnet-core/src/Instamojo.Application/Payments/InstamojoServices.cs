using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using InstaSharp.Exceptions;
using InstaSharp.Interface;
using InstaSharp.Model;
using InstaSharp.Response;
using InstaSharp;
using Volo.Abp.Modularity;
using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;
using RestSharp;

using AutoMapper.Internal.Mappers;
using Instamojo.Payments.Instamojo;

namespace Instamojo.Payments
{
    public class InstamojoServices:IInstamojoServices
    {
        private readonly IinstamojoHttpClient _imHttpclient;
        private readonly IConfigurationRoot _appConfigurations;
        public InstamojoServices(IConfigurationRoot appConfigurations, IinstamojoHttpClient imHttpclient)
        {
            _appConfigurations = appConfigurations;
            _imHttpclient = imHttpclient;
           
        }
        public async Task<string> CreatePaymentRequestInstaMojo(CreatePaymentDTO input,string transactionId)
        {
          //  var PaymentReq = ObjectMapper.Map<CreatePaymentDTO, PaymentRequest>(input)
            string clientid = "test_pFVcJomHPMH7hv9lFNCU328eCq0PGu1t0mk";
            string secret = "test_M4VmsoWBl6k1bFtXnZzvjlbdGaaLDwo7r2bbh2fow8IxB8xgRzrd216SZaNWjX6fDWbPcxeleQv7M7TzOYDjLxWpTyIQmfq7THQjOY47JP9aF9hG8j5A0hbafn1";
            string auth_endpoint = "https://test.instamojo.com/oauth2/token/";
            string endpoint = "https://test.instamojo.com/v2/";
            //await _imHttpclient.CreatePaymentRequest(input, transactionId);//
            //Config obj=new Config();
            //obj.grant_type = "client_credentials";
            //obj.client_id = clientid;
            //obj.client_secret= secret;
           //string rebody = System.Text.Json.JsonSerializer.Serialize(obj);
            //System.Net.ServicePointManager.SecurityProtocol =
            //SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            //var client = new RestClient($"{auth_endpoint}");
            //var request = new RestRequest();
            //request.Method = Method.Post;
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", rebody, ParameterType.RequestBody);
            //var response = await client.ExecuteAsync(request);
            // string tk= System.Text.Json.JsonSerializer.Deserialize<Auth>(response.Content)?.access_token;
            IInstamojo objClass = InstamojoImplementation.getApi(clientid, secret, endpoint, auth_endpoint);


            PaymentOrder objPaymentRequest = new PaymentOrder();
           
            //Required POST parameters
            objPaymentRequest.name = input.Name;
            objPaymentRequest.email = input.Email;
            objPaymentRequest.phone = input.Phone;
            objPaymentRequest.amount = input.Amount;
            objPaymentRequest.transaction_id = transactionId; // Unique Id to be provided
            objPaymentRequest.description = input.Description;


           objPaymentRequest.redirect_url = "http://localhost:4200/payment";

            //webhook is optional.
            objPaymentRequest.webhook_url = "https://your.server.com/webhook";

            if (objPaymentRequest.validate())
            {
                if (objPaymentRequest.emailInvalid)
                {

                }
                if (objPaymentRequest.nameInvalid)
                {

                }
                if (objPaymentRequest.phoneInvalid)
                {

                }
                if (objPaymentRequest.amountInvalid)
                {

                }
                if (objPaymentRequest.currencyInvalid)
                {

                }
                if (objPaymentRequest.transactionIdInvalid)
                {

                }
                if (objPaymentRequest.redirectUrlInvalid)
                {

                }
                if (objPaymentRequest.webhookUrlInvalid)
                {

                }

            }
            else
            {
                try
                {
                    CreatePaymentOrderResponse objPaymentResponse = objClass.CreateNewPaymentRequest(objPaymentRequest);
                    string orderid = objPaymentResponse.order.id;
                    string paymnturl = objPaymentResponse.payment_options.payment_url;
                    //Response.Redirect(paymnturl);
                    return paymnturl;
                }
                catch (ArgumentNullException ex)
                {

                }
                catch (WebException ex)
                {

                }
                catch (IOException ex)
                {

                }
                catch (InvalidPaymentOrderException ex)
                {
                    if (!ex.IsWebhookValid())
                    {

                    }

                    if (!ex.IsCurrencyValid())
                    {

                    }

                    if (!ex.IsTransactionIDValid())
                    {

                    }
                }
                catch (ConnectionException ex)
                {

                }
                catch (BaseException ex)
                {

                }
                catch (Exception ex)
                {

                }
            }
               return "";


        }
   public async Task<string> GetpaymentStatus(string transactionId,string OrderId)
        {
            string clientid = "test_LfPHD7E0OxuHgTZrFIwTMiKOWqo7N7bANFR";
            string secret = "test_mVmt0FyXk6uH8ViLw35eUUpPqOwf5Mc5iWRfwxEpgDI8FFV4mXg48FAyGzZoQpnOwvEQhWF3SlxsPHCP88pipzdvILOv5DERa4yZJbu7va7aEk1bBa7zroG2YgL";
            string auth_endpoint = "https://test.instamojo.com/oauth2/token/";
            string endpoint = "https://test.instamojo.com/v2/";


            System.Net.ServicePointManager.SecurityProtocol =
            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            IInstamojo objClass = InstamojoImplementation.getApi(clientid, secret, endpoint, auth_endpoint);
            PaymentOrderDetailsResponse response=objClass.GetPaymentOrderDetailsByTransactionId(transactionId); 
            PaymentOrderDetailsResponse res= objClass.GetPaymentOrderDetails(transactionId);

            PaymentOrderListRequest objPaymentOrderListRequest = new PaymentOrderListRequest();

            //Required POST parameters
            objPaymentOrderListRequest.id = OrderId;
            objPaymentOrderListRequest.transaction_id = transactionId;
            PaymentOrderListResponse resp = objClass.GetPaymentOrderList(objPaymentOrderListRequest);
            return "";


        }
    }
}
