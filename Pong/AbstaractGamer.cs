using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TournamentBL;
using System.Threading;

namespace Pong
{
    public abstract class AbstaractGamer
    {
        public abstract Image BackGround { get;  }
        public int SpeedX { get; protected set; }
        public int SpeedY { get; protected set; }
        public Image Hero { get; protected set; }
        public Player Account { get; }
        public Point Position { get; protected set; }

        public AbstaractGamer(Image box,Player mainAccount )
        {
            Hero = box;
            Account = mainAccount;
        }

        protected AbstaractGamer(Player main)
        {
            Account = main;

        }

        public virtual void MoveUp()
        {
           Position= new Point(Position.X, Position.Y - SpeedY);
        }
        public virtual void MoveDown()
        {
           Position= new Point(Position.X, Position.Y + SpeedY);
           
        }
        public virtual void MoveLeft()
        {
            Position = new Point(Position.X-SpeedX, Position.Y );
        }
        public virtual void MoveRight()
        {
            Position = new Point(Position.X-SpeedX, Position.Y);
        }

      

        /// <summary>
        /// New size for image
        /// </summary>
        /// <param name="size">Size</param>
        public void ChangeSize(Size size)
        {
            
            Hero = new Bitmap(Hero, size);
            
          
        }
    }
}
