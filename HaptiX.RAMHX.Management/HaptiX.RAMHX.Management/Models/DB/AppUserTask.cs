using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppUserTask
    {
        public Guid Id { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskSubmissionDate { get; set; }
        public string Remark { get; set; }
        public string TaskFile { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? DivisionId { get; set; }
        public string UserId { get; set; }
        public string GivenByByUserId { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AppClass Class { get; set; }
        public AppClassDivision Division { get; set; }
        public AspNetUsers GivenByByUser { get; set; }
        public AppOrganization Org { get; set; }
        public AspNetUsers User { get; set; }
    }
}
