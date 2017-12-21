using System;
using Xunit;
using NSubstitute;
using WarehouseServices;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServicesTests
{
    public class ItemCountRecentServiceTest
    {
        private ItemCountRecentService sut;
        private IItemCountRecentRepository iRepositoryFake;
        
        public ItemCountRecentServiceTest()
        {
            iRepositoryFake = Substitute.For<IItemCountRecentRepository>();
            sut = new ItemCountRecentService(iRepositoryFake);
        }

        [Fact]
        public void GetBy_validItemCount_ReturnItemCounts()
        {
            //arrange
            var valid = new ItemCount();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            iRepositoryFake.Received(1).GetBy(valid);
        }
    }
}