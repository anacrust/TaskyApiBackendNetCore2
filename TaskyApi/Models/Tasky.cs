using System;
using System.Collections.Generic;
using TaskyApi.Models.DTOs;

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
        public DateTime? EndTime { get; set; }
        public DateTime? Completed { get; set; }
        public decimal PaymentAmount { get; set; }
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

        //public Tasky(Guid CreatorId, Guid? TaskerId, int TaskTypeId, string Street1, string Street2, string Street3, string Country, 
        //    string Region, string County, string City, string PostalCode, decimal? Lat, decimal? Lng, bool NoAddressReq, bool SingleAddressReq, 
        //    bool MultiAddressReq, bool BackgroundCheckReq, bool LicenseReq, DateTime StartTime, DateTime? EndTime, DateTime? Completed, 
        //    decimal PaymentAmount, int PaymentTypeId, string Phone, string Email, string Description, string ContactNotes, 
        //    string PaymentNotes, bool? Active)
        //{ }
        public static implicit operator Tasky(TaskyDto model)
        {
            return new Tasky
            {
                Id = model.id,
                CreatorId = model.creatorId,
                TaskerId = model.taskerId,
                TaskTypeId = model.taskTypeId,
                Street1 = model.street1,
                Street2 = model.street2,
                Street3 = model.street3,
                Country = model.country,
                Region = model.region,
                County = model.county,
                City = model.city,
                PostalCode = model.postalCode,
                Lat = model.lat,
                Lng = model.lng,
                NoAddressReq = model.noAddressReq,
                SingleAddressReq = model.singleAddressReq,
                MultiAddressReq = model.multiAddressReq,
                BackgroundCheckReq = model.backgroundCheckReq,
                LicenseReq = model.licenseReq,
                StartTime = model.startTime,
                EndTime = model.endTime,
                Completed = model.completed,
                PaymentAmount = model.paymentAmount,
                PaymentTypeId = model.paymentTypeId,
                PaymentNotes = model.paymentNotes,
                Phone = model.phone,
                Email = model.email,
                Description = model.description,
                ContactNotes = model.contactNotes,
                Active = true
            };
        }
    }
}
