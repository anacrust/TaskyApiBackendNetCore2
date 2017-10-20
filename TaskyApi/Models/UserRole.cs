using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserM2muserRole = new HashSet<UserM2muserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<UserM2muserRole> UserM2muserRole { get; set; }
    }
}
