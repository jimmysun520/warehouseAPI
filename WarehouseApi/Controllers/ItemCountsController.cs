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
    public class ItemCountsController : Controller
    {
        private readonly IItemCountService service;
        public ItemCountsController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IItemCountService>();

        // GET api/itemCounts/bySkuAndYearAndWeek/5/2017/49
        [HttpGet("bySkuAndYearAndWeek/{Sku}/{Year}/{Week}")]
        public IEnumerable<ItemCount> GetBySkuAndYearAndWeek(int Sku, int Year, int Week)
        {
            try
            {
                ItemCount searchItemCount = new ItemCount();
                searchItemCount.Sku = Sku;
                searchItemCount.Year = Year;
                searchItemCount.Week = Week;
                return service.GetBy(searchItemCount);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // GET api/itemCounts/bySku/523523
        [HttpGet("bySku/{Sku}")]
        public IEnumerable<ItemCount> GetBySku(int Sku)
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

        // GET api/itemCounts/byYearAndWeek/2017/49
        [HttpGet("byYearAndWeek/{Year}/{Week}")]
        public IEnumerable<ItemCount> GetByYearAndWeek(int Year, int Week)
        {
            try
            {
                ItemCount searchItemCount = new ItemCount();
                searchItemCount.Year = Year;
                searchItemCount.Week = Week;
                return service.GetBy(searchItemCount);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // GET api/itemCounts/byYearAndWeekAndSku/2017/49/612332
        [HttpGet("byYearAndWeekAndSku/{Year}/{Week}/{Sku}")]
        public IEnumerable<ItemCount> GetByYearAndWeekAndSku(int Year, int Week, int Sku)
        {
            try
            {
                ItemCount searchItemCount = new ItemCount();
                searchItemCount.Year = Year;
                searchItemCount.Week = Week;
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
