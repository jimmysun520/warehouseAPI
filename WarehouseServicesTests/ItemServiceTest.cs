using System;
using Xunit;
using NSubstitute;
using WarehouseServices;
using WarehouseServices.Infrastructure;
using WarehouseServices.Repositories;

namespace WarehouseServicesTests
{
    public class ItemServiceTest
    {
        private ItemService sut;
        private IItemRepository iRepositoryFake;
        
        public ItemServiceTest()
        {
            iRepositoryFake = Substitute.For<IItemRepository>();
            sut = new ItemService(iRepositoryFake);
        }

        [Fact]
        public void GetBy_validItem_ReturnItems()
        {
            //arrange
            var valid = new Item();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            iRepositoryFake.Received(1).GetBy(valid);
        }
    }
}