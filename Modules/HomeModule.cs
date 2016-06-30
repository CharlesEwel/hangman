using System.Collections.Generic;
using HangmanGame.Objects;
using Nancy;

namespace HangmanGame
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/new_game"] = _ => {
        Hangman glyph = new Hangman("glyph");
        return View["hangman.cshtml", glyph];
      };

      Get["/"] = _ => {
        return View["home.cshtml"];
      };
      Post["/guess_letter"] = _ =>{
        Hangman newHangman = Hangman.GetHangman();
        newHangman.HandleGuess(Request.Form["letter-input"]);
        return View["hangman.cshtml", newHangman];
      };
    }
  }
}
