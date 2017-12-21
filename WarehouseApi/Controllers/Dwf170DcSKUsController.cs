// using System;
// using System.Collections.Generic;
// using System.Net;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.DependencyInjection;
// using WarehouseServices.Contracts;
// using WarehouseData.Contracts;

// namespace WarehouseApi.Controllers
// {
//     [Route("api/[controller]")]
//     public class Dwf170DcSKUsController : Controller
//     {
//         private readonly IDwf170DcSkuService service;
//         public Dwf170DcSKUsController(IServiceProvider serviceProvider) =>
//             service = serviceProvider.GetRequiredService<IDwf170DcSkuService>();

//         // get Dwf170DcSKU record by sku
//         // GET api/Dwf170DcSKUs/5
//         [HttpGet("{sku}")]
//         public IEnumerable<IDwf170DcSku> GetBy(int sku)
//         {
//             try
//             {
//                 return service.GetBy(sku);
//             }
//             catch (Exception ex)
//             {
//                 HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
//                 HttpContext.Items.Add("ErrorMessage", ex.Message);
//                 throw ex;
//             }
//         }

//         // get all Dwf170DcSKU records
//         // GET api/Dwf170DcSKUs
//         [HttpGet("")]
//         public IEnumerable<IDwf170DcSku> GetAll()
//         {
//             try
//             {
//                 return service.GetAll();
//             }
//             catch (Exception ex)
//             {
//                 HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
//                 HttpContext.Items.Add("ErrorMessage", ex.Message);
//                 throw ex;
//             }
//         }
//     }
// }
