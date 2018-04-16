using BeFaster.App.Solutions;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
    public class SumSolutionTest
    {
        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(1, -1, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 1)]
        public int ComputeSum(int x, int y)
        {
            return SumSolution.Sum(x, y);
        }
    }
}
