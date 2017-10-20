using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class TaskType
    {
        public TaskType()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public TaskCategory Category { get; set; }
        public ICollection<Task> Task { get; set; }
    }
}
