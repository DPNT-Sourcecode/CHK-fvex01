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
        [TestCase("K", ExpectedResult = 70)]
        [TestCase("KK", ExpectedResult = 120)]
        [TestCase("NNN", ExpectedResult = 120)]
        [TestCase("NNMN", ExpectedResult = 120)]
        [TestCase("PPPP", ExpectedResult = 200)]
        [TestCase("PPPPP", ExpectedResult = 200)]
        [TestCase("QQ", ExpectedResult = 60)]
        [TestCase("QQQ", ExpectedResult = 80)]
        [TestCase("RRR", ExpectedResult = 150)]
        [TestCase("RRRQ", ExpectedResult = 150)]
        [TestCase("RRRQRRQQ", ExpectedResult = 310)]
        [TestCase("UUU", ExpectedResult = 120)]
        [TestCase("UUUU", ExpectedResult = 120)]
        [TestCase("V", ExpectedResult = 50)]
        [TestCase("VV", ExpectedResult = 90)]
        [TestCase("VVV", ExpectedResult = 130)]
        [TestCase("G", ExpectedResult = 20)]
        [TestCase("g", ExpectedResult = -1)]
        [TestCase("I", ExpectedResult = 35)]
        [TestCase("J", ExpectedResult = 60)]
        [TestCase("L", ExpectedResult = 90)]
        [TestCase("M", ExpectedResult = 15)]
        [TestCase("O", ExpectedResult = 10)]
        [TestCase("S", ExpectedResult = 20)]
        [TestCase("T", ExpectedResult = 20)]
        [TestCase("W", ExpectedResult = 20)]
        [TestCase("X", ExpectedResult = 17)]
        [TestCase("Y", ExpectedResult = 20)]
        [TestCase("Z", ExpectedResult = 21)]
        [TestCase("ZZZ", ExpectedResult = 45)]
        public int ComputeCheckoutTotal(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}
