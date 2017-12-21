using System;
using Xunit;
using NSubstitute;
using WarehouseServices.Infrastructure;
using Microsoft.Extensions.Configuration;
using WarehouseRepository;

namespace WarehouseRepositoryTests
{
    public class OrderRepositoryTest
    {
        private OrderRepository sut;
        private IConfiguration configurationFake;
        private string warehouseDBConnectionString;

        public OrderRepositoryTest()
        {
            warehouseDBConnectionString = "Server=memsqldw;Database=DWPROD;Trusted_Connection=True;User ID=Warehouse.APi.Prod;password=89=discover=STEEL=vermont;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;connect timeout=100;";
            configurationFake = Substitute.For<IConfiguration>();
            configurationFake.GetConnectionString("WarehouseDB").Returns(warehouseDBConnectionString);
            sut = new OrderRepository(configurationFake);
        }

        [Fact]
        public void GetBy_ValidSku_ReturnOrders()
        {
            //arrange
            Order validOrder = new Order();
            validOrder.Sku = 612332;

            //act
            var result = sut.GetBy(validOrder);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBy_InvalidSku_ReturnEmptyOrder()
        {
            //arrange
            Order invalidOrder = new Order();
            invalidOrder.Sku = 000000;

            //act
            var result = sut.GetBy(invalidOrder);
            //assert
            Assert.Empty(result);
        }
    }
}
