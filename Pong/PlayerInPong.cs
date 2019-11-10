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
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
               
                var color = Color.FromArgb( rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
               flagGraphics.FillRectangle(new SolidBrush (color), 0, 0, 200, 100);
                
                return flag;
            }

        }

        
       
        

        public PlayerInPongController(Image box, Player player) : base(box, player)
        {
            SpeedY = 10;
        }
       
        

    }
}
