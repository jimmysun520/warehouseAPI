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
    public class ShipmentsController : Controller
    {
        private readonly IShipmentService service;
        public ShipmentsController(IServiceProvider serviceProvider) =>
            service = serviceProvider.GetRequiredService<IShipmentService>();

        // GET api/shipments/bySkuAndStore/5/1001/1100001
        [HttpGet("bySkuAndStoreIdAndInvoiceId/{Sku}/{StoreId}/{InvoiceId}")]
        public IEnumerable<Shipment> GetBySkuAndStoreIdAndInvoiceId(int Sku, int StoreId, int InvoiceId)
        {
            try
            {
                Shipment searchShipment = new Shipment();
                searchShipment.Sku = Sku;
                searchShipment.Store = StoreId;
                searchShipment.Invoice = InvoiceId;
                return service.GetBy(searchShipment);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // GET api/shipments/bySku/5/1001
        [HttpGet("bySkuAndStoreId/{Sku}/{StoreId}")]
        public IEnumerable<Shipment> GetBySkuAndStoreId(int Sku, int StoreId)
        {
            try
            {
                Shipment searchShipment = new Shipment();
                searchShipment.Sku = Sku;
                searchShipment.Store = StoreId;
                return service.GetBy(searchShipment);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // GET api/shipments/bySkuAndInvoice/5/10
        [HttpGet("bySkuAndInvoiceId/{Sku}/{InvoiceId}")]
        public IEnumerable<Shipment> GetBySkuAndInvoiceId(int Sku, int InvoiceId)
        {
            try
            {
                Shipment searchShipment = new Shipment();
                searchShipment.Sku = Sku;
                searchShipment.Invoice = InvoiceId;
                return service.GetBy(searchShipment);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }

        // get store info by Sku
        // GET api/shipments/bySku/5
        [HttpGet("bySku/{Sku}")]
        public IEnumerable<Shipment> GetBySku(int Sku)
        {
            try
            {
                Shipment searchShipment = new Shipment();
                searchShipment.Sku = Sku;
                return service.GetBy(searchShipment);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }
        // get store info by storeId
        // GET api/shipments/byStoreId/5
        [HttpGet("byStoreId/{StoreId}")]
        public IEnumerable<Shipment> GetByStoreId(int StoreId)
        {
            try
            {
                Shipment searchShipment = new Shipment();
                searchShipment.Store = StoreId;
                return service.GetBy(searchShipment);
            }
            catch (Exception ex)
            {
                HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
                HttpContext.Items.Add("ErrorMessage", ex.Message);
                throw ex;
            }
        }
        // get store info by InvoiceId
        // GET api/shipments/byInvoiceId/5
        [HttpGet("byInvoiceId/{InvoiceId}")]
        public IEnumerable<Shipment> GetByInvoiceId(int InvoiceId)
        {
            try
            {
                Shipment searchShipment = new Shipment();
                searchShipment.Invoice = InvoiceId;
                return service.GetBy(searchShipment);
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