using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WarehouseServices.Repositories;
using WarehouseServices.Infrastructure;

namespace WarehouseRepository
{
    public class RecentShipmentRepository : IRecentShipmentRepository
    {
        public string _connectionString { get; set; }

        public RecentShipmentRepository(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("WarehouseDB");

        public IEnumerable<RecentShipment> GetBy(RecentShipment recentShipment)
        {
            using (var context = new SqlConnection(_connectionString))
            {
                var query = @"SELECT 
                            [Store]
                            ,[ProcessDate]
                        FROM [DWPROD].[dbo].[wmf260_Distinct_Store]
                    WHERE (@Store IS NULL OR [Store] = @Store)
                    ";
                return context.Query<RecentShipment>(query, recentShipment);
            }
        }

        public IEnumerable<RecentShipment> GetAll() => this.GetBy(new RecentShipment());
    }
}
