using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskyApi.Models.DTOs
{
    public class PaymentTypeDto
    {
        public int id { get; set; }
        public string name { get; set; }
        //public bool? active { get; set; }

        //public static implicit operator PaymentTypeDto(PaymentType model)
        //{
        //    return new PaymentTypeDto
        //    {
        //        Id = model.Id,
        //        Name = model.Name,
        //        Active = model.Active
        //    };
        //}
    }
}
