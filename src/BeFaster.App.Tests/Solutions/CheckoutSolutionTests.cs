using NUnit.Framework;
using BeFaster.App.Solutions;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    public class CheckoutSolutionTests
    {
        [TestCase("John", ExpectedResult = "Hello, John!")]
        [TestCase("Mary", ExpectedResult = "Hello, Mary!")]
        [TestCase(" ", ExpectedResult = "Hello,  !")]
        public int ComputeSum(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
