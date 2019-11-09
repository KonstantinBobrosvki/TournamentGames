using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TournamentBL;

namespace Pong
{
    public abstract class AbstaractGamer
    {
        public abstract Image BackGround { get;  }
        public int SpeedX { get; protected set; }
        public int SpeedY { get; protected set; }
        public PictureBox Hero { get; protected set; }
        public Player Account { get; }

        public AbstaractGamer(PictureBox box,Player mainAccount )
        {
            Hero = box;
        }

        public virtual void MoveUp()
        {
            Hero.Location = new Point(Hero.Location.X, Hero.Location.Y - SpeedY);
        }
        public virtual void MoveDown()
        {
            Hero.Location = new Point(Hero.Location.X, Hero.Location.Y + SpeedY);
        }
        public virtual void MoveLeft()
        {
            Hero.Location = new Point(Hero.Location.X+SpeedX, Hero.Location.Y );
        }
        public virtual void MoveRight()
        {
            Hero.Location = new Point(Hero.Location.X + SpeedX, Hero.Location.Y);
        }
    }
}
