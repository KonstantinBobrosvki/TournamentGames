using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBL
{
    public class Tournament
    {
        public List<Player> AllPlayers { get; private set; } 
        public List<Match[]> Rounds { get; private set; }
        public int CurrentRound { get; private set; } = 0;

        public List<Player> CurrentRoundPlayers { get; private set; }

        public Tournament(string[] names)
        {
            AllPlayers = new List<Player>(names.Length);
            Rounds = new List<Match[]>(4);
            CurrentRoundPlayers = new List<Player>();
            for (int i = 0; i < names.Length; i++)
            {
                var item = names[i];
                AllPlayers.Add(new Player(item));
                CurrentRoundPlayers.Add(AllPlayers[i]);
            }
        }
        public void CreateRound()
        {
            if(AllPlayers.Count%2==0)
            {              
                Random random = new Random();
               
                HashSet<int> allUsedPlayersId = new HashSet<int>();
                CurrentRound++;
                Rounds.Add(new Match[CurrentRoundPlayers.Count/2]);
                var roind = 0;
                for (int i = 0; i < CurrentRoundPlayers.Count-1; i++)
                {
                    int secondPlayerId = random.Next(i+1, CurrentRoundPlayers.Count);

                    if (allUsedPlayersId.Contains(i))
                        continue;
                    
                    allUsedPlayersId.Add(i);
                    while (allUsedPlayersId.Contains(secondPlayerId) || secondPlayerId==i)
                    {
                         secondPlayerId = random.Next(i+1, CurrentRoundPlayers.Count);                      
                    }
                    allUsedPlayersId.Add(secondPlayerId);

                    foreach (var item in Rounds[CurrentRound - 1])
                    {
                        if (item is null)
                            continue;
                        if(item.PlayerOne.ID==i||item.PlayerTwo.ID==secondPlayerId)
                        {
                            var f = -1;
                        }
                        if (item.PlayerOne.ID == secondPlayerId || item.PlayerTwo.ID == i)
                        {
                            var f = -1;
                        }
                    }
                    var p1 = CurrentRoundPlayers.Where((p) => p.ID == i).First();
                    var p2 = CurrentRoundPlayers.Where((p) => p.ID == secondPlayerId).First();
                    Rounds[CurrentRound-1][roind++] = new Match(p1, p2); 



                }
                
            }
            else
            {

            }
        }
    }
}
