using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Instamojo.AppliedCourses
{
    public class Applied:FullAuditedAggregateRoot<Guid>
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
}
