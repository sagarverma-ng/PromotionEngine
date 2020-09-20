using System;
using NUnit.Framework;
using PromotionEngine;

namespace Nunit.Test
{
    [TestFixture]
    public class PromotionEngineTest
    {
        [Test]
        public void Test_GetPriceByProductType_WithNull()
        {
            ProductService productService = new ProductService();
            var result = productService.GetPriceByProductType(null);
            Product product = null;
            Assert.AreEqual(product, result);
        }

        [Test]
        public void Test_GetPriceByProductType_WithNullId()
        {
            ProductService productService = new ProductService();
            var result = productService.GetPriceByProductType(new Product() { Id = null });
            var product = new Product();
            Assert.AreSame(product.Id, result.Id);
            Assert.AreSame(product.Price, result.Price);
        }

        [Test]
        public void Test_GetPriceByProductType_WithValidProductId()
        {
            ProductService productService = new ProductService();
            var result = productService.GetPriceByProductType(new Product() { Id = "d", Price = null });
            var product = new Product { Id = "d", Price = 2015 };
            Assert.AreSame(product.Id, result.Id);
            Assert.That(Math.Abs(Convert.ToDecimal(product.Price - result.Price)), Is.LessThan(0.0001M));
        }

        [Test]
        public void Test_GetPriceByProductType_WithInvalidProductId()
        {
            ProductService productService = new ProductService();
            var result = productService.GetPriceByProductType(new Product() { Id = "z"});
            var product = new Product { Id = "z", Price = null };
            Assert.AreSame(product.Id, result.Id);
            Assert.AreSame(product.Price, result.Price);
        }

        [Test]
        public void Test_GetTotalPriceWithNull()
        {
            ProductService productService = new ProductService();
            var result = productService.GetTotalPrice(null);
            Assert.AreEqual(0, result);
        }
    }
}
