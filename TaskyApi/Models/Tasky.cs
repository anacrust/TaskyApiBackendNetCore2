using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class Tasky
    {
        public Tasky()
        {
            TaskMultiAddress = new HashSet<TaskMultiAddress>();
        }

        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? TaskerId { get; set; }
        public int TaskTypeId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public bool NoAddressReq { get; set; }
        public bool SingleAddressReq { get; set; }
        public bool MultiAddressReq { get; set; }
        public bool BackgroundCheckReq { get; set; }
        public bool LicenseReq { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? Completed { get; set; }
        public decimal? Amount { get; set; }
        public int PaymentTypeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ContactNotes { get; set; }
        public string PaymentNotes { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public User Creator { get; set; }
        public PaymentType PaymentType { get; set; }
        public TaskType TaskType { get; set; }
        public User Tasker { get; set; }
        public ICollection<TaskMultiAddress> TaskMultiAddress { get; set; }
    }
}
