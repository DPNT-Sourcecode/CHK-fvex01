using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        private static char[] _allowedCharacters = new char[] { 'A', 'B', 'C', 'D' };
        
        public static int Checkout(string skus)
        {
            var chars = skus.ToCharArray().GroupBy(c => c, (key, g) => new { sku = key, count = g.Count() });
            var total = 0;
            foreach(var group in chars)
            {
                total += SumItemPrices(group.sku, group.count);
            }

            return total;
        }

        private static int SumItemPrices(char sku, int count)
        {
            var priceDictionary = GetPrices();
            var discount = Discount(sku, count);
            return count * priceDictionary[sku] - discount;
        }

        private static int Discount(char sku, int count)
        {
            var countDouble = (double)count;
            switch (sku)
            {
                case 'A':
                    return GetADiscount();
                case 'B':
                    return GetBDiscount();
                default:
                    return 0;
            }

            int GetADiscount()
            {
                var d = countDouble / 3.0;
                return (int)Math.Floor(d) * 20;
            }

            int GetBDiscount()
            {
                double d = countDouble / 2;
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
