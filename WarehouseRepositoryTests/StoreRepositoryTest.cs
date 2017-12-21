using System;
using Xunit;
using NSubstitute;
using WarehouseServices.Infrastructure;
using Microsoft.Extensions.Configuration;
using WarehouseRepository;

namespace WarehouseRepositoryTests
{
    public class StoreRepositoryTest
    {
        private StoreRepository sut;
        private IConfiguration configurationFake;
        private string warehouseDBConnectionString;

        public StoreRepositoryTest()
        {
            warehouseDBConnectionString = "Server=memsqldw;Database=DWPROD;Trusted_Connection=True;User ID=Warehouse.APi.Prod;password=89=discover=STEEL=vermont;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;connect timeout=100;";
            configurationFake = Substitute.For<IConfiguration>();
            configurationFake.GetConnectionString("WarehouseDB").Returns(warehouseDBConnectionString);
            sut = new StoreRepository(configurationFake);
        }

        [Fact]
        public void GetBy_ValidStoreId_ReturnStores()
        {
            //arrange
            Store validStore = new Store();
            validStore.StoreId = 1088;

            //act
            var result = sut.GetBy(validStore);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBy_InvalidStoreId_ReturnEmpty()
        {
            //arrange
            Store invalidStore = new Store();
            invalidStore.StoreId = 0000;

            //act
            var result = sut.GetBy(invalidStore);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBy_InvalidShorterStoreId_ReturnEmpty()
        {
            //arrange
            Store invalidStore = new Store();
            invalidStore.StoreId = 002;

            //act
            var result = sut.GetBy(invalidStore);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBy_InvalidLongerStoreId_ReturnEmpty()
        {
            //arrange
            Store invalidStore = new Store();
            invalidStore.StoreId = 0000001;

            //act
            var result = sut.GetBy(invalidStore);
            //assert
            Assert.Empty(result);
        }



        [Fact]
        public void GetAll_ReturnStores()
        {
            //arrange

            //act
            var result = sut.GetAll();

            //assert
            Assert.NotEmpty(result);
        }
    }
}
