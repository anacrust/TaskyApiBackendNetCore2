using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class Pictures
    {
        public Guid Id { get; set; }
        public byte[] PicData { get; set; }
        public string PicCdn { get; set; }
    }
}
