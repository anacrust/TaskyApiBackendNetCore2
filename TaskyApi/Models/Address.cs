using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class Address
    {
        public Address()
        {
            Task = new HashSet<Task>();
            TaskMultiAddress = new HashSet<TaskMultiAddress>();
        }

        public Guid Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool Confirmed { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<Task> Task { get; set; }
        public ICollection<TaskMultiAddress> TaskMultiAddress { get; set; }
    }
}
