using System.Collections.Generic;
using System.Linq;
using TradeWithNarnia.Helper;
using TradeWithNarnia.Manager;
using TradeWithNarnia.Parsers.WordParser;
using TradeWithNarnia.Symbol;
using Microsoft.Practices.Unity;

namespace TradeWithNarnia.Parsers.LineParser
{
  /// <summary>
  /// Base class for processing various types of parsed lines viz. Question, Statement, Error
  /// Contains dependency injected properties and utility methods
  /// </summary>
  public class ParsedBase
  {
    [Dependency]
    public IParsedWords ParsedWords { get; set; }

    [Dependency]
    public AliasManager AliasMgr { get; set; }

    [Dependency]
    public CommodityManager CommodityMgr { get; set; }

    [Dependency]
    public PriceConverter PriceCnvtr { get; set; }

    protected string GetCommodityName(IEnumerable<string> words_)
    {
      return ParsedWords.GetSingleUnknownWord(words_);
    }

    protected int GetQuantity(IEnumerable<string> aliases)
    {
      IList<RomanSymbol> romanSymbols =
        (from alias in aliases select AliasMgr[alias] into romanSymbol where romanSymbol != null select romanSymbol.Value).
          ToList();
      int lhsQuantity = PriceCnvtr.GetArabicNumber(romanSymbols);
      return lhsQuantity;
    }

    protected int GetTotalCost(IEnumerable<string> words_)
    {
      string rhstotalCost = ParsedWords.GetSingleUnknownWord(words_);
      int totalCost = 0;
      int temp;
      if (int.TryParse(rhstotalCost, out temp))
      {
        totalCost = temp;
      }
      return totalCost;
    }
  }
}
