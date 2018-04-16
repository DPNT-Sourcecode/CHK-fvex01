using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        private static List<char> _allowedCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E' };
        
        public static int Checkout(string skus)
        {
            var chars = skus
                .ToCharArray()
                .GroupBy(c => c, (key, g) => new { sku = key, count = g.Count() });

            if(chars.Any(c => !_allowedCharacters.Contains(c.sku)))
            {
                return -1;
            }

            var EItems = chars.FirstOrDefault(g => g.sku.Equals('E'));

            var total = EItems != null ? SumItemPrices(EItems.sku, EItems.count) : 0;
            foreach (var group in chars.Where(g => !g.sku.Equals('E')))
            {
                total += SumItemPrices(group.sku, group.count);
            }

            return total;
        }

        private static int SumItemPrices(char sku, int count)
        {
            var priceDictionary = GetPrices();
            var discount = CalculateDiscount(sku, count);
            return count * priceDictionary[sku] - discount;
        }

        private static int CalculateDiscount(char sku, int count)
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
                var dividedBy5 = countDouble / 5.0;
                var discount = (int)Math.Floor(dividedBy5) * 50;
                var remaining = countDouble - (int)Math.Floor(dividedBy5) * 5;

                var dividedBy3 = remaining / 3.0;
                discount += (int)Math.Floor(dividedBy3) * 20;

                return discount;
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
            prices.Add('E', 40);

            return prices;
        }
    }
}
