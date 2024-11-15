// Hangman game made by Preston Fitzgerald for BYU Coding Challenge 15 November 2024
// This is all of the functions needed to actually play the game

namespace PrestonFitzgeraldCodeChallengeHangman
{
    internal class Functions
    {

        // creates a new game and sets some of the basic parameters
        public static hangmanGame newGame()
        {
            
            hangmanGame game = new hangmanGame();

            for (int i = 0; i < game.Word.Length; i++)
            {
                if (!game.CorrectLetters.Contains(game.Word[i]))
                {
                    game.CorrectLetters.Append(game.Word[i]);
                }

                game.GuessedText = game.GuessedText + "_ ";
            }

            return game;
        }

        public static void guess(hangmanGame game, char guessedLetter)
        {
            game.GuessedLetters += guessedLetter;
            game.TotalGuesses++;

            if (game.Word.Contains(guessedLetter))
            {
                correct(game, guessedLetter);
            }
            else
            {
                incorrect(game, guessedLetter);
            }
            

        }

        public static void correct(hangmanGame game, char guessedLetter)
        {;
            game.CorrectLetters += guessedLetter;

            game.GuessedText = "";

            int correctLetters = 0;

            for (int i = 0; i < game.Word.Length; i++)
            {
                if (game.CorrectLetters.Contains(game.Word[i]))
                {
                    game.GuessedText += game.Word[i] + " ";
                    correctLetters++;
                }
                else
                {
                    game.GuessedText += "_ ";
                }
            }

            if (correctLetters == game.Word.Length)
            {
                game.GameActive = false;
                Console.WriteLine( $"""
                You did it! You guessed the word {game.Word} in {game.TotalGuesses} guesses!
                Do you want to play again? (y/N)
                """);
            }
        }

        public static void incorrect(hangmanGame game, char guessedLetter)
        {
            game.WrongGuesses++;
            Console.WriteLine($"The word does not contain the letter \"{guessedLetter}\". You have {6-game.WrongGuesses} guess(es) remaining.");

            if (game.WrongGuesses == 6)
            {
                game.GameActive = false;
                Console.WriteLine($"To the gallows with you! We have no space for people who can't guess the word {game.Word} in {game.TotalGuesses} guesses.");
                Console.WriteLine(Functions.drawGallows(game.WrongGuesses));
                Console.WriteLine("\nWell, you hung this time, but we offer a two for one deal! Would you like to try again? (y/N)");
            }
        }

        public static void validateGuess(hangmanGame game, string guessedLetter)
        {
            if ((guessedLetter != null) && (guessedLetter != ""))
            {
                char guessedChar = (char)guessedLetter.First();
                if (!Char.IsLetter(guessedChar))
                {
                    Console.WriteLine("Sorry, the guess needs to be a letter. Try again.");
                }
                else if (game.GuessedLetters.Contains(guessedChar))
                {
                    Console.WriteLine("Sorry, you alread guessed that letter. Try again. ");
                }
                else
                {
                    guess(game, guessedChar);
                }
            }
            else
            {
                Console.WriteLine("Well, you have to put something!");
            }


        }

        public static string drawGallows(int wrongGuesses)
        {
            string[] gallowsArt = [
                """
                  __________
                  |         |
                  |
                  |
                  |
                  |
                  |
                  |
                __|__
                """,
                """
                  __________
                  |         |
                  |         O
                  |
                  |
                  |
                  |
                  |
                __|__
                """,
                """
                  __________
                  |         |
                  |         O
                  |         |
                  |         |
                  |
                  |
                  |
                __|__
                """,
                """
                  __________
                  |         |
                  |        _O
                  |       / |
                  |         |
                  |
                  |
                  |
                __|__
                """,
                """
                  __________
                  |         |
                  |        _O_
                  |       / | \
                  |         |
                  |
                  |
                  |
                __|__
                """,
                """
                  __________
                  |         |
                  |        _O_
                  |       / | \
                  |         |
                  |       _/
                  |       
                  |
                __|__
                """,
                """
                  __________
                  |         |
                  |        _O_
                  |       / | \
                  |         |
                  |        _/\_
                  |       
                  |
                __|__
                """
                ];

            return gallowsArt[wrongGuesses];
        }
    }
}
