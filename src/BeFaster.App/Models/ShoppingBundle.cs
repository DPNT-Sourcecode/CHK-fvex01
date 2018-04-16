using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Models
{
    public class ShoppingBundle
    {
        ShoppingBundle(string skus, int toQualify, int price)
        {
            Items = skus
                .ToCharArray()
                .ToList();
        }

        public List<char> Items { get; }


    }
}
