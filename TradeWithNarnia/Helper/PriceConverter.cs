using System;
using System.Collections.Generic;
using TradeWithNarnia.Symbol;
using System.Linq;

namespace TradeWithNarnia.Helper
{
  /// <summary>
  /// RomanSymbols to Arabic Numbers Converter 
  /// </summary>
  public class PriceConverter
  {
    public int GetArabicNumber(IEnumerable<RomanSymbol> romanSymbols)
    {
      if(RomanNumberValidator.IsRomanNumberValid(romanSymbols) == false)
      {
        throw new Exception("Invalid Roman Number");
      }

      int total = 0;
      if (romanSymbols.Any())
      {
        RomanSymbol[] romanSymbolArray = romanSymbols.ToArray();
        for (var i = 0; i < romanSymbolArray.Length; i++)
        {
          // last number just add the value and exit
          if (i + 1 == romanSymbolArray.Length)
          {
            total += (int) romanSymbolArray[i];
            break;
          }

          // exception found
          if (romanSymbolArray[i] < romanSymbolArray[i+1])
          {
            total += ((int) romanSymbolArray[i +1] - (int) romanSymbolArray[i]);
            i++;
          }
          else
          {
            total += (int) romanSymbolArray[i];
          }
        }
      }
      return total;
    }
  }
}
