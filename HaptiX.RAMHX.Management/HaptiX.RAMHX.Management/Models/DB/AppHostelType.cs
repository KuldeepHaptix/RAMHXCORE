using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppHostelType
    {
        public AppHostelType()
        {
            AppHostel = new HashSet<AppHostel>();
        }

        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public Guid OrgId { get; set; }

        public AppOrganization Org { get; set; }
        public ICollection<AppHostel> AppHostel { get; set; }
    }
}
