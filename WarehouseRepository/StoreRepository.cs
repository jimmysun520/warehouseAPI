using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WarehouseServices.Repositories;
using WarehouseServices.Infrastructure;

namespace WarehouseRepository
{
    public class StoreRepository : IStoreRepository
    {
        public string _connectionString { get; set; }

        public StoreRepository(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("WarehouseDB");

        public IEnumerable<Store> GetAll() => this.GetBy(new Store());

        public IEnumerable<Store> GetBy(Store store)
        {
            using (var context = new SqlConnection(_connectionString))
            {
                var query = @"SELECT [DW_STORE] AS StoreId
                    ,[DATE_ON_SWORD]    AS DateOnSword
                    ,[STORE_STATUS]     AS Status
                    ,[STORE_PHONE]      AS Phone
                    ,[STORE_NAME]       AS Name
                    ,[STORE_ST_adr1]    AS StreetAddress1
                    ,[STORE_ST_adr2]    AS StreetAddress2
                    ,[STORE_CITY]       AS City
                    ,[STORE_STATE]      AS State
                    ,[STORE_ZIP]        AS Zip
                    ,[STORE_type]       AS Type
                    ,[STORE_ar_con]     AS ArCon
                    ,[STORE_region]     AS Region
                    ,[STORE_ar_dt_lt_phys]  AS AccountReceivableDateLastPhysical
                    ,[STORE_ware_hse]   AS Warehouse
                    ,[STORE_area_ft]    AS TotalAreaInFoot
                    ,[STORE_sales_ft]   AS SalesAreaInFoot
                    ,[STORE_back_rm_area]   AS BackRoomAreaInFoot
                    ,[STORE_parking_area]   AS ParkingArea
                    ,[STORE_INV_PER_FT]     AS InvPerFt
                    ,[STORE_OPEN_DT]        AS OpenDate
                    ,[STORE_CLOSE_DT]       AS CloseDate
                    ,[COMP_STORE_DT]        AS CompDate
                    ,[last_expansion]       AS LastExpansionDate
                    ,[STORE_msi_day_code]   AS MsiDayCode
                    ,[STORE_rep_code_77]    AS ReplenishCode
                    ,[STORE_mgr]            AS Manager
                    ,[STORE_area_popula]    AS AreaPopulation
                    ,[CMPT_AREA_FT_1]       AS CmptAreaFt
                    ,[CMPT_SALES_FT_1]      AS CmptSalesFt
                    ,[CMPT_OPEN_DT_1]   AS CmptOpenDate
                    ,[CMPT_CODE_1]          AS CmptCode
                    ,[STORE_REP_CYCLE_77]   AS ReplenishCycle
                    FROM [DWPROD].[dbo].[DWF165_STORE]
                    WHERE (@storeId IS NULL OR [DW_STORE] = @storeId)
                    AND (@dateOnSword IS NULL OR DATE_ON_SWORD = @dateOnSword)
                    AND (@Phone IS NULL OR STORE_PHONE = @Phone)
                    AND (@City IS NULL OR STORE_CITY = @City)
                    AND (@State IS NULL OR STORE_STATE = @State)
                    AND (@Zip IS NULL OR STORE_ZIP = @Zip)
                    AND (@Status IS NULL OR STORE_STATUS = @Status)
                    AND (@Type IS NULL OR STORE_type = @Type)
                    AND (@ArCon IS NULL OR STORE_ar_con = @ArCon)
                    AND (@Region IS NULL OR STORE_region = @Region)
                    AND (@Warehouse IS NULL OR STORE_ware_hse = @Warehouse)
                    AND (@OpenDate IS NULL OR STORE_OPEN_DT = @OpenDate)
                    AND (@CloseDate IS NULL OR STORE_CLOSE_DT = @CloseDate)
                    AND (@CompDate IS NULL OR COMP_STORE_DT = @CompDate)
                    AND (@LastExpansionDate IS NULL OR last_expansion = @LastExpansionDate)
                    AND (@MsiDayCode IS NULL OR STORE_msi_day_code = @MsiDayCode)
                    AND (@ReplenishCode IS NULL OR STORE_rep_code_77 = @ReplenishCode)
                    AND (@Manager IS NULL OR STORE_mgr = @Manager)
                    AND (@AreaPopulation IS NULL OR STORE_area_popula = @AreaPopulation)
                    AND (@ReplenishCycle IS NULL OR STORE_REP_CYCLE_77 = @ReplenishCycle)
                    ";
                return context.Query<Store>(query, store);
            }
        }
    }
}
