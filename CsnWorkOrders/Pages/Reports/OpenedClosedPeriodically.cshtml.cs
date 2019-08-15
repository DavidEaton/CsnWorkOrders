using CsnWorkOrders.Data;
using CsnWorkOrders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CsnWorkOrders.Pages.Reports
{
    public class OpenedClosedPeriodicallyModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWorkOrderData data;

        public string Message { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }

        // Functions as both output and input model
        // By default, only binds during POST
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public OpenedClosedPeriodicallyModel(IConfiguration config,
                                             IWorkOrderData data)
        {
            this.config = config;
            this.data = data;
        }

        public IActionResult OnGet()
        {
            Message = config["Message"];
            WorkOrders = data.GetByDetail(SearchTerm);

            if (WorkOrders == null || !WorkOrders.Any())
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}