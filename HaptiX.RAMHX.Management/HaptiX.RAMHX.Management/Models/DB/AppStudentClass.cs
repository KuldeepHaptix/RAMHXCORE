using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppStudentClass
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public Guid DivisionId { get; set; }
        public string StudentId { get; set; }
        public string RollNo { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AppClass Class { get; set; }
        public AppClassDivision Division { get; set; }
        public AppOrganization Org { get; set; }
        public AspNetUsers Student { get; set; }
    }
}
