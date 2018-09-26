using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class AppUserPermission
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public Guid UserTypeId { get; set; }

        public MstPermission Permission { get; set; }
        public AppUserType UserType { get; set; }
    }
}
