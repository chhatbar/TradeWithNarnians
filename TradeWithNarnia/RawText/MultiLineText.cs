using System.Collections.Generic;
using System.Linq;

namespace TradeWithNarnia.RawText
{
  /// <summary>
  /// Processes a multiline text to emit a list of SingleLineTexts
  /// </summary>
  public class MultiLineText : TextBase
  {
    private static readonly char[] SEPARATOR = new []{'\r','\n'};

    public MultiLineText(string text_):base(text_)
    {
      
    }

    public override char[] GetSeparator()
    {
      return SEPARATOR;
    }

    public IEnumerable<SingleLineText> SingleLineTexts
    {
      get
      {
        return SeparatedStrings.Select(text => new SingleLineText(text)).ToList();
      }
    }
  }
}
