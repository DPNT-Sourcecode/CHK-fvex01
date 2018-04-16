using BeFaster.App.Models;

namespace BeFaster.App.Solutions
{
    public static class CheckoutSolution
    {
        
        public static int Checkout(string skus)
        {
            var basket = new ShoppingBasket(skus);

            return basket.IsValid ? basket.CalculateTotalPrice() : -1;
        }
    }
}
