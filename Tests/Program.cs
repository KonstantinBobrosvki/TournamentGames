using Pong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentBL;

namespace Tests
{
  
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var names = new List<string>(4);
            while (true)
            {
                string name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                    break;
                names.Add(name);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Tournament tournament = new Tournament(names.ToArray());
            tournament.CreateRound();
            foreach (var item in tournament.Rounds[tournament.CurrentRound])
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

            foreach (var item in tournament.Rounds[tournament.CurrentRound])
            {
                var ttt = new PongGameField(item);
                item.WinEvent += (w, s) => {
                    Console.WriteLine(s.Winner.Name + " wins");
                    
                    ttt.Close();

                };
              
                Application.Run(ttt);

               
            }

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
