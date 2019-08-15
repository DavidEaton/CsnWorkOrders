using System;
using System.Collections.Generic;

namespace CsnWorkOrders.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public int AreaID { get; set; }
        public Area Area { get; set; }
        public Nullable<bool> Active { get; set; }
        public string AreaName { get; set; }
        public string ServiceType { get; set; }
    }
}
