using PromotionEngine.Business;
using System.Collections.Generic;

namespace PromotionEngine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Product productA = new Product() { Id = 1, Name = "A", Price = 50 };
            Product productB = new Product() { Id = 2, Name = "B", Price = 30 };
            Product productC = new Product() { Id = 3, Name = "C", Price = 20 };
            Product productD = new Product() { Id = 4, Name = "D", Price = 15 };
            List<Product> products = new List<Product>();
            products.Add(productA);
            products.Add(productB);
            products.Add(productC);
            products.Add(productD);
            Cart cartA = new Cart() { Id = 1 };
            Cart cartB = new Cart() { Id = 1 };
            Cart cartC = new Cart() { Id = 1 };
            CartManager promotedCartManager = new CartManager(new PromotionEngine());

            //Scenario 1 added 
            promotedCartManager.AddProductToCart(cartA, productA, 1);
            promotedCartManager.AddProductToCart(cartA, productB, 1);
            promotedCartManager.AddProductToCart(cartA, productC, 1);

            //Scenario 2 added 
            promotedCartManager.AddProductToCart(cartB, productA, 5);
            promotedCartManager.AddProductToCart(cartB, productB, 5);
            promotedCartManager.AddProductToCart(cartB, productC, 1);

            //Scenario 1 added 
            promotedCartManager.AddProductToCart(cartC, productA, 3);
            promotedCartManager.AddProductToCart(cartC, productB, 5);
            promotedCartManager.AddProductToCart(cartC, productC, 1);
            promotedCartManager.AddProductToCart(cartC, productD, 1);

            //Displying Product Details
            System.Console.WriteLine("=========================");
            System.Console.WriteLine("Product Details");
            System.Console.WriteLine("=========================");
            System.Console.WriteLine("Id" + "   " + "Name" + "    " + "price");
            foreach (var item in products)
            {
                System.Console.WriteLine(item.Id + "     " + item.Name + "       " + item.Price);
            }
            System.Console.WriteLine("=========================");
            System.Console.WriteLine();

            // Displaying Total with Promotion 
            System.Console.WriteLine("Senario A Promoted Price: " + promotedCartManager.CheckoutCart(cartA));
            System.Console.WriteLine("Senario B Promoted Price: " + promotedCartManager.CheckoutCart(cartB));
            System.Console.WriteLine("Senario C Promoted Price: " + promotedCartManager.CheckoutCart(cartC));
            System.Console.ReadLine();
        }
    }
}
