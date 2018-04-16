using BeFaster.App.Solutions;
using System;
using Xunit;

namespace BeFaster.App.Tests.Solutions
{
    public class SumSolutionTest : IDisposable
    {
        public SumSolutionTest()
        {

        }
        public void Dispose()
        {
            
        }

        [Fact]
        public void Sum_TwoPositiveIntegers_Correct()
        {
            var sum = SumSolution.Sum(2, 2);
            Assert.Equal(4, sum);
        }
    }
}
