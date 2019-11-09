using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentBL;

namespace Pong
{
    public class PlayerInPongController :AbstaractGamer
    {
        public override Image BackGround
        {
            get
            {

                Bitmap flag = new Bitmap(200, 100);
                Graphics flagGraphics = Graphics.FromImage(flag);
                
                    flagGraphics.FillRectangle(Brushes.White, 0, 0, 200, 100);
                
                return flag;
            }

        }

        
       
        public int Speed { get; private set; } 

        public PlayerInPongController(PictureBox box):base(box)
        {

        }
        

    }
}
