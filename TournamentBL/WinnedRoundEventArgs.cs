using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBL
{
    public class WinnedRoundEventArgs
    {
        public Player WinnerOfRound { get; }
        public int WinnedRounds { get; }
        public Player Loser { get; }

        public WinnedRoundEventArgs(Player winner,int winnedRounds,Player loser)
        {
            WinnedRounds = winnedRounds;
            WinnerOfRound = winner;
            Loser = loser;
        }
    }
}
