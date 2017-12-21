// using System.Data.SqlClient;
// using Dapper;
// using Microsoft.Extensions.Configuration;
// // using System.Linq;
// // using System.Data;
// using System.Collections.Generic;
// using WarehouseServices.Repositories;
// using WarehouseData.Contracts;
// using WarehouseData.Models;

// namespace WarehouseRepository
// {
//     public class Wmf260DistinctStoreRepository : IWmf260DistinctStoreRepository
//     {
//         public string _connectionString { get; set; }

//         public Wmf260DistinctStoreRepository(IConfiguration configuration) =>
//             _connectionString = configuration.GetConnectionString("WarehouseDB");

//         public IEnumerable<IWmf260DistinctStore> GetBy(int? storeId)
//         {
//             using (var context = new SqlConnection(_connectionString))
//             {
//                 var query = @"SELECT TOP (1000) [Store]
//                             ,[ProcessDate]
//                         FROM [DWPROD].[dbo].[wmf260_Distinct_Store]
//                     WHERE (@storeId IS NULL OR [Store] = @storeId)
//                     ";
//                 return context.Query<Wmf260DistinctStore>(query, new { storeId });
//             }
//         }

//         public IEnumerable<IWmf260DistinctStore> GetAll() => this.GetBy(null);

//         // /// return latest shipment to each store
//         // public IEnumerable<IWmf260> Wmf260DistinctStore(){
//         //     using (var context = new SqlConnection(_connectionString)){
//         //         var query = "SELECT [Store],[ProcessDate] FROM [DWPROD].[dbo].[wmf260_Distinct_Store]";
//         //         return context.Query<Wmf260DistinctStore>(query);
//         //     }
//         // }

//         // public IEnumerable<IWmf260> Wmf260DistinctStoreByStoreId(int storeId){
//         //     using (var context = new SqlConnection(_connectionString)){
//         //         var query = "SELECT [Store],[ProcessDate] FROM [DWPROD].[dbo].[wmf260_Distinct_Store] WHERE [Store} = @storeId";
//         //         return context.Query<Wmf260DistinctStore>(query, new {storeId});
//         //     }
//         // }
//     }
// }
