using NUnit.Framework;
using BeFaster.App.Solutions;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
        public class HelloSolutionTests
        {
            [TestCase("John", ExpectedResult = "Hello, John!")]
            [TestCase("Mary", ExpectedResult = "Hello, Mary!")]
            [TestCase(" ", ExpectedResult = "Hello,  !")]
        public string ComputeSum(string x)
            {
                return HelloSolution.Hello(x);
            }
        }
}
