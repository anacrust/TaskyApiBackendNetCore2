using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class Task
    {
        public Task()
        {
            TaskMultiAddress = new HashSet<TaskMultiAddress>();
        }

        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? TaskerId { get; set; }
        public int TaskTypeId { get; set; }
        public Guid? AddressId { get; set; }
        public bool NoAddressReq { get; set; }
        public bool SingleAddressReq { get; set; }
        public bool MultiAddressReq { get; set; }
        public bool BackgroundCheckReq { get; set; }
        public bool LicenseReq { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Completed { get; set; }
        public decimal? Amount { get; set; }
        public int PaymentTypeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactNotes { get; set; }
        public string TaskNotes { get; set; }
        public string PaymentNotes { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public Address Address { get; set; }
        public User Creator { get; set; }
        public PaymentType PaymentType { get; set; }
        public TaskType TaskType { get; set; }
        public User Tasker { get; set; }
        public ICollection<TaskMultiAddress> TaskMultiAddress { get; set; }
    }
}
