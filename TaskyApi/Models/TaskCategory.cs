using System;
using System.Collections.Generic;

namespace TaskyApi.Models
{
    public partial class TaskCategory
    {
        public TaskCategory()
        {
            TaskType = new HashSet<TaskType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public byte[] Updated { get; set; }

        public ICollection<TaskType> TaskType { get; set; }
    }
}
