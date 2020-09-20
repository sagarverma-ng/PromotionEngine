using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public interface IProductService
    {
        Product GetPriceByProductType(Product product);
        int GetTotalPrice(List<Product> products);
    }
}
