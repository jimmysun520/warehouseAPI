using System;
using Xunit;
using NSubstitute;
using WarehouseServices.Infrastructure;
using Microsoft.Extensions.Configuration;
using WarehouseRepository;

namespace WarehouseRepositoryTests
{
    public class RecentShipmentRepositoryTest
    {
        private RecentShipmentRepository sut;
        private IConfiguration configurationFake;
        private string warehouseDBConnectionString;

        public RecentShipmentRepositoryTest()
        {
            warehouseDBConnectionString = "Server=memsqldw;Database=DWPROD;Trusted_Connection=True;User ID=Warehouse.APi.Prod;password=89=discover=STEEL=vermont;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;connect timeout=100;";
            configurationFake = Substitute.For<IConfiguration>();
            configurationFake.GetConnectionString("WarehouseDB").Returns(warehouseDBConnectionString);
            sut = new RecentShipmentRepository(configurationFake);
        }

        [Fact(Skip = "no guarantee of which store will always be there")]
        public void GetByStoreId_ValidStoreId_ReturnShipments()
        {
            //arrange
            var valid = new RecentShipment();
            valid.Store = 1088;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetByStoreId_InvalidStoreId_ReturnEmpty()
        {
            //arrange
            var invalid = new RecentShipment();
            invalid.Store = 9999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetAll_ReturnShipments()
        {
            //arrange
            var valid = new RecentShipment();

            //act
            var result = sut.GetAll();

            //assert
            Assert.NotEmpty(result);
        }
    }
}
