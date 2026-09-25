using System.Net.Security;
using System.Runtime.CompilerServices;

namespace NumbersGame
{
    internal class Program
    {
        //Shared random instance, to avoid multiple calls for different numbers
        private static readonly Random rnd = new Random();
        //Starting the game
        static void Main(string[] args)
        {
            GuessNumber();
           
        }
        // Asking player to play again or exit
        private static void PlayAgain()
        {
            Console.WriteLine("Vill du spela engång till? Skriv 'nej' för att avsluta");
            string yes = Console.ReadLine().ToLower();
            if (yes == "ja")
            {
                Console.Clear();
                GuessNumber();
            }
            else if (yes == "nej")
            {
                Console.WriteLine("avslutar");
            }
            else
            {
                Console.WriteLine("Felinmatning försök igen");
                PlayAgain();
            }
        }
        // Welcome message, difficulty section and starting guessing loop
        private static void GuessNumber()
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket?");
            Console.WriteLine("Nivå 1: 1 - 15, 6 gissningar | Nivå 2: 1 - 25, 4 gissningar | Nivå 3: 1 - 35, 3 gissningar");
        // Select level to play
            Console.WriteLine("Vilken svårighetsgrad vill du ha?");
            int level = int.Parse(Console.ReadLine());
            int numberToGuess = NumberToGuessLevel(level);
            int count = Math.Max(3, 8 - level * 2);

            Gissning(numberToGuess, count);
        }
        //Quessing loop, hot/cold feedback
        private static void Gissning(int numberToGuess, int count)
        {
            Console.WriteLine("Gissa nummer?");
            for (int i = 0; i < count; i++)
            {

                int guessedNumber = int.Parse(Console.ReadLine());
                if (numberToGuess > guessedNumber)
                {
                    CloseOrNot(guessedNumber,numberToGuess, out string low);
                    Console.WriteLine("Din gissning är låg, men {0}",low);
                }
                else if (numberToGuess < guessedNumber)
                {
                    CloseOrNot(numberToGuess, guessedNumber, out string high);
                    Console.WriteLine("Din gissning är hög, men {0}",high);

                }
                else if (numberToGuess == guessedNumber)
                {
                    Console.WriteLine("Wohoo! Du gjorde det! Rätt nummer var {0}", numberToGuess);
                    PlayAgain();
                   
                }

                if (i == count - 1 && numberToGuess != guessedNumber)
                {
                    Console.WriteLine("Tyvärr så lyckades du inte gissa talet på {0} försök, rätt nummer var {1}", count, numberToGuess);
                    PlayAgain();
                }
            }
        }
        //Returns random number
        public static int NumberToGuessLevel(int level)
        {
            int max = 10 * level + 5;
            return rnd.Next(1, max + 1);          

        }
        //Checks how the guess compares to randomnumber    
        public static double CloseOrNot(double numtoG, double gnum, out string N)
        {
            double diffFromNumber = numtoG/gnum;
             

            if (diffFromNumber > 0.8) 
            {
                N = "Brännhett! Du är supernära.";
            }
            else if (diffFromNumber >= 0.5 && diffFromNumber <= 0.8)
            {
                N = "Varmt, du är ganska nära.";
            }
            else
            {
                N = "Kallt, inte alls nära.";
            }
            return diffFromNumber;
            
        }

    }
}
