using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public abstract class Interactable
    {
        public virtual int SpeedX {
            get =>speedX;
            set
            {
                if (value < -30)
                    speedX = -30;
                else if (value > 30)
                    speedX = 30;
                else
                    speedX = value;

            }

        }
        protected int speedX;
        public int SpeedY {
            get => speedY;
            set
            {
                if (value < -30)
                    speedY = -30;
                else if (value > 30)
                    speedY = 30;
                else
                    speedY = value;

            }
        }
        protected int speedY;
        public abstract  Image Skin { get; protected set; }
        public  Point Location { get; protected set; }

        /// <summary>
        /// Call on colision
        /// </summary>
        /// <param name="gamer">other object in colisions</param>
        /// <param name="otherGamer">Enemy</param>
        public abstract void OnColision(AbstaractGamer gamer,AbstaractGamer otherGamer);

        /// <summary>
        /// Call on colisions with bounds
        /// </summary>
        public abstract void OnColision();
       

        public Interactable(Point p)
        {
            Location = p;
        }
       
        public virtual void Move()
        {
            Location = new Point(Location.X + SpeedX, Location.Y + SpeedY);
        }
    }
}
