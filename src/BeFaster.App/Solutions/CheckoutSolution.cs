using System;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            var chars = skus.ToCharArray().GroupBy(c => c);

            var priceDictionary = GetPrices();

        }

        private static object GetPrices()
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
