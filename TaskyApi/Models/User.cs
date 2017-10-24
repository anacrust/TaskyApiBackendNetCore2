using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class User
    {
        public User()
        {
            TaskyCreator = new HashSet<Tasky>();
            TaskyTasker = new HashSet<Tasky>();
            UserBackgroundCheck = new HashSet<UserBackgroundCheck>();
            UserLicense = new HashSet<UserLicense>();
            UserM2muserRole = new HashSet<UserM2muserRole>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool? IsLocked { get; set; }
        public string Email { get; set; }
        public string PhoneMain { get; set; }
        public string PhoneMaineExt { get; set; }
        public string Phone2nd { get; set; }
        public string Phone2ndExt { get; set; }
        public byte[] ProfilePicData { get; set; }
        public string ProfilePicCdn { get; set; }
        public bool? HasLicense { get; set; }
        public bool? HasBackgroundCheck { get; set; }
        public byte[] DriversLicenseScanData { get; set; }
        public string DriverLicenseScanCdn { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<Tasky> TaskyCreator { get; set; }
        public ICollection<Tasky> TaskyTasker { get; set; }
        public ICollection<UserBackgroundCheck> UserBackgroundCheck { get; set; }
        public ICollection<UserLicense> UserLicense { get; set; }
        public ICollection<UserM2muserRole> UserM2muserRole { get; set; }
    }
}
