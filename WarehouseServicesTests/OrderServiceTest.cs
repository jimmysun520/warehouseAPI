using System;
using Xunit;
using NSubstitute;
using WarehouseServices;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServicesTests
{
    public class OrderServiceTest
    {
        private OrderService sut;
        private IOrderRepository iRepositoryFake;
        
        public OrderServiceTest()
        {
            iRepositoryFake = Substitute.For<IOrderRepository>();
            sut = new OrderService(iRepositoryFake);
        }

        [Fact]
        public void GetBy_validOrder_ReturnOrders()
        {
            //arrange
            var valid = new Order();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            iRepositoryFake.Received(1).GetBy(valid);
        }
    }
}