namespace TradeWithNarnia.Parsers.LineParser
{
  /// <summary>
  /// Interface for processing various type of parsed lines viz. Question, Statement, Error
  /// </summary>
  public interface IParsedLine
  {
    string Process();
  }
}
