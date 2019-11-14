using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentBL;
namespace TEstts
{
    class Program
    {
        static void Main(string[] args)
        {
            var z = new string[16];
            for (int i = 0; i < 16; i++)
            {
                z[i] = RandomString(7);
            }

            Tournament tournament = new Tournament(z);
            tournament.RoundFinishedEvent += (f, g) => Console.WriteLine("Round Finished");
            tournament.TournamentFinishedEvent += (g, h) => Console.WriteLine("Tournament Finishe");

            tournament.CreateRound();
            foreach (var item in tournament.Rounds[1])
            {
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);

            }
            tournament.FinishRound();

            tournament.CreateRound();
            foreach (var item in tournament.Rounds[2])
            {
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);

            }
            tournament.FinishRound();

            tournament.CreateRound();
            foreach (var item in tournament.Rounds[3])
            {
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);

            }
            tournament.FinishRound();

            tournament.CreateRound();
            foreach (var item in tournament.Rounds[4])
            {
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);
                item.AddPoints(item.PlayerOne.ID);

            }
            tournament.FinishRound();

            Console.Read();
        }
  
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
