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
            var l = new List<Player>();
            for (int i = 0; i < 16; i++)
            {
                l.Add(new Player(i.ToString()));
            }
            Tournament tournament = new Tournament(l);

            Console.Read();
        }
    }
}
