using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeWithNarnia.Helper;
using TradeWithNarnia.Symbol;
using NUnit.Framework;

namespace TradeWithNarniaTest
{
  /// <summary>
  /// Checks the expected working of the Price Converter with varous inputs
  /// </summary>
  [TestFixture]
  public class TestPriceConverter
  {
    [Test]
    public void TestPriceConversion()
    {
      // Test for Roman Symbol constraint for Number of Repetitions
      IEnumerable<RomanSymbol> sixtyFour = new List<RomanSymbol>() { RomanSymbol.L, RomanSymbol.X, RomanSymbol.V};
      Assert.True((new PriceConverter().GetArabicNumber(sixtyFour)) == 65);

      // Test for Roman Symbol constraint for Number of Repetitions
      IEnumerable<RomanSymbol> invalidRomanNumber = new List<RomanSymbol>() { RomanSymbol.C, RomanSymbol.C, RomanSymbol.C, RomanSymbol.C };
      var priceConverter = new PriceConverter();
      var ex = Assert.Throws<Exception>(() => priceConverter.GetArabicNumber(invalidRomanNumber));
      Assert.That(ex.Message, Is.EqualTo("Invalid Roman Number"));
    }
  }
}
