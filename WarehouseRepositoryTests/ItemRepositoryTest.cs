using System;
using Xunit;
using NSubstitute;
using WarehouseServices.Infrastructure;
using Microsoft.Extensions.Configuration;
using WarehouseRepository;

namespace WarehouseRepositoryTests
{
    public class ItemRepositoryTest
    {
        private ItemRepository sut;
        private IConfiguration configurationFake;
        private string warehouseDBConnectionString;

        public ItemRepositoryTest()
        {
            warehouseDBConnectionString = "Server=memsqldw;Database=DWPROD;Trusted_Connection=True;User ID=Warehouse.APi.Prod;password=89=discover=STEEL=vermont;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;connect timeout=100;";
            configurationFake = Substitute.For<IConfiguration>();
            configurationFake.GetConnectionString("WarehouseDB").Returns(warehouseDBConnectionString);
            sut = new ItemRepository(configurationFake);
        }

        [Fact]
        public void GetBy_ValidSku_ReturnItem()
        {
            //arrange
            var valid = new Item();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBy_InvalidSku_ReturnEmpty()
        {
            //arrange
            var invalid = new Item();
            invalid.Sku = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }
    }
}
