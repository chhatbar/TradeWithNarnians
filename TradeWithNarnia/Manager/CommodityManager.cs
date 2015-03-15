using System.Collections.Generic;
using TradeWithNarnia.Trading;

namespace TradeWithNarnia.Manager
{
  /// <summary>
  /// Maintains a cache of commodities
  /// </summary>
  public class CommodityManager
  {
    /// <summary>
    /// key : value => "iron" : Commodity("Iron", 105)
    /// </summary>
    private Dictionary<string, Commodity> _commodityCache = new Dictionary<string, Commodity>();

    public Commodity this[string commodityName_]
    {
      get
      {
        return _commodityCache.ContainsKey(commodityName_.ToLower()) ? _commodityCache[commodityName_.ToLower()] : null;
      }
      set
      {
        _commodityCache.Add(value.Name.ToLower(), value);
      }
    }
  }
}
