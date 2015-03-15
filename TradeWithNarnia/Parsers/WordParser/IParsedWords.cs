using System.Collections.Generic;
using TradeWithNarnia.RawText;

namespace TradeWithNarnia.Parsers.WordParser
{
  /// <summary>
  /// Generic interface to process a SingleLineText
  /// </summary>
  public interface IParsedWords
  {
    bool IsQuestion { get; }
    bool IsStatement { get; }    
    IEnumerable<string> TrimmedLeftHalfWords { get; }
    IEnumerable<string> TrimmedRightHalfWords { get; }

    bool HasAliases(IEnumerable<string> words_);
    bool HasSingleUnknownWord(IEnumerable<string> words_);
    void SetSingleLineText(SingleLineText singleLineText_);
    string GetSingleUnknownWord(IEnumerable<string> words_);
    IEnumerable<string> GetUnknownWords(IEnumerable<string> words_);
    IEnumerable<string> GetAliases(IEnumerable<string> words_);
  }
}
