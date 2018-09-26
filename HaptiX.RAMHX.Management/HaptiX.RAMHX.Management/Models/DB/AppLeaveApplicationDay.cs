using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppLeaveApplicationDay
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsHalf { get; set; }
        public string HalfPeriod { get; set; }
        public string UserId { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AppOrganization Org { get; set; }
        public AspNetUsers User { get; set; }
    }
}
