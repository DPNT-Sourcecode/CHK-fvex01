using BeFaster.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        
        public static int Checkout(string skus)
        {
            var basket = new ShoppingBasket(skus);

            if(!basket.IsValid)
            {
                return -1;
            }

            return basket.CalculateTotalPrice();

            
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
