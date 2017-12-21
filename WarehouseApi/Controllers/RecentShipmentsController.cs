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
    public class RecentShipmentsController : Controller
    {
        private readonly IRecentShipmentService service;
        public RecentShipmentsController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IRecentShipmentService>();

        // GET api/recentShipments/5
        [HttpGet("{StoreId}")]
        public IEnumerable<RecentShipment> GetBy(int StoreId)
        {
            try
            {
                RecentShipment recentShipment = new RecentShipment();
                recentShipment.Store = StoreId;
                return service.GetBy(recentShipment);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // GET api/recentShipments
        [HttpGet("")]
        public IEnumerable<RecentShipment> GetAll()
        {
            try
            {
                return service.GetAll();
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
