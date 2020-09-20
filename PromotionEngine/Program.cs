using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        IProductService productService;

        Program(IProductService obj)
        {
            productService = obj;
        }

        static void Main(string[] args)
        {

            Program objProgram = new Program(new ProductService());
            objProgram.Start();
        }

        public void Start()
        {
            List<Product> products = new List<Product>();
            Console.WriteLine("Kindly enter total number of order");
            var numb = Console.ReadLine();
            bool isNumeric = int.TryParse(numb, out int n);
            if (isNumeric == true)
            {
                for (int i = 0; i < Convert.ToInt32(numb); i++)
                {
                    Product p = GetValidProduct();
                    if (p != null)
                    {
                        products.Add(p);
                    }
                }
                int totalPrice = productService.GetTotalPrice(products);
                Console.WriteLine("Total Price is " + totalPrice);
                Console.Read();
            }
            else
            {
                Start();
            }
        }

        public Product GetValidProduct()
        {
            Product p = null;
            for (int i = 0; i < 2; i++)
            {
                i = 0;
                Console.WriteLine("Kindly enter the type of product:A,B,C or D");
                string type = Console.ReadLine();
                p = productService.GetPriceByProductType(new Product() { Id = type });
                if (p.Price != null)
                {
                    return p;
                }
                else
                {
                    Console.WriteLine("Entered product is not availbale");
                }

            }
            return p;
        }
    }
}
