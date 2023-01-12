using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Instamojo.AppliedCourses
{
    public interface IAppliedAppService : IApplicationService
    {
        Task CreateAsync(AppliedCreateOrUpdateDto input);
        Task<List<AppliedDto>> GetAllAsync();
    }
}
