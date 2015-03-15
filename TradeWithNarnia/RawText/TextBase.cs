using System;

namespace TradeWithNarnia.RawText
{
  public abstract class TextBase
  {
     private string _text = string.Empty;

    public TextBase(string text_)
    {
      _text = text_;
    }

    public string Text
    {
      get
      {
        return _text;
      }
    }

    public string[] SeparatedStrings
    {
      get
      {
        return _text.Split(GetSeparator(), StringSplitOptions.RemoveEmptyEntries);
      }
    }

    public abstract char[] GetSeparator();

    public override string ToString()
    {
      return "Text: " + Text;
    }
  }
}
