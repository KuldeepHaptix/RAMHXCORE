using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class MstCity
    {
        public MstCity()
        {
            AppOrganization = new HashSet<AppOrganization>();
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public Guid Id { get; set; }
        public string CityName { get; set; }
        public Guid StateId { get; set; }

        public MstState State { get; set; }
        public ICollection<AppOrganization> AppOrganization { get; set; }
        public ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
