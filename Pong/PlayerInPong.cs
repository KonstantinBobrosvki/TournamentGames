using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TournamentBL;

namespace Pong
{
    public class PlayerInPongController :AbstaractGamer
    {
        private static bool Right=true;
        public override Image BackGround
        {
            get
            {
                Bitmap originalImage = new Bitmap(Resources.Resources.Cort);
                Rectangle rect = new Rectangle(0, 0, originalImage.Width / 2, originalImage.Height);
                Bitmap firstHalf = originalImage.Clone(rect, originalImage.PixelFormat);
            
                rect = new Rectangle(originalImage.Width / 2, 0, originalImage.Width / 2, originalImage.Height);
                Bitmap secondHalf = originalImage.Clone(rect, originalImage.PixelFormat);
                if (Right)
                {

                    Right = false;
                    return firstHalf;
                }
                else
                {
                    Right = true;

                  
                    return secondHalf;
                }
               
            }

        }

        
       
        

        public PlayerInPongController(Image box, Player player) : base( player)
        {
         
            Hero= new Bitmap(Resources.Resources.Rocket, box.Size);
            ((Bitmap)Hero).MakeTransparent();
            SpeedY = 20;
        }

       
        

    }
}
