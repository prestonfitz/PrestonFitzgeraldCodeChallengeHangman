// Hangman game made by Preston Fitzgerald for BYU Coding Challenge 15 November 2024
// This is the main program file
namespace PrestonFitzgeraldCodeChallengeHangman
{
    internal class Program
    {
        static void Main()
        {
            // initialize game and text inputs
            hangmanGame game = Functions.newGame();
            string guessedLetter;
            string playAgain;

            Console.WriteLine("Welcome. Your life is on the line. If you can't spell this word, you will be the hangman.");

            // This loop is the game
            do {
                Console.WriteLine($"Your word has {game.Word.Length} letters. Good luck!");

                // This is the guessing sequence. You go until you win or lose
                while (game.GameActive){

                    // draw gallows and guessed word
                    Console.WriteLine(Functions.drawGallows(game.WrongGuesses));
                    Console.WriteLine($"\n{game.GuessedText}");

                    // on going game information
                    if (game.GuessedLetters != "")
                    {
                        Console.WriteLine($"\nYou have made {game.TotalGuesses} guesses, {game.TotalGuesses-game.WrongGuesses} correct, {game.WrongGuesses} incorrect. \nAs a reminder, you have guessed these letters: \n{game.GuessedLetters}\n");
                    }

                    // make a guess
                    Console.WriteLine("\nPlease enter a letter:");
                    guessedLetter = Console.ReadLine();
                    guessedLetter = guessedLetter.ToLower();
                    Functions.validateGuess(game, guessedLetter);
                };

                // Determine if the user wants to play again.
                playAgain = Console.ReadLine();
                playAgain = playAgain.ToLower();
                playAgain = playAgain.First().ToString();
                if (playAgain == "y")
                {
                    game = Functions.newGame();
                }
            } while (game.GameActive);

            Console.WriteLine("Thank you for playing. Come hang with us another time!");
        }
    }
}
