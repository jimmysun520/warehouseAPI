using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;

namespace WarehouseApi.Controllers
{
    [Route("api/[controller]")]
    public class RecentItemCountsController : Controller
    {
        private readonly IItemCountRecentService service;
        public RecentItemCountsController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IItemCountRecentService>();

        // GET api/itemCounts/523523
        [HttpGet("{Sku}")]
        public IEnumerable<ItemCount> GetBy(int Sku)
        {
            try
            {
                ItemCount searchItemCount = new ItemCount();
                searchItemCount.Sku = Sku;
                return service.GetBy(searchItemCount);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }
    }
}
