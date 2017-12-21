using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WarehouseServices.Repositories;
using WarehouseServices.Infrastructure;

namespace WarehouseRepository
{
    public class ShipmentRepository : IShipmentRepository
    {
        public string _connectionString { get; set; }

        public ShipmentRepository(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("WarehouseDB");

        public IEnumerable<Shipment> GetBy(Shipment shipment)
        {
            using (var context = new SqlConnection(_connectionString))
            {
                var query = @"SELECT TOP (1000) [Store]
                        ,[InvoiceNbr]   AS Invoice
                        ,[TruckDay]
                        ,[InvoiceDate]
                        ,[sku ] AS Sku
                        ,[Qty]  AS Quantity
                        ,[ProcessDate]
                    FROM [DWPROD].[dbo].[WMF260_Detail]
                    WHERE (@Store IS NULL OR [Store] = @Store)
                    AND (@Invoice IS NULL OR [InvoiceNbr] = @Invoice)
                    AND (@TruckDay IS NULL OR [TruckDay] = @TruckDay)
                    AND (@InvoiceDate IS NULL OR [InvoiceDate] = @InvoiceDate)
                    AND (@Sku IS NULL OR [sku ] = @Sku)
                    AND (@Quantity IS NULL OR [Qty ] = @Quantity)
                    AND (@ProcessDate IS NULL OR [ProcessDate] = @ProcessDate)
                    ";
                return context.Query<Shipment>(query, shipment);
            }
        }

        public IEnumerable<Shipment> GetAll() => this.GetBy(new Shipment());
    }
}
