using System;
using System.Collections.Generic;

namespace HaptiX.RAMHX.Management.Models.DB
{
    public partial class MstCountry
    {
        public MstCountry()
        {
            AppOrganization = new HashSet<AppOrganization>();
            AspNetUsers = new HashSet<AspNetUsers>();
            MstState = new HashSet<MstState>();
        }

        public Guid Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<AppOrganization> AppOrganization { get; set; }
        public ICollection<AspNetUsers> AspNetUsers { get; set; }
        public ICollection<MstState> MstState { get; set; }
    }
}
