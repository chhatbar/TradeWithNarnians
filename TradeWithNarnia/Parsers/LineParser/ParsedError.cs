namespace TradeWithNarnia.Parsers.LineParser
{
  /// <summary>
  /// Helps to process Error Inputs
  /// </summary>
  public class ParsedError : ParsedBase, IParsedLine
  {
    public string Process()
    {
      return "Exception - unable to parse";
    }
  }
}
