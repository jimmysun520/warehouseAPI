using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WarehouseServices.Contracts;
using WarehouseServices.Infrastructure;
using System.Text.RegularExpressions;
using WarehouseApi.Extensions;
using Microsoft.Extensions.Configuration;

namespace WarehouseApi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService service;
        public OrdersController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IOrderService>();

        // get order info by sku
        // GET api/orders/5
        [HttpGet("bySkuAndDc/{Sku}/{Dc}")]
        public IEnumerable<Order> GetBySkuAndDc(int Sku, int Dc)
        {
            try
            {
                Order searchOrder  = new Order();
                searchOrder.Sku = Sku;
                searchOrder.WarehouseNumber = Dc;
                return service.GetBy(searchOrder);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }
        
        // GET api/orders/5
        [HttpGet("bySkuAndDcWithStartDate/{Sku}/{Dc}/{StartDate}")]
        public IEnumerable<Order> GetBySkuAndDcWithStartDate(int Sku, int Dc, string StartDate)
        {
            try
            {
                var formatedStartDate = FormatDate(StartDate);
                Order searchOrder  = new Order();
                searchOrder.Sku = Sku;
                searchOrder.WarehouseNumber = Dc;
                searchOrder.OrderDate = formatedStartDate;
                return service.GetBy(searchOrder);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        private int FormatDate(string date)
        {
            string pattern = @"\d{8}";
            Regex r = new Regex(pattern);
            Match match = r.Match(date);
            if(match.Success)
            {
                return int.Parse(date);
            }
            else
            {
                throw new Exception("StartDate format must be something like 20170930");
            }
        }

        // get orders
        // GET api/orders
        [HttpGet("")]
        public IEnumerable<Order> GetAll()
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

        // // get the most recent order of an item from a dc to all stores
        // // GET api/orders/storeOrders?itemSku=123490
        // [HttpGet]
        // [Route("mostRecentToStores")]
        // public string MostRecentToStores([FromQuery]int itemSku, string dcCode)
        // {
        //     return "get orders by sku and dcCode";
        // }

        // //get historic orders up to 12 month of an item from a dc to a specific store
        // // GET api/orders/storeOrders?itemSku=123490
        // [HttpGet]
        // [Route("storeOrders")]
        // public string StoreOrders([FromQuery]int itemSku, string dcCode, int storeId, int intOfDays)
        // {
        //     return "recent orders for a stoer";

        // }
    }
}
