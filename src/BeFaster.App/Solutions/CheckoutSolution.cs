using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            var chars = skus.ToCharArray().GroupBy(c => c, (key, g) => new { sku = key, count = g.Count() });
            var total = 0;
            foreach(var group in chars)
            {
                total += SumItemPrices(group.sku, group.count);
            }

            return 0;
        }

        private static int SumItemPrices(char sku, int count)
        {
            var priceDictionary = GetPrices();
            return count * priceDictionary[sku] - Discount(sku, count);
        }

        private static int Discount(char sku, int count)
        {
            switch (sku)
            {
                case 'A':
                    return 20 * Math.Floor(count % 3);
                    break;
                case 'B':
                    return 20;
                    break;

            }

            int GetADiscount()
            {
                decimal d = count % 3;
                return (int)Math.Floor(d) * 20;
            }

            int GetBDiscount()
            {
                decimal d = count % 2;
                return (int)Math.Floor(d) * 15;
            }
        }

        private static Dictionary<char, int> GetPrices()
        {
            var prices = new Dictionary<char, int>();

            prices.Add('A', 50);
            prices.Add('B', 30);
            prices.Add('C', 20);
            prices.Add('D', 15);

            return prices;
        }
    }
}
