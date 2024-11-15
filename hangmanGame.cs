// Hangman game made by Preston Fitzgerald for BYU Coding Challenge 15 November 2024
// This class represents a game of hangman

namespace PrestonFitzgeraldCodeChallengeHangman
{
    internal class hangmanGame
    {

        // constants
        private static string[] gameWords = ["potato", "caramel", "hamburger", "pizza", "sandwich", "cheesecake", "chocolate", "ketchup", "mayonnaise", "barbecue"];
        private static Random rand = new Random();

        // variables
        private bool gameActive = true;
        private int numWrongGuesses = 0;
        private string word = gameWords[rand.Next(gameWords.Length)];
        private string correctLetters = "";
        private string guessedLetters = "";
        private string guessedText = "";
        private int totalGuesses = 0;


        // getters and setters
        public string[] GameWords
        {
            get { return gameWords; }
        }
        public bool GameActive
        {
            get { return gameActive; }
            set { gameActive = !gameActive; }
        }

        public int WrongGuesses
        {
            get { return numWrongGuesses; }
            set { numWrongGuesses = value; }
        }

        public string Word
        {
            get { return word; }
        }

        public string CorrectLetters
        {
            get { return correctLetters; }
            set { correctLetters = value; }
        }

        public string GuessedLetters
        {
            get { return guessedLetters; }
            set { guessedLetters = value; }
        }

        public string GuessedText
        {
            get { return guessedText; }
            set { guessedText = value; }
        }

        public int TotalGuesses
        {
            get { return totalGuesses; }
            set { totalGuesses = value; }
        }
    }
}
