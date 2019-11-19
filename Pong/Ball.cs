using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Ball : Interactable
    {
        public override Image Skin
        {
            get =>skin;
            protected set => skin = value;
        }
        Image skin;
        public override void OnColision(AbstaractGamer gamer, AbstaractGamer otherGamer)
        {
            if (gamer is PlayerInPongController && otherGamer is PlayerInPongController)
            {
                SpeedX = SpeedX * -12 / 10;
                SpeedY = SpeedY * 12 / 10;
            }
            
            SoundPlayer simpleSound = new SoundPlayer(Resources.Resources.Udar);
            simpleSound.Play();

        }

        public override void OnColision()
        {
           
                SpeedY =  SpeedY * -12 / 10;
        }
        public Ball(Point p):base(p)
        {
            var image = new Bitmap(80, 80);
            Graphics g = Graphics.FromImage(image);
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 255)), 0, 0, 80, 80);

         

            Random random = new Random();
            var temp = random.Next(-15, 15);
            while (temp > -8 && temp < 8)
                temp = random.Next(-15, 15);
            SpeedX =  temp;
            temp = random.Next(-10, 10);
            while (temp > -5 && temp < 5)
                temp = random.Next(-15, 15);
            SpeedY = temp;
            

            Skin = image;

        }
    }
}
