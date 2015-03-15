Problem. Trade With Narnia

Solution

General
- The solution to address the above problem is implemented in C# Dot Net
- The solution is built with Visual Studio 2012, Dot Net Framework 3.5. Solution file: .\TradeWithNarnia\TradeWithNarnia.sln
- The solution contains two projects
	- TradeWithNarnia
		- This project implements core logic
	- TradeWithNarniaTest
		- This project implements NUnit Tests on TradeWithNarnia
		
External Dependencies
- Prism 4.1
	- The project leverages Prism 4.1 framework as it uses the UnityContainer for Dependency Injection.
	- These dependencies can be downloaded from: http://www.microsoft.com/en-in/download/details.aspx?id=28950

- NUnit
	- The test project has a dependency on NUnit framework 2.6.2.12296
	- NUnit dependency can be downloaded from: http://launchpad.net/nunitv2/2.6.2/2.6.2/+download/NUnit-2.6.2.zip
	
Unit Tests
- TestGivenInput
	- Use NUnit to run TestGivenInput Test cases. These test cases assert the given sample output with the problem statement against the actual output of the program.
- TestRomanNumberValidator
	- Tests the given constains for a Roman number
		- Number of repetitions
		- Marginally Smaller number to precede bigger number for subtraction
- TestPriceConverter
	- Tests Price conversion from Roman Number to Arabic Number for various inputs
	
	
