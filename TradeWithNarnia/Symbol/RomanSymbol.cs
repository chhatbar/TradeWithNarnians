namespace TradeWithNarnia.Symbol
{

  /// <summary>
  /// Enum that represents each RomanNumber with their Constraints specified as attributes
  /// </summary>
  public enum RomanSymbol
  {
    [RomanSymbolConstraint(CanBeSubtractedFrom = new[] { V, X }, MaxRepetition = 3)]
    I = 1,

    V = 5,

    [RomanSymbolConstraint(CanBeSubtractedFrom = new [] { L, C }, MaxRepetition = 3)]
    X = 10,

    L = 50,

    [RomanSymbolConstraint(CanBeSubtractedFrom = new [] { D, M }, MaxRepetition = 3)]
    C = 100,

    D = 500,

    [RomanSymbolConstraint(MaxRepetition = 3)]
    M = 1000,
  }
}
