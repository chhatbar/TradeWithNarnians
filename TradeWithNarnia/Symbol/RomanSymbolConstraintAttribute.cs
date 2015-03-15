using System;

namespace TradeWithNarnia.Symbol
{
  /// <summary>
  /// Represents a RomanNumber Constraints. Can be attached as an attribute to individual roman symbols
  /// </summary>
  public class RomanSymbolConstraintAttribute : Attribute
  {
    private int _maxRepetition = 0;
    private RomanSymbol[] _canBeSubtractedFrom = null;
    
    public int MaxRepetition
    {
      get { return _maxRepetition; }
      set { _maxRepetition = value; }
    }

    public RomanSymbol[] CanBeSubtractedFrom
    {
      get { return _canBeSubtractedFrom; }
      set { _canBeSubtractedFrom = value; }
    }

    public bool CanRepeat
    {
      get { return _maxRepetition > 0; }
    }

    public bool CanBeSubtracted
    {
      get { return _canBeSubtractedFrom != null; }
    }
  }
}
