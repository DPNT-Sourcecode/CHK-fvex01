using NUnit.Framework;
using BeFaster.App.Solutions;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    public class CheckoutSolutionTests
    {
        [TestCase("A", ExpectedResult = 50)]
        //[TestCase("B", ExpectedResult = "Hello, Mary!")]
        //[TestCase("C", ExpectedResult = "Hello,  !")]
        //[TestCase("D", ExpectedResult = "Hello,  !")]
        public int ComputeSum(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
