using CsnWorkOrders.Models;
using System.Collections.Generic;

namespace CsnWorkOrders.Data
{
    public interface IWorkOrderData
    {
        IEnumerable<WorkOrder> GetByDetail(string searchTerm);
    }
}
