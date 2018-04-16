using BeFaster.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        private static List<char> _allowedCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F' };
        
        public static int Checkout(string skus)
        {
            var chars = skus
                .ToCharArray()
                .GroupBy(c => c, (key, g) => new ItemOrder() { Sku = key, Count = g.Count() })
                .ToList();

            if(chars.Any(c => !_allowedCharacters.Contains(c.Sku)))
            {
                return -1;
            }

            var numberOfEItems = chars.FirstOrDefault(g => g.Sku.Equals('E'))?.Count ?? 0;
            if(numberOfEItems > 0)
            {
                var numberOfFreeBItems = numberOfEItems / 2;
                var currentBCount = chars.FirstOrDefault(g => g.Sku.Equals('B'))?.Count ?? 0;
                if(currentBCount > 0)
                {
                    var DiscountedBItems = currentBCount - numberOfFreeBItems;
                    chars.FirstOrDefault(g => g.Sku.Equals('B')).Count = Math.Max(0, DiscountedBItems);
                }
            }

            var total = 0;
            foreach (var group in chars)
            {
                total += SumItemPrices(group.Sku, group.Count);
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
                case 'F':
                    return GetFDiscount();
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
                double dividedBy2 = countDouble / 2;
                return (int)Math.Floor(dividedBy2) * 15;
            }

            int GetFDiscount()
            {
                double dividedBy3 = countDouble / 3;
                return (int)Math.Floor(dividedBy3) * 10;
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
            prices.Add('F', 10);

            return prices;
        }
    }
}
