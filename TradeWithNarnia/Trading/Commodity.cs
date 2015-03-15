namespace TradeWithNarnia.Trading
{
  /// <summary>
  /// Commodity class to encapsulate the names and other attributes of the commodities that can be potentially traded in the galaxy
  /// </summary>
  public class Commodity
  {
    private readonly string _name;
    private readonly decimal _unitPrice;

    public Commodity(string name_, decimal unitPrice_)
    {
      _name = name_;
      _unitPrice = unitPrice_;
    }

    public string Name
    {
      get { return _name; }
    }

    public decimal UnitPrice
    {
      get { return _unitPrice; }
    }
  }
}
