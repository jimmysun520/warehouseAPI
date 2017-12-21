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
//     public class Wmf260DistinctStoresController : Controller
//     {
//         private readonly IWmf260DistinctStoreService service;
//         public Wmf260DistinctStoresController(IServiceProvider serviceProvider) =>
//             service = serviceProvider.GetRequiredService<IWmf260DistinctStoreService>();

//         // get Wmf260_Distinct_Store record by storeId
//         // GET api/wmf260DistinctStores/5
//         [HttpGet("{storeId}")]
//         public IEnumerable<IWmf260DistinctStore> GetBy(int storeId)
//         {
//             try
//             {
//                 return service.GetBy(storeId);
//             }
//             catch (Exception ex)
//             {
//                 HttpContext.Items.Add("StatusCode", HttpStatusCode.InternalServerError);
//                 HttpContext.Items.Add("ErrorMessage", ex.Message);
//                 throw ex;
//             }
//         }

//         // get Wmf260_Distinc_Store records
//         // GET api/wmf260DistinctStores
//         [HttpGet("")]
//         public IEnumerable<IWmf260DistinctStore> GetAll()
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
