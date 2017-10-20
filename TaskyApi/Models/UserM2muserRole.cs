using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class UserM2muserRole
    {
        public Guid UserId { get; set; }
        public int UserRoleId { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public User User { get; set; }
        public UserRole UserRole { get; set; }
    }
}
