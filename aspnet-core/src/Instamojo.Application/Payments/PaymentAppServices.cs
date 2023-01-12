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
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Web;
using Instamojo.Payments.Instamojo;
namespace Instamojo.Payments
{
    public class PaymentAppServices : ApplicationService, IPaymentAppServices
    {

        private readonly IinstamojoHttpClient _imHttpclient;
        private readonly IPaymentRequestRepository _paymentrequestRepository;
        private readonly IPaymentDetailRepository _paymentdetailRepository;
        private string redirectUrl { get; set; }
        public PaymentAppServices(IinstamojoHttpClient imHttpclient, IPaymentRequestRepository paymentrequestRepository, IPaymentDetailRepository paymentdetailRepository)
        {
            _imHttpclient = imHttpclient;
            _paymentrequestRepository = paymentrequestRepository;
            _paymentdetailRepository = paymentdetailRepository;
            //  _InstamojoServices = InstamojoServices;
        }
        public async Task<string> CreateAsync(CreatePaymentDTO input)
        {

            var PaymentReq = ObjectMapper.Map<CreatePaymentDTO, PaymentRequest>(input);
            string data = await _imHttpclient.CreatePaymentRequest(PaymentReq);
            PaymentReq.PaymentRequest_id = data.Split("||")[1];
            var result = await _paymentrequestRepository.InsertAsync(PaymentReq, autoSave: true);
            await CurrentUnitOfWork.SaveChangesAsync();
            return data.Split("||")[0];
            //  return await _imHttpclient.CreatePaymentRequest(PaymentReq, transid);
        }
        public async Task<string> CreatePaymentDetails(PaymentDetailsDTO input)
        {
            string status = await _imHttpclient.GetPaymentStatus(input.PaymentID);
            input.CurrentPaymentStatus = status;
            var PaymentTransDetail = ObjectMapper.Map<PaymentDetailsDTO, PaymentTransactionDetail>(input);
            var result = await _paymentdetailRepository.InsertAsync(PaymentTransDetail, autoSave: true);
            return status;
        }
    }
}
