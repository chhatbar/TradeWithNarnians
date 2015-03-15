using System.Linq;

namespace TradeWithNarnia.Parsers.LineParser
{
  /// <summary>
  /// Helps to process Questions
  /// </summary>
  public class ParsedQuestion : ParsedBase, IParsedLine
  {
    public string Process()
    {
      var result = string.Empty;
      if (IsRegularQuestion)
      {
        result = ProcessRegularQuestion();
      }
      else if (IsCommodityQuestion)
      {
        result = ProcessCommodityQuestion();
      }
      else
      {
        result = new ParsedError().Process();
      }

      return result.Trim();
    }

    private string ProcessCommodityQuestion()
    {
      string result;
      string commodityName = GetCommodityName(ParsedWords.TrimmedRightHalfWords);
      var quantity = GetQuantity(ParsedWords.GetAliases(ParsedWords.TrimmedRightHalfWords));
      var unitPrice = CommodityMgr[commodityName.ToLower()].UnitPrice;

      int totalPrice = (int) (quantity*unitPrice);

      result = ParsedWords.GetAliases(ParsedWords.TrimmedRightHalfWords).Aggregate(string.Empty,
                                                                                   (current, word) => current + (" " + word));

      result += " " + CommodityMgr[commodityName.ToLower()].Name + " is " + totalPrice + " Credits";
      return result;
    }

    private string ProcessRegularQuestion()
    {
      string result;
      var quantity = GetQuantity(ParsedWords.GetAliases(ParsedWords.TrimmedRightHalfWords));
      result = ParsedWords.TrimmedRightHalfWords.Aggregate(string.Empty, (current, word) => current + (" " + word));

      result += " is " + quantity;
      return result;
    }

    private bool IsRegularQuestion
    {
      get
      {
        bool isRegularQuestion = !ParsedWords.GetUnknownWords(ParsedWords.TrimmedRightHalfWords).Any()
          && ParsedWords.HasAliases(ParsedWords.TrimmedRightHalfWords);

        return isRegularQuestion;
      }
    }

    private bool IsCommodityQuestion
    {
      get
      {
        bool isCommodityStatement = ParsedWords.HasSingleUnknownWord(ParsedWords.TrimmedRightHalfWords)
          && ParsedWords.HasAliases(ParsedWords.TrimmedRightHalfWords);

        return isCommodityStatement;
      }
    }
  }
}
