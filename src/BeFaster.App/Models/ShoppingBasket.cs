using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Models
{
    public class ShoppingBasket
    {
        private static List<char> _allowedCharacters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F' };

        public ShoppingBasket(string skus)
        {
            Orders = skus
                .ToCharArray()
                .GroupBy(c => c, (key, g) => new ItemOrder() { Sku = key, Count = g.Count() })
                .ToList();
        }

        public int CalculateTotalPrice()
        {
            RemoveFreeItems('E', 2, 'B');
            RemoveFreeItems('N', 3, 'M');
            RemoveFreeItems('R', 3, 'Q');

            var total = 0;

            foreach (var group in Orders)
            {
                total += SumItemPrices(group.Sku, group.Count);
            }

            return total;
        }

        private void RemoveFreeItems(char paidItem, int quantityOfPaidItems, char freeItem)
        {
            var numberOfPaidItems = Orders.FirstOrDefault(g => g.Sku.Equals(paidItem))?.Count ?? 0;
            if (numberOfPaidItems > 0)
            {
                var numberOfFreeItems = numberOfPaidItems / quantityOfPaidItems;
                var currentFreeCount = Orders.FirstOrDefault(g => g.Sku.Equals(freeItem))?.Count ?? 0;
                if (currentFreeCount > 0)
                {
                    var discountedFreeItems = currentFreeCount - numberOfFreeItems;
                    Orders.FirstOrDefault(g => g.Sku.Equals(freeItem)).Count = Math.Max(0, discountedFreeItems);
                }
            }
        }

        public List<ItemOrder> Orders { get; set; }

        public bool IsValid => Orders.All(c => c.Sku > 64 && c.Sku < 91);

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
                    return Get2Discounts(5, 50, 3, 20);
                case 'B':
                    return GetDiscount(2, 15);
                case 'F':
                    return GetDiscount(3, 10);
                case 'H':
                    return Get2Discounts(3, 10);
                default:
                    return 0;
            }

            int GetDiscount(int toQualify, int discount)
            {
                double divided = countDouble / toQualify;
                return (int)Math.Floor(divided) * discount;
            }

            int Get2Discounts(int toQualify, int discount1, int toQualify2, int discount2)
            {
                var dividedFirst = countDouble / toQualify;
                var discount = (int)Math.Floor(dividedFirst) * discount1;
                var remaining = countDouble - (int)Math.Floor(dividedFirst) * toQualify;

                var dividedSecond = remaining / toQualify2;
                discount += (int)Math.Floor(dividedSecond) * discount2;

                return discount;
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
            prices.Add('G', 20);
            prices.Add('H', 10);
            prices.Add('I', 35);
            prices.Add('J', 60);
            prices.Add('K', 80);
            prices.Add('L', 90);
            prices.Add('M', 15);
            prices.Add('N', 40);
            prices.Add('O', 10);
            prices.Add('P', 50);
            prices.Add('Q', 30);
            prices.Add('R', 50);
            prices.Add('S', 30);
            prices.Add('T', 20);
            prices.Add('U', 40);
            prices.Add('V', 50);
            prices.Add('W', 20);
            prices.Add('X', 90);
            prices.Add('Y', 10);
            prices.Add('Z', 50);

            return prices;
        }
    }
}
