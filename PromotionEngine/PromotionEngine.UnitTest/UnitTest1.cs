using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Business;

namespace PromotionEngine.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddNewPromotionRule()
        {

            PromotionEngine promotionEngine = new PromotionEngine();
            CartManager promotedCartManager = new CartManager(new PromotionEngine());
            Product product1 = new Product() { Id = 1, Name = "A", Price = 50 };
            Product product2 = new Product() { Id = 2, Name = "B", Price = 30 };
            Product product3 = new Product() { Id = 3, Name = "C", Price = 20 };
            Product product4 = new Product() { Id = 4, Name = "D", Price = 15 };

            Cart cart = new Cart() { Id = 1 };
            cart.AddItems(new CartItem() { Product = product1, Quantity = 1 });
            cart.AddItems(new CartItem() { Product = product2, Quantity = 1 });
            cart.AddItems(new CartItem() { Product = product3, Quantity = 1 });
            int expected = 100;
            int actual;
            actual = promotionEngine.ApplyPromotion(cart);
            Assert.AreEqual(expected, actual);
        }
    
        [TestMethod]
        public void TestCheckoutCart()
        {
            
        }
    }
}
