Problem. Trade With Narnia

	Peter, Susan, Edmund and Lucy go to Narnia and stayed there for a while during their interaction with The Lion, the Witch and the Wardrobe. Their stay in Narnia made them realize some trade opportunities with the Narnians. Trading with the Narnians required them to convert numbers and units. They decided to outsouce a program that could help themselves to trade with the Narnians. The numbers used for Narnian transactions follows similar convention to the Roman Numerals. Roman numerals are based on seven symbols:

	Source: http://en.wikipedia.org/wiki/Roman_numerals

	Symbol	Value
	I	1
	V	5
	X	10
	L	50
	C	100
	D	500
	M	1,000

	Numbers are formed by combining symbols together and adding the values. So II is two ones, i.e. 2, and XIII is a ten and three ones, i.e. 13. There is no zero in this system, so 207, for example, is CCVII, using the symbols for two hundreds, a five and two ones. 1066 is MLXVI, one thousand, fifty and ten, a five and a one.

	Symbols are placed from left to right in order of value, starting with the largest. However, in a few specific cases, to avoid four characters being repeated in succession (such as IIII or XXXX) these can be reduced using subtractive notation as follows:

	the numeral I can be placed before V and X to make 4 units (IV) and 9 units (IX) respectively
	X can be placed before L and C to make 40 (XL) and 90 (XC) respectively
	C can be placed before D and M to make 400 and 900 according to the same pattern

	An example using the above rules would be 1904: this is composed of 1 (one thousand), 9 (nine hundreds), 0 (zero tens), and 4 (four units). To write the Roman numeral, each of the non-zero digits should be treated separately. Thus 1,000 = M, 900 = CM, and 4 = IV. Therefore, 1904 is MCMIV. This reflects typical modern usage rather than a universally accepted convention: historically Roman numerals were often written less consistently.

	A common exception to the practice of placing a smaller value before a larger in order to reduce the number of characters, is the use of IIII instead of IV for 4.

	Input to your program consists of Statements and Questions.  The Program should handle exceptions.

	Test input 

	cat is I
	fish is V
	pig is X
	ant is L 
	cat cat Brass is 10 Credits
	cat fish Copper is 4000 Credits
	pig pig Aluminium is 2000 Credits
	how much is pig ant cat ?
	how many Credits is cat fish Brass ?
	how many Credits is cat fish Copper ?
	how many Credits is cat fish Aluminium ?
	how much would be the cost to get Aslan on to the earth ? 

	Test Output  

	pig ant cat is 41
	cat fish Brass is 20 Credits
	cat fish Copper is 4000 Credits
	cat fish Aluminium is 400 Credits
	Exception - unable to parse 
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
	
	
