// using System.Data.SqlClient;
// using Dapper;
// using Microsoft.Extensions.Configuration;
// // using System.Linq;
// // using System.Data;
// using System.Collections.Generic;
// using WarehouseData.Contracts;
// using WarehouseData.Models;
// using WarehouseServices.Repositories;

// namespace WarehouseRepository
// {
//     public class Dwf170DcSkuRepository : IDwf170DcSkuRepository
//     {
//         public string _connectionString { get; set; }

//         public Dwf170DcSkuRepository(IConfiguration configuration) =>
//             _connectionString = configuration.GetConnectionString("WarehouseDB");

//         public IEnumerable<IDwf170DcSku> GetAll() => this.GetBy(null);

//         public IEnumerable<IDwf170DcSku> GetBy(int? sku)
//         {
//             using (var context = new SqlConnection(_connectionString))
//             {
//                 var query = @"SELECT TOP (1000) [DWYEAR]
//                         ,[DWEEK]
//                         ,[DC_NUM]
//                         ,[DWSKU]
//                         ,[F_RECEPIT_DT]
//                         ,[L_RECEPIT_DT]
//                         ,[L_SHIP_DT]
//                         ,[COST]
//                         ,[RESERVE_TOT]
//                         ,[ONHAND]
//                         ,[ALLOCATED_QTY]
//                         ,[SHIP_UNITS]
//                         ,[RCPT_UNITS]
//                         ,[LW_UNITS_MIN]
//                         ,[LW_STORE_MIN]
//                         ,[LW_NBR_STORES]
//                         ,[STORE_UNITS_SLS]
//                         ,[AONORD_RTL]
//                         ,[AONORD_UNITS]
//                         ,[OUT_OF_STOCK]
//                     FROM [DWPROD].[dbo].[DWF170_DCSKU]
//                     WHERE (@sku IS NULL OR [DWSKU] = @sku)
//                     ";
//                 return context.Query<Dwf170DcSku>(query, new { sku });
//             }
//         }
//     }
// }
