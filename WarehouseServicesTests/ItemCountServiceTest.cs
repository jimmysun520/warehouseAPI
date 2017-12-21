using System;
using Xunit;
using NSubstitute;
using WarehouseServices;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServicesTests
{
    public class ItemCountServiceTest
    {
        private ItemCountService sut;
        private IItemCountRepository iRepositoryFake;
        
        public ItemCountServiceTest()
        {
            iRepositoryFake = Substitute.For<IItemCountRepository>();
            sut = new ItemCountService(iRepositoryFake);
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