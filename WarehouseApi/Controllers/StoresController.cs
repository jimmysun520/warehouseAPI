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
    public class StoresController : Controller
    {
        private readonly IStoreService service;
        public StoresController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IStoreService>();

        // get store info by store id
        // GET api/stores/5
        [HttpGet("{StoreId}")]
        public IEnumerable<Store> Get(int StoreId)
        {
            try
            {
                Store searchStore = new Store();
                searchStore.StoreId = StoreId;
                return service.GetBy(searchStore);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // get stores
        // GET api/stores
        [HttpGet("")]
        public IEnumerable<Store> GetAll()
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
