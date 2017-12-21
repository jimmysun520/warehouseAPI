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
    public class ItemsController : Controller
    {
        private readonly IItemService service;
        public ItemsController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IItemService>();

        // get item by sku
        // GET api/items/5
        [HttpGet("{Sku}")] //@TODO: REFACTOR
        public IEnumerable<Item> GetBy(int Sku)
        {
            try
            {
                Item newItem = new Item();
                newItem.Sku = Sku;
                return service.GetBy(newItem);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // get all items with default limit
        // GET api/items
        [HttpGet("")]
        public IEnumerable<Item> GetAll()
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
