using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppAttendance
    {
        public Guid Id { get; set; }
        public DateTime AttendenceDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid AttTypeId { get; set; }
        public string UserId { get; set; }
        public string TakenByUserId { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AppAttendanceType AttType { get; set; }
        public AppOrganization Org { get; set; }
        public AspNetUsers TakenByUser { get; set; }
        public AspNetUsers User { get; set; }
    }
}
