using System;
using Xunit;
using NSubstitute;
using WarehouseServices.Infrastructure;
using Microsoft.Extensions.Configuration;
using WarehouseRepository;

namespace WarehouseRepositoryTests
{
    public class ItemCountRepositoryTest
    {
        private ItemCountRepository sut;
        private IConfiguration configurationFake;
        private string warehouseDBConnectionString;

        public ItemCountRepositoryTest()
        {
            warehouseDBConnectionString = "Server=memsqldw;Database=DWPROD;Trusted_Connection=True;User ID=Warehouse.APi.Prod;password=89=discover=STEEL=vermont;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;connect timeout=180;";
            configurationFake = Substitute.For<IConfiguration>();
            configurationFake.GetConnectionString("WarehouseDB").Returns(warehouseDBConnectionString);
            sut = new ItemCountRepository(configurationFake);
        }

        [Fact(Skip = "connection timemout sqlexception if run with all tests")]
        public void GetByYearAndWeek_ValidYearWeek_ReturnItemCounts()
        {
            //arrange
            var valid = new ItemCount();
            valid.Year = 2017;
            valid.Week = 40;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact(Skip = "connection timemout sqlexception")]
        public void GetByYearAndWeek_InvalidYearWeek_ReturnEmpty()
        {
            //arrange
            var invalid = new ItemCount();
            invalid.Year = 999999;
            invalid.Week = 99999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact(Skip = "connection timemout sqlexception if run with all tests")]
        public void GetBySku_ValidSku_ReturnItemCounts()
        {
            //arrange
            var valid = new ItemCount();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact(Skip = "connection timemout sqlexception")]
        public void GetBySku_InvalidSku_ReturnEmpty()
        {
            //arrange
            var invalid = new ItemCount();
            invalid.Sku = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }


        [Fact(Skip = "connection timemout sqlexception if run with all tests")]
        public void GetByYearAndWeekAndSku_ValidYearWeekSku_ReturnItemCount()
        {
            //arrange
            var valid = new ItemCount();
            valid.Year = 2017;
            valid.Week = 40;
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact(Skip = "connection timemout sqlexception")]
        public void GetByYearAndWeekAndSku_InvalidYearWeekSku_ReturnEmpty()
        {
            //arrange
            var invalid = new ItemCount();
            invalid.Year = 2017;
            invalid.Week = 40;
            invalid.Sku = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }
    }
}
