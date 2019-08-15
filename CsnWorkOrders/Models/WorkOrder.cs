using System;

namespace CsnWorkOrders.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Priority Priority { get; set; }
        public DateTime Reported { get; set; }
        public string Reporter { get; set; }
        public string Details { get; set; }
        public DateTime? Closed { get; set; }
        public bool Open { get; set; }
        public Department Department { get; set; }
    }
}
