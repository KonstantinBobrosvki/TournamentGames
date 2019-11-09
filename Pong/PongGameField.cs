using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentBL;
namespace Pong
{
    public partial class PongGameField : Form
    {
        AbstaractGamer Player1;
        AbstaractGamer Player2;
        public PongGameField(Match match)
        {
            Player1 = new PlayerInPongController();
            Player2 = new PlayerInPongController();

            this.BackgroundImage = Player1.BackGround;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
           
        }
       
    }
}
