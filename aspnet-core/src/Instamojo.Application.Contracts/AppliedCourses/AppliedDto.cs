using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Instamojo.AppliedCourses
{
    public class AppliedDto
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string CourseId { get; set; }
        public string ProgramId { get; set; }
        public string CourseName { get; set; }
        public float TotalFee { get; set; }
        public string CountryName { get; set; }
    }
    public class GetAppliedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { set; get; }
    }
}
