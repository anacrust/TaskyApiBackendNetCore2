using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class UserLicense
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public int? LicenseTypeId { get; set; }
        public string County { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public byte[] ImageScanData { get; set; }
        public string ImageCdn { get; set; }
        public string Link { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public UserLicenseType LicenseType { get; set; }
        public User User { get; set; }
    }
}
