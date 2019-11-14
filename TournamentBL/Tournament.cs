using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBL
{

    public class Tournament
    {
        /// <summary>
        /// All resgistred Players
        /// </summary>
        public List<Player> AllPlayers { get; private set; } 
        /// <summary>
        /// All rounds
        /// </summary>
        public List<Match[]> Rounds { get; private set; }
        /// <summary>
        /// Number of current round
        /// </summary>
        public int CurrentRound { get; private set; } = 0;
       
        /// <summary>
        /// Players in current round
        /// </summary>
        public List<Player> CurrentRoundPlayers { get; private set; }

        public bool Finished { get; private set; }

        public event EventHandler RoundFinishedEvent;

        public event EventHandler TournamentFinishedEvent;


        public Tournament(string[] names)
        {
            AllPlayers = new List<Player>(names.Length);
            Rounds = new List<Match[]>(4);
            CurrentRoundPlayers = new List<Player>();
            Rounds.Add( new Match[0]);
            for (int i = 0; i < names.Length; i++)
            {
                var item = names[i];
                AllPlayers.Add(new Player(item));
                CurrentRoundPlayers.Add(AllPlayers[i]);
            }
        }

        

        public void CreateRound()
        {

            CurrentRound++;

            if (Rounds[CurrentRound - 1].Select((p) => p.Finished).Where((p)=>p).Count() != Rounds[CurrentRound - 1].Length)
                    throw new Exception("Current round is not finished");





            if (CurrentRoundPlayers.Count % 2 == 0)
            {
                Random random = new Random();

                HashSet<int> allUsedPlayersId = new HashSet<int>();
                Rounds.Add(new Match[CurrentRoundPlayers.Count / 2]);
                var roind = 0;
                for (int i = 0; i < CurrentRoundPlayers.Count; i++)
                {
                    int secondPlayerIndex = random.Next(i + 1, CurrentRoundPlayers.Count);

                    if (allUsedPlayersId.Contains(i))
                        continue;

                    allUsedPlayersId.Add(i);
                    while (allUsedPlayersId.Contains(secondPlayerIndex) || secondPlayerIndex == i)
                    {
                        secondPlayerIndex = random.Next(i + 1, CurrentRoundPlayers.Count);
                    }
                    allUsedPlayersId.Add(secondPlayerIndex);


                    var p1 = CurrentRoundPlayers[i];
                    var p2 = CurrentRoundPlayers[secondPlayerIndex];
                    var match = new Match(p1, p2);
                    Rounds[CurrentRound][roind++] = match;
                    match.WinEvent += MatchFinished;


                }

            }
            else
                throw new Exception("Must be even");
        }

        public void FinishRound()
        {
            if (Rounds[CurrentRound].Select((p) => p.Finished).Where((p) => p).Count() != Rounds[CurrentRound].Length)
                throw new Exception("Current round matchs are not finished");
            CurrentRoundPlayers = new List<Player>(Rounds[CurrentRound].Length);
            foreach (var item in Rounds[CurrentRound])
            {
                if(item.WinnerID==item.PlayerOne.ID)
                {
                    CurrentRoundPlayers.Add(item.PlayerOne);
                }
                else
                {
                    CurrentRoundPlayers.Add(item.PlayerTwo);

                }
            }
        }

        private void MatchFinished(object sender,EventArgs e)
        {
            foreach (var item in Rounds[CurrentRound])
            {
                if (!item.Finished)
                    return;
            }

            if (Rounds[CurrentRound].Length == 1)
                TournamentFinishedEvent?.Invoke(this, new EventArgs());
            else
            RoundFinishedEvent?.Invoke(this, new EventArgs());

        }

    }
}
