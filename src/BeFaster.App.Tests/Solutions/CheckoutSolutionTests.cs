using NUnit.Framework;
using BeFaster.App.Solutions;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    public class CheckoutSolutionTests
    {
        [TestCase("A", ExpectedResult = 50)]
        [TestCase("B", ExpectedResult = 30)]
        [TestCase("C", ExpectedResult = 20)]
        [TestCase("D", ExpectedResult = 15)]
        [TestCase("AAABB", ExpectedResult = 175)]
        [TestCase(" ", ExpectedResult = -1)]
        [TestCase("a", ExpectedResult = -1)]
        public int ComputeCheckoutTotal(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
