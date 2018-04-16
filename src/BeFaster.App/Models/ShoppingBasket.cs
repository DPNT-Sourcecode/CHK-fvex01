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
            var numberOfEItems = basket.FirstOrDefault(g => g.Sku.Equals('E'))?.Count ?? 0;
            if (numberOfEItems > 0)
            {
                var numberOfFreeBItems = numberOfEItems / 2;
                var currentBCount = basket.FirstOrDefault(g => g.Sku.Equals('B'))?.Count ?? 0;
                if (currentBCount > 0)
                {
                    var DiscountedBItems = currentBCount - numberOfFreeBItems;
                    basket.FirstOrDefault(g => g.Sku.Equals('B')).Count = Math.Max(0, DiscountedBItems);
                }
            }

            var total = 0;
            foreach (var group in basket)
            {
                total += SumItemPrices(group.Sku, group.Count);
            }

            return total;
        }

        public List<ItemOrder> Orders { get; set; }

        public bool IsValid => Orders.All(c => _allowedCharacters.Contains(c.Sku))
    }
}
