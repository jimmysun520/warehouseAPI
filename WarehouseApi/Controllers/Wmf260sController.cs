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
//     public class Wmf260sController : Controller
//     {
//         private readonly IWmf260Service service;
//         public Wmf260sController(IServiceProvider serviceProvider) =>
//             service = serviceProvider.GetRequiredService<IWmf260Service>();

//         // get Wmf260_Detail record by sku
//         // GET api/wmf260s/5
//         [HttpGet("{sku}")]
//         public IEnumerable<IWmf260> GetBy(int sku)
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

//         // get Wmf260Details
//         // GET api/wmf260s
//         [HttpGet("")]
//         public IEnumerable<IWmf260> GetAll()
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
