using TradeWithNarnia.Manager;
using TradeWithNarnia.Parsers.WordParser;
using Microsoft.Practices.Unity;

namespace TradeWithNarnia.Helper
{
  public class UnityContainerHelper
  {
    public static IUnityContainer _unityContainer;

    public static IUnityContainer UnityContainer
    {
      get { return _unityContainer; }
    }

    static UnityContainerHelper()
    {
      _unityContainer = new UnityContainer();
    }

    public static void Initialize()
    {
      _unityContainer.RegisterType<CommodityManager>(new ContainerControlledLifetimeManager());
      _unityContainer.RegisterType<AliasManager>(new ContainerControlledLifetimeManager());
      _unityContainer.RegisterType<IParsedWords, ParsedWordsImpl>(new ContainerControlledLifetimeManager());
    }
  }
}
