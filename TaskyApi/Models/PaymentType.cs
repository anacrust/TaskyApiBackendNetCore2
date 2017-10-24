using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Tasky = new HashSet<Tasky>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<Tasky> Tasky { get; set; }
    }
}
