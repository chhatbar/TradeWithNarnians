using System;
using System.Collections.Generic;
using System.Linq;
using TradeWithNarnia.Helper;

namespace TradeWithNarnia.Symbol
{
  /// <summary>
  /// Checks the validity of a given roman number
  /// </summary>
  public class RomanNumberValidator
  {
    public static bool IsRomanNumberValid(IEnumerable<RomanSymbol> romanSymbols_)
    {
      bool isRomanNumberValid = true;
      RomanSymbol[] symbols = romanSymbols_.ToArray();

      for (int i = 0; i < symbols.Length; i++)
      {
        var attribute = symbols[i].GetAttributeOfType<RomanSymbolConstraintAttribute>();
        if (attribute != null)
        {
          // Check if the roman number can be subtracted from the next number
          if (attribute.CanBeSubtracted)
          {
            if (i < (symbols.Length - 1) && ((int)symbols[i] < (int)symbols[i + 1]))
            {
              if (attribute.CanBeSubtractedFrom.Contains(symbols[i + 1]) == false)
              {
                isRomanNumberValid = false;
              }
            }
          }

          // check if the roman number has the right number of repetitions
          if (attribute.CanRepeat)
          {
            string symbolName = Enum.GetName(symbols[i].GetType(), symbols[i]);
            string potentiallyInvalidSubstring = GetSubstring(symbolName, attribute.MaxRepetition + 1);
            if (GetRomanNumberAsString(romanSymbols_).Contains(potentiallyInvalidSubstring))
            {
              isRomanNumberValid = false;
            }
          }

        }
      }
      return isRomanNumberValid;
    }

    private static string GetSubstring(string symbol_, int maxRepeats_)
    {
      string result = string.Empty;
      for (int i = 0; i < maxRepeats_; i++)
      {
        result += symbol_;
      }
      return result;
    }

    private static string GetRomanNumberAsString(IEnumerable<RomanSymbol> romanSymbols_)
    {
      return romanSymbols_.Aggregate(string.Empty, (current, romanSymbol) => current + Enum.GetName(romanSymbol.GetType(), romanSymbol));
    }
  }


}
