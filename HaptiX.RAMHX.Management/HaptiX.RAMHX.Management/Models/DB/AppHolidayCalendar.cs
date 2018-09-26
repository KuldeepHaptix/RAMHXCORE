using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppHolidayCalendar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid OrgId { get; set; }
        public Guid AcademicYid { get; set; }

        public AppAcademicYear AcademicY { get; set; }
        public AppOrganization Org { get; set; }
    }
}
