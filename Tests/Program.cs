using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBL;
namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>(10);
            for (int i = 0; i < 20; i++)
            {
                names.Add(RandomString(7));
                Console.WriteLine(names[i]);
            }
            Tournament tournament = new Tournament(names.ToArray());
            tournament.CreateRound();

            Console.WriteLine();
            var temp = tournament.Rounds[1];
            foreach (var item in temp)
            {
                Console.WriteLine(item.ToString());
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
              

            }
            tournament.FinishRound();
            tournament.CreateRound();
            temp = tournament.Rounds[2];
            Console.WriteLine();
            foreach (var item in temp)
            {
                Console.WriteLine(item.ToString());
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);


            }
            Console.Read();
         
        }

        public static string RandomString(int length)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
