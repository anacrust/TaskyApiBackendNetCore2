using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class TaskMultiAddress
    {
        public Guid TaskId { get; set; }
        public Guid AddressId { get; set; }
        public bool LocationNum { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public Address Address { get; set; }
        public Task Task { get; set; }
    }
}
