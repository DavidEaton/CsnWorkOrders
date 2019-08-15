using System;
using System.Collections.Generic;
using System.Linq;
using CsnWorkOrders.Models;

namespace CsnWorkOrders.Data
{
    public class InMemoryWorkOrderData : IWorkOrderData
    {
        readonly List<WorkOrder> workorders;

        readonly DateTime yesterday = DateTime.Today.AddDays(-1);
        readonly DateTime lastWeek = DateTime.Today.AddDays(-7);
        readonly DateTime tomorrow = DateTime.Today.AddDays(1);
        readonly DateTime today = DateTime.Today;

        public InMemoryWorkOrderData()
        {
            workorders = new List<WorkOrder>()
            {
                new WorkOrder { Id = 1, Closed = null, Department = new Department { Id = 1, Active = true, Name = "Dodge", Area = new Area { Id = 1, Active = true, Name = "Lincoln" }, AreaName = "Lincoln" }, Details = "DEETS", Open = true, Reported = lastWeek, Reporter = "Molly Moops", Priority = Priority.Low, DepartmentId = 1 },

                new WorkOrder { Id = 2, Closed = null, Department = new Department { Id = 1, Active = true, Name = "Dodge", Area = new Area { Id = 1, Active = true, Name = "Lincoln" }, AreaName = "Lincoln" }, Details = "MORE DEETS", Open = true, Reported = lastWeek, Reporter = "Kiri Obeson", Priority = Priority.Normal, DepartmentId = 1 },

                new WorkOrder { Id = 3, Closed = yesterday, Department = new Department { Id = 2, Active = true, Name = "Fair", Area = new Area { Id = 1, Active = true, Name = "Lincoln" }, AreaName = "Lincoln" }, Details = "EVEN MORE DEETS", Open = false, Reported = today, Reporter = "Aliya Enorma", Priority = Priority.High, DepartmentId = 1 },

            };
        }


        public IEnumerable<WorkOrder> GetByDetail(string searchTerm = null)
        {
            return from w in workorders
                   where string.IsNullOrEmpty(searchTerm) || w.Details.Contains(searchTerm)
                   orderby w.Reported
                   select w;
        }
    }
}
