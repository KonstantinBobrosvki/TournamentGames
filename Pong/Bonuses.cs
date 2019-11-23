using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pong
{
    public abstract class Bonus:Interactable
    {
        public Bonus(Point p):base(p)
        {

        }

        public static Bonus RandomBonus(Point p)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var res = random.Next(0, 4);
            switch (res)
            {
                case 0:
                    return new SmallerBonus(p);
                    break;
                case 1:
                    return new BiggerBonus(p);
                    break;
                case 2:
                    return new SpeedUpBonus(p);
                    break;
                case 3:
                    return new SpeedDownBonus(p);
                    break;  
                default:
                    throw new Exception();
                    break;
            }
        }


        protected void ReturnToNormal(Action<AbstaractGamer,AbstaractGamer > action,AbstaractGamer p1,AbstaractGamer p2)
        {
            Timer timer = new Timer
            {
                Interval = 10000
            };
            timer.Start();
            timer.Tick += (s, e) => {
                action.Invoke(p1, p2);
                timer.Stop();
                timer.Dispose();
            };
        }
    }

    public  class SmallerBonus : Bonus
    {
        public override Image Skin { get => skin; protected set => skin = value; }
        private Image skin;
        public override void OnColision(AbstaractGamer gamer, AbstaractGamer otherGamer)
        {
         
            gamer.ChangeSize(new Size(gamer.Hero.Size.Width, gamer.Hero.Height - 100));
            Timer timer = new Timer
            {
                Interval = 10000
            };
            timer.Start();
            timer.Tick += (s, e) => {
                gamer.ChangeSize(new Size(gamer.Hero.Size.Width, gamer.Hero.Height + 100));
                timer.Stop();
                timer.Dispose();
                
            };
        }

        public override void OnColision()
        {
          
        }

        public SmallerBonus(Point p):base(p)
        {
            Skin =new Bitmap( Resources.Resources.ZoomOut,new Size(80,80));
            ((Bitmap)Skin).MakeTransparent();
        }
    }

    public class BiggerBonus : Bonus
    {
        public override Image Skin { get => skin; protected set => skin = value; }
        private Image skin;
        public override void OnColision(AbstaractGamer gamer, AbstaractGamer otherGamer)
        {
           
            gamer.ChangeSize(new Size(gamer.Hero.Size.Width, gamer.Hero.Height + 100));
            Timer timer = new Timer
            {
                Interval = 10000
            };
            timer.Start();
            timer.Tick += (s, e) => {
                gamer.ChangeSize(new Size(gamer.Hero.Size.Width, gamer.Hero.Height - 100));
                timer.Stop();
                timer.Dispose();
            };
        }

        public override void OnColision()
        {

        }

        public BiggerBonus(Point p) : base(p)
        {
            Skin = new Bitmap(Resources.Resources.ZoomIn, new Size(80, 80));
            ((Bitmap)Skin).MakeTransparent();
        }
    }

    public class SpeedUpBonus : Bonus
    {
        public override Image Skin { get; protected set; }

        public override void OnColision(AbstaractGamer gamer, AbstaractGamer otherGamer)
        {
            gamer.SpeedY *= 2;
            Timer timer = new Timer
            {
                Interval = 10000
            };
            timer.Start();
            timer.Tick += (s, e) => {
                gamer.SpeedY/=2;
                timer.Stop();
                timer.Dispose();

            };

        }

        public override void OnColision()
        {
            throw new NotImplementedException();
        }

        public SpeedUpBonus(Point p):base(p)
        {
            Skin = new Bitmap(Resources.Resources.ArrowUp, new Size(80, 80));
            ((Bitmap)Skin).MakeTransparent();
        }
    }

    public class SpeedDownBonus : Bonus
    {
        public override Image Skin { get; protected set; }

        public override void OnColision(AbstaractGamer gamer, AbstaractGamer otherGamer)
        {
            otherGamer.SpeedY /= 2;
            Timer timer = new Timer
            {
                Interval = 10000
            };
            timer.Start();
            timer.Tick += (s, e) => {
                otherGamer.SpeedY *= 2;
                timer.Stop();
                timer.Dispose();

            };
        }

        public override void OnColision()
        {
            throw new NotImplementedException();
        }

        public SpeedDownBonus(Point p) : base(p)
        {

            Skin = new Bitmap(Resources.Resources.ArrowDown, new Size(80, 80));
            ((Bitmap)Skin).MakeTransparent();
        }
    }

}
