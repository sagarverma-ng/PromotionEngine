using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
   public class ProductService: IProductService
    {
        public Product GetPriceByProductType(Product product)
        {
            product.Price = product.Id.ToUpper() switch
            {
                "A" => 50m,
                "B" => 30m,
                "C" => 20m,
                "D" => 2015m,
                _ => product.Price
            };
            return product;
        }

        public int GetTotalPrice(List<Product> products)
        {
            int priceA = 50;
            int priceB = 30;
            int priceC = 20;
            int priceD = 15;
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;

            foreach (Product pr in products)
            {
                switch (pr.Id.ToUpper())
                {
                    case "A":
                        countA += 1;
                        break;
                    case "B":
                        countB += 1;
                        break;
                    case "C":
                        countC += 1;
                        break;
                    case "D":
                        countD += 1;
                        break;
                }
            }
            int totalPriceA = (countA / 3) * 130 + (countA % 3 * priceA);
            int totalPriceB = (countB / 2) * 45 + (countB % 2 * priceB);
            int totalPriceC = (countC * priceC);
            int totalPriceD = (countD * priceD);
            return totalPriceA + totalPriceB + totalPriceC + totalPriceD;
        }
    }
}
