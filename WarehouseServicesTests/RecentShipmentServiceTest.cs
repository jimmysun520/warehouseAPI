using System;
using Xunit;
using NSubstitute;
using WarehouseServices;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServicesTests
{
    public class RecentShipmentServiceTest
    {
        private RecentShipmentService sut;
        private IRecentShipmentRepository iRepositoryFake;
        
        public RecentShipmentServiceTest()
        {
            iRepositoryFake = Substitute.For<IRecentShipmentRepository>();
            sut = new RecentShipmentService(iRepositoryFake);
        }

        [Fact]
        public void GetBy_validRecentShipment_ReturnRecentShipments()
        {
            //arrange
            var valid = new RecentShipment();

            //act
            var result = sut.GetBy(valid);

            //assert
            iRepositoryFake.Received(1).GetBy(valid);
        }
    }
}