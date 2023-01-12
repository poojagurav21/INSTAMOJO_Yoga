using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using Volo.Abp.DependencyInjection;
using System.Net.Http;

namespace Instamojo.Payments.Instamojo
{

    public class InstamojoHttpClient:IinstamojoHttpClient
    {
        private readonly IConfiguration Configuration;
        private string endpoint { get; set; }
        private string authendpoint { get; set; }
        private string client_id { get; set; }
        private string client_secret { get; set; }
        private string returnurl { get; set; }
        private readonly PaymentReq _request;
        public InstamojoHttpClient(IConfiguration Configuration,PaymentReq request)
        {
            
            authendpoint = Configuration["Payment:Instamojo:auth_endpoint"];
            endpoint = Configuration["Payment:Instamojo:endpoint"];                   
           client_id = Configuration["Payment:Instamojo:clientid"];
           client_secret = Configuration["Payment:Instamojo:secret"];
           returnurl= Configuration["App:ClientUrl"];
            _request = request;
        }       



        public async Task<string> CreatePaymentRequest(PaymentRequest Input)
        {
            string tocken = await CreateTocken();
           
         
            return await CreatePayment(tocken, Input, "payment_requests/");                          
        }
        public async Task<string> GetPaymentStatus(string paymentId)
        {
            string token = await CreateTocken();
            string status=await GetPaymentDetails("payments/"+ paymentId+"/",token );
            return status;
        }

        public async Task<string> CreateTocken()
        {
          //  string body = System.Text.Json.JsonSerializer.Serialize(_config);
          //  var client = new RestClient($"{authendpoint}");
          //  var request = new RestRequest();
          //  request.Method = Method.Post;
          //  request.AddHeader("Content-Type", "application/json");
          //  request.AddHeader("Access-Control-Allow-Origin", "*");
          //  request.AddHeader("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, PATCH, DELETE");
          //  request.AddParameter("application/json", body, ParameterType.RequestBody);
          //  var response = await client.ExecuteAsync(request);
          //return System.Text.Json.JsonSerializer.Deserialize<AuthenticationResponse>(response.Content)?.access_token;


           var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{ authendpoint }"),
                Headers =
                 {
                     { "accept", "application/json" },
                     { "API_Key", "test_47a01ac38ffa11c1309d1f93e16" },
                     { "Auth_Token", "test_a939f49b3598f3304b699ff6850" },
                     { "salt", "0bcf7fb7a8e047c791303af331ea5d9c" }
                  },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id",client_id },
                    { "client_secret",client_secret}
                }),
            };
            var response = await client.SendAsync(request);
             response.EnsureSuccessStatusCode();
           return System.Text.Json.JsonSerializer.Deserialize<AuthenticationResponse>(response.Content.ReadAsStream())?.access_token;
            
        }

        public async Task<string> CreatePayment(string token, PaymentRequest Input,string url)
        {
            try
            {




                //var client = new RestClient($"{endpoint}{url}");
                //var request = new RestRequest();
                //request.Method = Method.Post;
                //request.AddHeader("Content-Type", "application/json");
                //request//.AddHeader("Authorization","Bearer " + tocken);
                //request.AddHeader("Access-Control-Allow-Origin", "*");
                //request.AddHeader("Access-Control-Allow-Methods", "OPTIONS, GET, POST, PUT, PATCH, DELETE");
                //request.AddParameter("application/json", body, ParameterType.RequestBody);
                //var response = await client.ExecuteAsync(request);

                //return System.Text.Json.JsonSerializer.Deserialize<CreatePaymentResponse>(response.Content)?.longurl;

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{endpoint}{url}"),
                    Headers =
                {
                  { "accept", "application/json" },
                  { "Authorization", "Bearer " + token },
                  { "API_Key", "test_47a01ac38ffa11c1309d1f93e16" },
                    { "Auth_Token", "test_a939f49b3598f3304b699ff6850" },
                     { "salt", "0bcf7fb7a8e047c791303af331ea5d9c" },
                 //   {  "Access_Control_Allow_Origin", "*" }
                   { "mode" ,"no-cors" }
                },
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"purpose"  , Input.Description },
                    { "amount",Input.Amount.ToString()},
                    {" buyer_name" , Input.Name },
                    { "email" , Input.Email },
                    { "phone" , Input.Phone },
                    { "redirect_url" , returnurl+"/payment" },
                    { "allow_repeated_payments", "false" },
                    { "send_email", "false" },
                    { "send_sms", "false" },
                 }),
                };
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
               
                var cn = response.Content;
             //   string redirecurl = System.Text.Json.JsonSerializer.Deserialize<CreatePaymentResponse>(response.Content.ReadAsStream())?.longurl + "?embed=form";
                var data = System.Text.Json.JsonSerializer.Deserialize<CreatePaymentResponse>(response.Content.ReadAsStream());

                return data.longurl+"||"+data.id;
            }
            catch (Exception)
            {

                throw;
            }
            return "";
        }
        public async Task<string> GetPaymentDetails(string url,string token)
        {           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{endpoint}{url}"),
                Headers =
                  {
                     { "accept", "application/json" },
                     { "Authorization", "Bearer " + token },
                  },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var paystatus = System.Text.Json.JsonSerializer.Deserialize<PaymentStatus>(response.Content.ReadAsStream())?.status;
            if (paystatus != null)
            {
                if (paystatus==true)
                {
                    return "Successful";
                }
                else
                {
                    return "Failed";
                }
            }
            else
            {
                return "Initiated";
            }
            return "";
        }


       
    }
}
