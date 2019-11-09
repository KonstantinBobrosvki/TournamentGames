using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBL
{
    public delegate void WinnedRoundEventHandler(object sender, WinnedRoundEventArgs e);
    public delegate void WinEventHandler(object sender, WinEventArgs e);

    public class Match
    {

        /// <summary>
        /// Maximum count of rounds that can be player.Player must have half of them for win
        /// </summary>
        public const int MaxRoundsCount = 5;

        /// <summary>
        /// Causes on finishing of match
        /// </summary>
        public event WinEventHandler WinEvent;

        /// <summary>
        /// Causes on winning of round
        /// </summary>
        public event WinnedRoundEventHandler WinRoundEvent;

        #region Properties
        /// <summary>
        /// First Player
        /// </summary>
        public Player PlayerOne { get; }

        /// <summary>
        /// Second Player
        /// </summary>
        public Player PlayerTwo { get; }

        /// <summary>
        /// Wins of PlayerOne
        /// </summary>
        public int WonRoundP1
        {
            get => wonRoundP1;
            private set
            {
                if (value < 0 || value > MaxRoundsCount / 2 + 1)
                    throw new ArgumentOutOfRangeException("Value is correct");
                wonRoundP1 = value;
                PlayerOne.WinsRounds++;
                PlayerTwo.LoseRounds++;
                WinRoundEvent?.Invoke(this, new WinnedRoundEventArgs(PlayerOne, WonRoundP1, PlayerTwo));


            }
        }
        private int wonRoundP1;

        /// <summary>
        /// Wins of PlayerTwo
        /// </summary>
        public int WonRoundP2 {
            get => wonRoundP2;
            private set
            {
                if (value < 0 || value > MaxRoundsCount / 2 + 1)
                    throw new ArgumentOutOfRangeException("Value is correct");
                wonRoundP2 = value;
                PlayerTwo.WinsRounds++;
                PlayerOne.LoseRounds++;
                WinRoundEvent?.Invoke(this, new WinnedRoundEventArgs(PlayerTwo, WonRoundP1, PlayerOne));

            }
        }
        private int wonRoundP2;

        /// <summary>
        /// Played at the moment rounds
        /// </summary>
        public int Rounds { get; private set; }

        /// <summary>
        /// ID of the winner.Returns -1 if the match is not finished
        /// </summary>
        public int WinnerID { get; private set; } = -1;

        #endregion

        public Match(Player player1,Player player2)
        {
            PlayerOne = player1;
            PlayerTwo = player2;
            logs =new List<string>(10);
        } 

        /// <summary>
        /// Is match finished
        /// </summary>
        public bool Finished { get => WinnerID != -1; }

        public void AddLog(string log)
        {
            if (WinnerID != -1)
                throw new Exception("Match is over");
            logs.Add(log);
        }
        public IEnumerator<string> GetLogs()
        {
            return logs.GetEnumerator();
        }

        List<string> logs;

        public void AddPoints(int playerId)
        {
            if (Finished)
                throw new Exception("Game is over");

            if(!HavePlayer(playerId))
            {
                throw new ArgumentException("The player is not existing");
            }
            if (PlayerOne.ID == playerId)
            {
                WonRoundP1++;

            }
            else
            {
                WonRoundP2++;

            }

            if (WonRoundP1 == MaxRoundsCount / 2 + 1)
            {
                WinnerID = PlayerOne.ID;
                WinEvent?.Invoke(this, new WinEventArgs(PlayerOne, PlayerTwo, this));
            }
            else if (WonRoundP2 == MaxRoundsCount / 2 + 1)
            {
                WinnerID = PlayerTwo.ID;
                WinEvent?.Invoke(this, new WinEventArgs(PlayerTwo, PlayerOne, this));
            }
            


        }

        /// <summary>
        /// Checks is player exists in current match
        /// </summary>
        /// <param name="Id">Id of player for check</param>
        /// <returns>Have match got player</returns>
        public bool HavePlayer(int Id)
        {
            return PlayerOne.ID == Id || PlayerTwo.ID == Id ? true : false;
        }

        public override string ToString()
        {
            return PlayerOne.Name+" vs "+PlayerTwo.Name;
        }
    }
}
