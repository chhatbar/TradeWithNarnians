using System.Collections.Generic;
using TradeWithNarnia.Symbol;
using NUnit.Framework;

namespace TradeWithNarniaTest
{
  [TestFixture]
  public class TestRomanNumberValidator
  {
    /// <summary>
    /// Asserts the constraints attributed to the RomanSymbols 
    /// </summary>
    [Test]
    public void TestRomanNumbers()
    {
      // Test for Roman Symbol constraint for Number of Repetitions
      // Roman number: XXX, perfectly valid
      IEnumerable<RomanSymbol> _3ConsecutiveXs = new List<RomanSymbol>() { RomanSymbol.X, RomanSymbol.X, RomanSymbol.X};
      Assert.True(RomanNumberValidator.IsRomanNumberValid(_3ConsecutiveXs));

      /// Roman number: XXXX, invalid
      IEnumerable<RomanSymbol> _4ConsecutiveXs = new List<RomanSymbol>(){RomanSymbol.X, RomanSymbol.X, RomanSymbol.X, RomanSymbol.X};
      Assert.False(RomanNumberValidator.IsRomanNumberValid(_4ConsecutiveXs));

      // Test for Roman Symbol constraint for Subtraction
      // Roman number: XL, valid
      IEnumerable<RomanSymbol> subtractXFromL = new List<RomanSymbol>() { RomanSymbol.X, RomanSymbol.L};
      Assert.True(RomanNumberValidator.IsRomanNumberValid(subtractXFromL));

      // Roman number: ID, invalid
      IEnumerable<RomanSymbol> subtractIFromD = new List<RomanSymbol>() { RomanSymbol.I, RomanSymbol.D };
      Assert.False(RomanNumberValidator.IsRomanNumberValid(subtractIFromD));
    }
  }
}
