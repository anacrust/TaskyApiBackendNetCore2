using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class UserLicenseType
    {
        public UserLicenseType()
        {
            UserLicense = new HashSet<UserLicense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<UserLicense> UserLicense { get; set; }
    }
}
