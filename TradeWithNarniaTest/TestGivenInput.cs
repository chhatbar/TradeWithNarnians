using System.Collections.Generic;
using TradeWithNarnia.Parsers.WordParser;
using TradeWithNarnia.RawText;
using NUnit.Framework;

namespace TradeWithNarniaTest
{
  /// <summary>
  /// Test Fixture to get the given input in the problem statement tested
  /// </summary>
  [TestFixture]
  public class TestGivenInput
  {
    private KeyValuePair<string, string>[] inputOutputPairs = new []
      {
        new KeyValuePair<string, string>("cat is I", string.Empty), 
        new KeyValuePair<string, string>("fish is V", string.Empty),
        new KeyValuePair<string, string>("pig is X", string.Empty),
        new KeyValuePair<string, string>("ant is L", string.Empty),
        new KeyValuePair<string, string>("cat cat Brass is 10 Credits", string.Empty),
        new KeyValuePair<string, string>("cat fish Copper is 4000 Credits", string.Empty),
        new KeyValuePair<string, string>("pig pig Aluminium is 2000 Credits", string.Empty),
        new KeyValuePair<string, string>("how much is pig ant cat ?", "pig ant cat is 41"),
        new KeyValuePair<string, string>("how many Credits is cat fish Brass ?", "cat fish Brass is 20 Credits"),
        new KeyValuePair<string, string>("how many Credits is cat fish Copper ?", "cat fish Copper is 4000 Credits"),
        new KeyValuePair<string, string>("how many Credits is cat fish Aluminium ?", "cat fish Aluminium is 400 Credits"),
        new KeyValuePair<string, string>("how much would be the cost to get Aslan on to the earth ?", "Exception - unable to parse"),
      };


    [Test]
    public void ExecuteTest1()
    {
      TradeWithNarnia.Helper.UnityContainerHelper.Initialize();

      var singleLineProcessor = new SingleLineProcessor();
      foreach (var inputOutpuPair in inputOutputPairs)
      {
        string output = singleLineProcessor.Process(new SingleLineText(inputOutpuPair.Key));
        Assert.True(inputOutpuPair.Value.Equals(output), "Expected output: " + inputOutpuPair.Value + " Actual output: " + output);
      }
    }

  }
}
