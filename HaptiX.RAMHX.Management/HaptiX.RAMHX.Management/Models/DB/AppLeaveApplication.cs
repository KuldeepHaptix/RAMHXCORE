using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppLeaveApplication
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }
        public string TaskDescription { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfDays { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }
        public string ApprovedByUserId { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AspNetUsers ApprovedByUser { get; set; }
        public AppOrganization Org { get; set; }
        public AspNetUsers User { get; set; }
    }
}
