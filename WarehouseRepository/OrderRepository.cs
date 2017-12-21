using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WarehouseServices.Repositories;
using WarehouseServices.Infrastructure;

namespace WarehouseRepository
{
    public class OrderRepository : IOrderRepository
    {
        public string _connectionString { get; set; }

        public OrderRepository(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("WarehouseDB");

        public IEnumerable<Order> GetAll() => this.GetBy(new Order());

        public IEnumerable<Order> GetBy(Order order)
        {
            using (var context = new SqlConnection(_connectionString))
            {
                var query = @"SELECT  TOP (1000)
                                [STORE120]     AS Store
                                ,[SKU_NUMBER120]    AS Sku
                                ,[ORDER_DATE120]    AS OrderDate
                                ,[SHIP_DATE120]     AS ShipDate
                                ,[ORDER_QUANTITY120]    AS OrderQuantity
                                ,[SHIP_QUANTITY120]     AS ShipQuantity
                                ,[ORDER_TYPE120]    AS OrderType
                                ,[NOFILL_REASON120] AS NofillReason
                                ,[RUN_NUMBER120]    AS RunNumber
                                ,[DAY_CODE120]  AS DayCode
                                ,[ITEM_DESC120] AS ItemDescription
                                ,[PICK_PACK120] AS PickPack
                                ,[CASES120]     AS OrderCase
                                ,[GL_NUMBER120] AS LedgerNumber
                                ,[GL_SUB_ACCT120] AS LedgerSubAccount
                                ,[RETAILPRICE120] AS RetailPrice
                                ,[WHSE_SALEPRICE120] AS WarehouseSalePrice
                                ,[COST120]      AS Cost
                                ,[INVOICE_NUMBER120]    AS Invoice
                                ,[CASE_NUMBER120]   AS CaseNumber
                                ,[DAMAGE_CODE120] AS DamageCode
                                ,[TAX_CODE120] AS TaxCode
                                ,[ITEM_TYPE120] AS ItemType
                                ,[CYCLE_NUMBER120] AS CycleNumber
                                ,[DOWNLOAD_SW120] AS Downloaded
                                ,[UPLOAD_SW120] AS Uploaded
                                ,[CIMS_SW120] AS CIMsSwitch
                                ,[BACKORDER_SW120] AS Backorder
                                ,[ON_RESERVE120] AS OnReserve
                                ,[WHSE_NBR120] AS WarehouseNumber
                            FROM [DWPROD].[dbo].[DWF120_Orders]
                            WHERE (@Store IS NULL OR [STORE120] = @Store)
                            AND (@Sku IS NULL OR [SKU_NUMBER120] = @Sku)
                            AND (@OrderDate IS NULL OR [ORDER_DATE120] = @OrderDate)
                            AND (@ShipDate IS NULL OR [SHIP_DATE120] = @ShipDate)
                            AND (@OrderQuantity IS NULL OR [ORDER_QUANTITY120] = @OrderQuantity)
                            AND (@ShipQuantity IS NULL OR [SHIP_QUANTITY120] = @ShipQuantity)
                            AND (@OrderType IS NULL OR [ORDER_TYPE120] = @OrderType)
                            AND (@NofillReason IS NULL OR [NOFILL_REASON120] = @NofillReason)
                            AND (@RunNumber IS NULL OR [RUN_NUMBER120] = @RunNumber)
                            AND (@DayCode IS NULL OR [DAY_CODE120] = @DayCode)
                            AND (@ItemDescription IS NULL OR [ITEM_DESC120] = @ItemDescription)
                            AND (@PickPack IS NULL OR [PICK_PACK120] = @PickPack)
                            AND (@OrderCase IS NULL OR [CASES120] = @OrderCase)
                            AND (@LedgerNumber IS NULL OR [GL_NUMBER120] = @LedgerNumber)
                            AND (@LedgerSubAccount IS NULL OR [GL_SUB_ACCT120] = @LedgerSubAccount)
                            AND (@RetailPrice IS NULL OR [RETAILPRICE120] = @RetailPrice)
                            AND (@WarehouseSalePrice IS NULL OR [WHSE_SALEPRICE120] = @WarehouseSalePrice)
                            AND (@Cost IS NULL OR [COST120] = @Cost)
                            AND (@Invoice IS NULL OR [INVOICE_NUMBER120] = @Invoice)
                            AND (@CaseNumber IS NULL OR [CASE_NUMBER120] = @CaseNumber)
                            AND (@DamageCode IS NULL OR [DAMAGE_CODE120] = @DamageCode)
                            AND (@TaxCode IS NULL OR [TAX_CODE120] = @TaxCode)
                            AND (@ItemType IS NULL OR [ITEM_TYPE120] = @ItemType)
                            AND (@CycleNumber IS NULL OR [CYCLE_NUMBER120] = @CycleNumber)
                            AND (@Downloaded IS NULL OR [DOWNLOAD_SW120] = @Downloaded)
                            AND (@Uploaded IS NULL OR [UPLOAD_SW120] = @Uploaded)
                            AND (@CIMsSwitch IS NULL OR [CIMS_SW120] = @CIMsSwitch)
                            AND (@Backorder IS NULL OR [BACKORDER_SW120] = @Backorder)
                            AND (@OnReserve IS NULL OR [ON_RESERVE120] = @OnReserve)
                            AND (@WarehouseNumber IS NULL OR [WHSE_NBR120] = @WarehouseNumber)
                            ";
                return context.Query<Order>(query, order);
            }
        }
    }
}
