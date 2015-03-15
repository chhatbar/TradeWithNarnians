using System.Collections.Generic;

namespace TradeWithNarnia.Parsers.WordParser
{
  /// <summary>
  /// Defines a library of redundant / marker words as constants. In future this class can be populated from a set of configuration files.
  /// </summary>
  public class WordConstants
  {
    public static readonly IEnumerable<string> REDUNDANT_WORDS = new[] { "credits", "how", "much", "many" };

    public static readonly IEnumerable<string> IN_THE_MIDDLE_WORDS = new[] { "is" };

    public static readonly IEnumerable<string> QUESTION_SUFFIX_WORDS = new[] { "?" };

  }
}
