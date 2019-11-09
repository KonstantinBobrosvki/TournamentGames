using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBL
{
    public class WinEventArgs:EventArgs
    {
        public Player Winner { get; }
        public Player Loser { get; }
        public Match Match { get; }

        public WinEventArgs(Player winner,Player loser,Match match)
        {
            Winner = winner;
            Loser = loser;
            Match = match;
        }

    }
}
