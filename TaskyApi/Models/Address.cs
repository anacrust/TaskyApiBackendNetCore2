using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class Address
    {
        public Address()
        {
            TaskMultiAddress = new HashSet<TaskMultiAddress>();
        }

        public Guid Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public bool Confirmed { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<TaskMultiAddress> TaskMultiAddress { get; set; }
    }
}
