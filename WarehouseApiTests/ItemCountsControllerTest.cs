using System;
using Xunit;
using WarehouseServices.Infrastructure;
using WarehouseServices.Contracts;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace WarehouseApiTests
{
    public class ItemCountsControllerTest
    {
        private IServiceProvider serviceProviderFake;
        private IItemCountService itemCountServiceFake;
        public ItemCountsControllerTest()
        {
            serviceProviderFake = Substitute.For<IServiceProvider>();
            itemCountServiceFake = Substitute.For<IItemCountService>();
        }

        [Theory]
        [InlineData(612332)]
        public void GetBySku_ReturnValidItemCount(int validSku)
        {
            //arrange
            var sut = new WarehouseApi.Controllers.ItemCountsController(serviceProviderFake);

            //act
            var arr = sut.GetBySku(validSku);

            //asert
            Assert.NotEmpty(arr);
        }

        [Theory]
        [InlineData(00000)]
        public void GetBySku_ReturnEmptyItemCount(int invalidSku)
        {
            //arrange
            var sut = new WarehouseApi.Controllers.ItemCountsController(serviceProviderFake);

            //act
            var arr = sut.GetBySku(invalidSku);

            //asert
            Assert.Empty(arr);

        }
        
        // [Fact]
        // public void getItemTest(int itemSku, string dcCode)
        // {
        //     // give sku, dcCode, return item info: SKU, Department, quantity on hand, description, pack, cost, store cost, retail, WGI

        // }

        // [Fact]
        // public void getOrderHistorysTest(int itemSku, string dcCode)
        // {
        //     // give sku, dcCode, return order historys containing: shipped date, order (invoice number), day count (???), OType, StoreId, Ordered Amount, Allocated Amount, Picked Amount
        //     // rows in either 120 or 260 (most recent)

        // }
        // [Fact]
        // public void getStoreTest(int storeId)
        // {
        //     // give storeId, return store info: StoreId, Franchise (Y/N), Address, City, Zip

        // }
        // [Fact]
        // public void getShipmentsTest(int itemSku, int storeId)
        // {
        //     // give itemSku, storeId, return all shipments history info contains: shipped date, order (invoice number), Picked Amount (?), Ex Cost (?), Ex Store Cost, Ex Retail.

        // }
    }
}
