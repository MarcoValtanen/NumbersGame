using System.Net.Security;
using System.Runtime.CompilerServices;

namespace NumbersGame
{
    internal class Program
    {
        private static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            GissaNummer();
            Console.WriteLine("Vill du spela engång till?");
            string yes = Console.ReadLine();
            if (yes == "Ja")
            {
                Console.WriteLine("------------------");
                GissaNummer();
            }
        }

        private static void GissaNummer()
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket?");
            Console.WriteLine("Nivå 1: 1 - 15, 6 gissningar | Nivå 2: 1 - 25, 4 gissningar | Nivå 3: 1 - 35, 3 gissningar");

            Console.WriteLine("Vilken svårighetsgrad vill du ha?");
            int level = int.Parse(Console.ReadLine());
            int numberToGuess = NumberToGuessLevel(level);
            int count = Math.Max(3, 8 - level * 2);

            Gissning(numberToGuess, count);
        }

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
                   
                   
                }

                if (i == count - 1 && numberToGuess != guessedNumber)
                {
                    Console.WriteLine("Tyvärr så lyckades du inte gissa talet på {0} försök, rätt nummer var {1}", count, numberToGuess);
                  
                }
            }
        }

        public static int NumberToGuessLevel(int level)
        {
            int max = 10 * level + 5;
            return rnd.Next(1, max + 1);          

        }

        public static double CloseOrNot(double numtoG, double gnum, out string N)
        {
            double quitent = numtoG/gnum;
             

            if (quitent > 0.8) 
            {
                N = "Brännhett! Du är supernära.";
            }
            else if (quitent >= 0.5 && quitent <= 0.8)
            {
                N = "Varmt, du är ganska nära.";
            }
            else
            {
                N = "Kallt, inte alls nära.";
            }
            return quitent;
                    
                
            

        }

    }
}
