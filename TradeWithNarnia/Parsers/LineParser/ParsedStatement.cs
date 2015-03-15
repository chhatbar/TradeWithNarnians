using TradeWithNarnia.Trading;

namespace TradeWithNarnia.Parsers.LineParser
{
  /// <summary>
  /// Processes statements, populates Alias cache, Commodity cache
  /// </summary>
  public class ParsedStatement : ParsedBase, IParsedLine
  {
    public string Process()
    {
      var result = string.Empty;
      if(IsAliasStatement)
      {
        ProcessAliasStatement();
      }
      else if(IsCommodityStatement)
      {
        ProcessCommodityStatement();
      }
      else
      {
        // Unable to process as a statement, Redirect to Error highlighting
        result = new ParsedError().Process();
      }

      return result.Trim();
    }

    private void ProcessCommodityStatement()
    {
      string commodityName = GetCommodityName(ParsedWords.TrimmedLeftHalfWords);
      var lhsQuantity = GetQuantity(ParsedWords.GetAliases(ParsedWords.TrimmedLeftHalfWords));
      var totalCost = GetTotalCost(ParsedWords.TrimmedRightHalfWords);

      // Populate commodity cache
      CommodityMgr[commodityName] = new Commodity(commodityName, (decimal) totalCost/(decimal) lhsQuantity);
    }

    private void ProcessAliasStatement()
    {
      var alias = ParsedWords.GetSingleUnknownWord(ParsedWords.TrimmedLeftHalfWords);
      var romanSymbol = ParsedWords.GetSingleUnknownWord(ParsedWords.TrimmedRightHalfWords);

      // Populate Alias Cache
      AliasMgr.Add(alias.ToLower(), romanSymbol);
    }

    private bool IsAliasStatement
    {
      get
      {
        bool isAliasStatement = ParsedWords.HasSingleUnknownWord(ParsedWords.TrimmedLeftHalfWords) 
          && !ParsedWords.HasAliases(ParsedWords.TrimmedLeftHalfWords);

        return isAliasStatement;
      }
    }

    private bool IsCommodityStatement
    {
      get
      {
        bool isCommodityStatement = ParsedWords.HasSingleUnknownWord(ParsedWords.TrimmedLeftHalfWords)
          && ParsedWords.HasAliases(ParsedWords.TrimmedLeftHalfWords);

        return isCommodityStatement;
      }
    }
  }
}
