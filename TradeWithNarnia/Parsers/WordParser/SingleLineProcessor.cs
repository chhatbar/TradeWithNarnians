using TradeWithNarnia.Helper;
using TradeWithNarnia.Parsers.LineParser;
using TradeWithNarnia.RawText;
using Microsoft.Practices.Unity;

namespace TradeWithNarnia.Parsers.WordParser
{
  /// <summary>
  /// SingleLineProcessor is the entry point to process the individual lines of text. Singleline processor knows to process a SingleLineText instance
  /// regardless of the line being a Statement, a question or an error
  /// </summary>
  public class SingleLineProcessor
  {
    public string Process(SingleLineText singleLineText_)
    {
      var parsedWords = UnityContainerHelper.UnityContainer.Resolve<IParsedWords>();
      parsedWords.SetSingleLineText(singleLineText_);

      IParsedLine parsedLine = UnityContainerHelper.UnityContainer.Resolve<ParsedError>();

      if(parsedWords.IsQuestion)
      {
        parsedLine = UnityContainerHelper.UnityContainer.Resolve<ParsedQuestion>();
      }
      else if(parsedWords.IsStatement)
      {
        parsedLine = UnityContainerHelper.UnityContainer.Resolve<ParsedStatement>();
      }

      return parsedLine.Process();
    }
  }
}
