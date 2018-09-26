using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppStudentResult
    {
        public Guid Id { get; set; }
        public string PaperFile { get; set; }
        public int ObtainMarks { get; set; }
        public string UserId { get; set; }
        public string InspectorId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid DivisionId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }
        public Guid ExamId { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AppClass Class { get; set; }
        public AppClassDivision Division { get; set; }
        public AppStudentExam Exam { get; set; }
        public AspNetUsers Inspector { get; set; }
        public AppOrganization Org { get; set; }
        public AppClassSubject Subject { get; set; }
        public AspNetUsers User { get; set; }
    }
}
