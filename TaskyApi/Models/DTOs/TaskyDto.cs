using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskyApi.Models.DTOs
{
    public class TaskyDto
    {
        public Guid id { get; set; }
        public Guid creatorId { get; set; }
        public Guid? taskerId { get; set; }
        public int taskTypeId { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string street3 { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public decimal? lat { get; set; }
        public decimal? lng { get; set; }
        public bool noAddressReq { get; set; }
        public bool singleAddressReq { get; set; }
        public bool multiAddressReq { get; set; }
        public bool backgroundCheckReq { get; set; }
        public bool licenseReq { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime? completed { get; set; }
        public decimal paymentAmount { get; set; }
        public int paymentTypeId { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public string contactNotes { get; set; }
        public string paymentNotes { get; set; }

        //public static implicit operator TaskyDto(Tasky tasky)
        //{
        //    return new TaskyDto
        //    {
        //        id = tasky.Id,
        //        creatorId = tasky.CreatorId
        //    };
        //}
    }
}
