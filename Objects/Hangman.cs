using System.Collections.Generic;

namespace HangmanGame.Objects
{
  public class Hangman
  {
    private string _word;
    private List<string> _wrongLetters =  new List<string>{};
    private List<string> _displayedWord = new List<string>{};
    private static List<Hangman> _hangmen = new List<Hangman>{};

    public Hangman (string newWord)
    {
    _word = newWord;
    _wrongLetters = new List<string>{};
    _displayedWord = new List<string>{};
    for(int i=1; i<=newWord.Length; i++)
    {
      _displayedWord.Add("_");
    }
    _hangmen.Add(this);
    }

    public string GetWord()
    {
      return _word;
    }
    public List<string> GetWrongLetters()
    {
      return _wrongLetters;
    }
    public List<string> GetDisplayedWord()
    {
      return _displayedWord;
    }
    public void HandleGuess(string guess)
    {
      List<int> matches = this.FindLetter(guess);
      if(matches.Count == 0)
      {
        if(_wrongLetters.Contains(guess))
        {

        }
        else
        {
          _wrongLetters.Add(guess);
        }
      }
      else
      {
        foreach(int match in matches)
        {
          _displayedWord[match]=guess;
        }
      }
    }

    public static Hangman GetHangman()
    {
      return _hangmen[0];
    }

    public List<int> FindLetter(string guessLetter)
    {
      char[] wordArray = _word.ToCharArray();
      List<int> matches = new List<int> {};
      int counter=0;
      foreach(char correctLetter in wordArray)
      {
        if (correctLetter.ToString() == guessLetter)
        {
          matches.Add(counter);
        }
        counter++;
      }
      return matches;
    }

  }
}
