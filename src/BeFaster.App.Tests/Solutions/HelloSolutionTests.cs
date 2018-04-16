using NUnit.Framework;
using BeFaster.App.Solutions;

namespace BeFaster.App.Tests.Solutions
{
    [TestFixture]
        public class HelloSolutionTests
        {
            [TestCase("hey", ExpectedResult = "Hello World!")]
            public string ComputeSum(string x)
            {
                return HelloSolution.Hello(x);
            }
        }
}
