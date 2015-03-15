using System;
using System.Collections.Generic;
using System.Linq;
using TradeWithNarnia.Manager;
using TradeWithNarnia.RawText;
using TradeWithNarnia.Symbol;
using Microsoft.Practices.Unity;

namespace TradeWithNarnia.Parsers.WordParser
{
  /// <summary>
  /// Default implementation of IParsedWords that implements parsing for TradeWithNarnia problem
  /// </summary>
  public class ParsedWordsImpl : IParsedWords
  {
    private IEnumerable<string> _words = new List<string>();

    [Dependency]
    public AliasManager AliasMgr { get; set; }

    private IEnumerable<string> LeftHalfWords
    {
      get
      {
        return _words.TakeWhile(word => !WordConstants.IN_THE_MIDDLE_WORDS.Contains(word)).ToList();
      }
    }

    private IEnumerable<string> RightHalfWords
    {
      get
      {
        return _words.Reverse().TakeWhile(word => !WordConstants.IN_THE_MIDDLE_WORDS.Contains(word)).Reverse().ToList();
      }
    }

    private IEnumerable<string> RedundantWords
    {
      get
      {
        return _words.Where(word => WordConstants.IN_THE_MIDDLE_WORDS.Contains(word) || WordConstants.QUESTION_SUFFIX_WORDS.Contains(word) || WordConstants.REDUNDANT_WORDS.Contains(word)).ToList();
      }
    }

    private bool HasWordInTheMiddle
    {
      get { return _words.Any(x => WordConstants.IN_THE_MIDDLE_WORDS.Contains(x)); }
    }


    public IEnumerable<string> TrimmedLeftHalfWords
    {
      get { return LeftHalfWords.Where(word => !RedundantWords.Contains(word)); }
    }

    public IEnumerable<string> TrimmedRightHalfWords
    {
      get { return RightHalfWords.Where(word => !RedundantWords.Contains(word)); }
    }

    public bool IsQuestion
    {
      get
      {
        return WordConstants.QUESTION_SUFFIX_WORDS.Contains(_words.Last());
      }
    }

    public bool IsStatement
    {
      get
      {
        bool isStatement = false;

        if(!IsQuestion && HasWordInTheMiddle && HasSingleUnknownWord(TrimmedLeftHalfWords) && HasSingleUnknownWord(TrimmedRightHalfWords))
        {
          if(IsArabicNumber(GetSingleUnknownWord(TrimmedRightHalfWords)) || IsRomanSymbol(GetSingleUnknownWord(TrimmedRightHalfWords))
            &&
            !IsArabicNumber(GetSingleUnknownWord(TrimmedLeftHalfWords)) && !IsRomanSymbol(GetSingleUnknownWord(TrimmedLeftHalfWords)))
          {
            isStatement = true;
          }
        }

        return isStatement;
      }
    }

    public void SetSingleLineText(SingleLineText singleLineText_)
    {
      _words = singleLineText_.SeparatedStrings;
    }

    public bool HasSingleUnknownWord(IEnumerable<string> words_)
    {
      return GetSingleUnknownWord(words_) != null;
    }

    public string GetSingleUnknownWord(IEnumerable<string> words_)
    {
      var wordsList = GetUnknownWords(words_);

      if (wordsList.Count() == 1)
      {
        return wordsList.First();
      }
      return null;
    }


    public IEnumerable<string> GetUnknownWords(IEnumerable<string> words_)
    {
      IList<string> wordsList = words_.ToList();

      IList<string> markForRemovalWords = wordsList.Where(word =>
        WordConstants.REDUNDANT_WORDS.Contains(word.ToLower())
        || WordConstants.IN_THE_MIDDLE_WORDS.Contains(word.ToLower())
        || WordConstants.QUESTION_SUFFIX_WORDS.Contains(word.ToLower())
        || AliasMgr.AllAliases().Contains(word.ToLower())).ToList();

      foreach (var markForRemovalWord in markForRemovalWords)
      {
        wordsList.Remove(markForRemovalWord);
      }

      return wordsList;
    }

    public IEnumerable<string> GetAliases(IEnumerable<string> words_)
    {
      var aliasList = new List<string>();
      foreach (var word in words_)
      {
        if(AliasMgr.AllAliases().Contains(word.ToLower()))
        {
          aliasList.Add(word.ToLower());
        }
      }
      return aliasList;
      //return words_.Where(word => AliasMgr.AllAliases().Contains(word.ToLower())).ToList();
    }

    public bool HasAliases(IEnumerable<string> words_)
    {
      return GetAliases(words_).Any();
    }

    private bool IsRomanSymbol(string word)
    {
      return GetRomanSymbol(word) != null;
    }

    private RomanSymbol? GetRomanSymbol(string word)
    {
      IEnumerable<string> names = Enum.GetNames(typeof(RomanSymbol));

      RomanSymbol? romanSymbol = null;
      foreach (var name in names)
      {
        if (string.Equals(name, word, StringComparison.CurrentCultureIgnoreCase))
        {
          romanSymbol = (RomanSymbol) Enum.Parse(typeof (RomanSymbol), name);
          break;
        }
      }
      return romanSymbol;
    }

    private bool IsArabicNumber(string word)
    {
      return GetArabicNumber(word) != null;
    }

    private int? GetArabicNumber(string word)
    {
      int? returnValue = null;
      int tempValue;
      if(Int32.TryParse(word, out tempValue))
      {
        returnValue = tempValue;
      }
      return returnValue;
    }
  }
}
