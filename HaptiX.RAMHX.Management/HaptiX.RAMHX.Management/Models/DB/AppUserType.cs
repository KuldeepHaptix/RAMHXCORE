using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppUserType
    {
        public AppUserType()
        {
            AppUserPermission = new HashSet<AppUserPermission>();
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public Guid DepartId { get; set; }
        public Guid OrgId { get; set; }

        public AppOrganizationDepartment Depart { get; set; }
        public AppOrganization Org { get; set; }
        public ICollection<AppUserPermission> AppUserPermission { get; set; }
        public ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
