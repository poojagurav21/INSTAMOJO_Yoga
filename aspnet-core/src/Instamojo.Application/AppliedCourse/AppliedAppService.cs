using Instamojo.AppliedCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Instamojo.AppliedCourse
{
    public class AppliedAppService : InstamojoAppService, IAppliedAppService
    {
        private readonly IRepository<Applied,Guid> _appliedRepository;
        public AppliedAppService(IRepository<Applied, Guid> appliedRepository)
        {
            _appliedRepository = appliedRepository;
        }

        public async Task CreateAsync(AppliedCreateOrUpdateDto input)
        {
            var courseDetailMap = ObjectMapper.Map<AppliedCreateOrUpdateDto, Applied>(input);
            var courseDetail = await _appliedRepository.InsertAsync(courseDetailMap);
        }
        public async Task<List<AppliedDto>> GetAllAsync()
        {
            var coursename = await _appliedRepository.GetListAsync();
            return coursename.Select(item => new AppliedDto
            {
                UserId= item.UserId,
                Name = item.Name,
                Email= item.Email,
                MobileNumber= item.MobileNumber,    
                CountryName= item.CountryName,
                ProgramId= item.ProgramId,
                
                CourseName = item.CourseName,
                CourseId = item.CourseId,
                TotalFee = item.TotalFee
            }).ToList();
        }
    }
}
