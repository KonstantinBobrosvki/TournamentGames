using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBL
{
    [Serializable]
    public class Player
    {
        static int Id;

        /// <summary>
        /// Special uniacal number
        /// </summary>
        public int ID { get; }

        public string Name { get; }

        public int WinsRounds {
            get => winsRounds;
            set
            {
                if(value< winsRounds || value<0)
                {
                    throw new ArgumentOutOfRangeException("You can not reduce wins count");
                }
                winsRounds = value;
            }

        }
        private int winsRounds;

        public int LoseRounds
        {
            get => loseRounds;
            set
            {
                if (value < loseRounds || value < 0)
                {
                    throw new ArgumentOutOfRangeException("You can not reduce lose count");
                }
                loseRounds = value;
            }

        }
        private int loseRounds;

        public int WinsGames {
            get => winsGames;
            set {
                if(value<winsGames || value<0)
                {
                    throw new ArgumentOutOfRangeException("You can not reduce wins count");
                }
                winsGames = value;
            }
        }
        private int winsGames;

        public Player(string name)
        {
            Name = name;
            this.ID = Player.Id++;
        }
    }
}
