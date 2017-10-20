using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class UserBackgroundCheck
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ImageScaneCdn { get; set; }
        public byte[] ImageScanData { get; set; }
        public bool Passed { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public User User { get; set; }
    }
}
