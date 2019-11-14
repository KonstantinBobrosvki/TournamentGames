using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public  class SmallerBonus : Interactable
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
            Bitmap flag = new Bitmap(80, 80);

            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0)), new Rectangle(0, 0, 80, 80));

            Skin = flag;
        }
    }

    public class BiggerBonus : Interactable
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
            Bitmap flag = new Bitmap(80, 80);

            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.FillRectangle(new SolidBrush(Color.FromArgb(0,255, 0)), new Rectangle(0, 0, 80, 80));

            Skin = flag;
        }
    }
}
