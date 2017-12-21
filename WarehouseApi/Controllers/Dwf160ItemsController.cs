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
//     public class Dwf160ItemsController : Controller
//     {
//         private readonly IDwf160ItemService service;
//         public Dwf160ItemsController(IServiceProvider serviceProvider) =>
//             service = serviceProvider.GetRequiredService<IDwf160ItemService>();

//         // get item by sku
//         // GET api/dwf160items/5
//         [HttpGet("{sku}")]
//         public IEnumerable<IDwf160Item> GetBy(int sku)
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

//         // get all items
//         // GET api/dwf160items
//         [HttpGet("")]
//         public IEnumerable<IDwf160Item> GetAll()
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
