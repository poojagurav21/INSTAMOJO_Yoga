using AutoMapper;
using Instamojo.AppliedCourses;
using Instamojo.Payments;

namespace Instamojo;

public class InstamojoApplicationAutoMapperProfile : Profile
{
    public InstamojoApplicationAutoMapperProfile()
    {
        CreateMap< AppliedCreateOrUpdateDto, Applied >().ReverseMap();
        CreateMap<GetAppliedDto,Applied>().ReverseMap();
        CreateMap<CreatePaymentDTO, PaymentRequest>();
        CreateMap<PaymentDetailsDTO, PaymentTransactionDetail>();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
