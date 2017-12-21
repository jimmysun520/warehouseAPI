using System;
using Xunit;
using NSubstitute;
using WarehouseServices;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServicesTests
{
    public class ShipmentServiceTest
    {
        private ShipmentService sut;
        private IShipmentRepository iRepositoryFake;
        
        public ShipmentServiceTest()
        {
            iRepositoryFake = Substitute.For<IShipmentRepository>();
            sut = new ShipmentService(iRepositoryFake);
        }

        [Fact]
        public void GetBy_validShipment_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            iRepositoryFake.Received(1).GetBy(valid);
        }
    }
}