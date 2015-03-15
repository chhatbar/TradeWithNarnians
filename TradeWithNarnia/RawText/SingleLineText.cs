namespace TradeWithNarnia.RawText
{

  /// <summary>
  /// Represents a Single line text. ie. A statement or a question or an error
  /// </summary>
  public class SingleLineText : TextBase
  {
    private static readonly char[] SEPARATOR = new [] {' '};

    public SingleLineText(string text_):base(text_)
    {
      
    }

    public override char[] GetSeparator()
    {
      return SEPARATOR;
    }
  }
}
