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
        [TestCase("AAAAA", ExpectedResult = 200)]
        [TestCase("AAAAAAAA", ExpectedResult = 330)]
        [TestCase("EEEEBB", ExpectedResult = 160)]
        [TestCase("EEEE", ExpectedResult = 160)]
        [TestCase("F", ExpectedResult = 10)]
        [TestCase("FF", ExpectedResult = 20)]
        [TestCase("FFF", ExpectedResult = 20)]
        [TestCase("HHHHH", ExpectedResult = 45)]
        [TestCase("HHHHHHHHHH", ExpectedResult = 80)]
        [TestCase("HHHHHHHHHHHHHHH", ExpectedResult = 125)]
        [TestCase("HHHHHHHHHHHHHHHH", ExpectedResult = 135)]
        public int ComputeCheckoutTotal(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
