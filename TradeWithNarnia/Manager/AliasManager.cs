using System;
using System.Collections.Generic;
using TradeWithNarnia.Symbol;

namespace TradeWithNarnia.Manager
{
  /// <summary>
  /// Maintains a cache of Aliases corresponding to various Roman Symbols
  /// </summary>
  public class AliasManager
  {
    /// <summary>
    /// key : value => "glob" : I 
    /// </summary>
    private Dictionary<string, RomanSymbol> _romanSymbolAliasCache = new Dictionary<string, RomanSymbol>();

    private void Add(string alias_, RomanSymbol romanSymbol_)
    {
      _romanSymbolAliasCache.Add(alias_, romanSymbol_);
    }

    public RomanSymbol? this[string alias]
    {
      get
      {
        if (_romanSymbolAliasCache.ContainsKey(alias))
        {
          return _romanSymbolAliasCache[alias];
        }
        return null;
      }
    }

    public void Add(string alias_, string romanSymbol_)
    {
      Add(alias_, (RomanSymbol) Enum.Parse(typeof (RomanSymbol), romanSymbol_));
    }

    public IEnumerable<string> AllAliases()
    {
      return _romanSymbolAliasCache.Keys;
    }

  }
}
