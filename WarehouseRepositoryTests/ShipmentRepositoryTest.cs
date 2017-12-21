using System;
using Xunit;
using NSubstitute;
using WarehouseServices.Infrastructure;
using Microsoft.Extensions.Configuration;
using WarehouseRepository;

namespace WarehouseRepositoryTests
{
    public class ShipmentRepositoryTest
    {
        private ShipmentRepository sut;
        private IConfiguration configurationFake;
        private string warehouseDBConnectionString;

        public ShipmentRepositoryTest()
        {
            warehouseDBConnectionString = "Server=memsqldw;Database=DWPROD;Trusted_Connection=True;User ID=Warehouse.APi.Prod;password=89=discover=STEEL=vermont;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;connect timeout=100;";
            configurationFake = Substitute.For<IConfiguration>();
            configurationFake.GetConnectionString("WarehouseDB").Returns(warehouseDBConnectionString);
            sut = new ShipmentRepository(configurationFake);
        }

        [Fact]
        public void GetBySkuAndStoreAndInvoice_ValidSkuStoreInvoice_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
            valid.Store = 1088;
            valid.Sku = 612332;
            valid.Invoice = 578690;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBySkuAndStoreAndInvoice_InvalidSkuStoreInvoice_ReturnEmpty()
        {
            //arrange
            var invalid = new Shipment();
            invalid.Store = 9999;
            invalid.Sku = 999999;
            invalid.Invoice = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBySkuAndStoreId_ValidSkuStore_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
            valid.Store = 1088;
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBySkuAndStoreId_InvalidSkuStore_ReturnEmpty()
        {
            //arrange
            var invalid = new Shipment();
            invalid.Store = 9999;
            invalid.Sku = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBySkuAndInvoiceId_ValidSkuInvoice_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
            valid.Sku = 612332;
            valid.Invoice = 578690;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBySkuAndInvoiceId_InvalidSkuInvoice_ReturnEmpty()
        {
            //arrange
            var invalid = new Shipment();
            invalid.Sku = 999999;
            invalid.Invoice = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBySku_ValidSku_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
            valid.Sku = 612332;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetBySku_InvalidSku_ReturnEmpty()
        {
            //arrange
            var invalid = new Shipment();
            invalid.Sku = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetByStoreId_ValidStoreId_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
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
            var invalid = new Shipment();
            invalid.Store = 9999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetByInvoiceId_ValidInvoice_ReturnShipments()
        {
            //arrange
            var valid = new Shipment();
            valid.Invoice = 578690;

            //act
            var result = sut.GetBy(valid);

            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetByInvoiceId_InvalidInvoice_ReturnEmpty()
        {
            //arrange
            var invalid = new Shipment();
            invalid.Invoice = 999999;

            //act
            var result = sut.GetBy(invalid);
            //assert
            Assert.Empty(result);
        }
    }
}
