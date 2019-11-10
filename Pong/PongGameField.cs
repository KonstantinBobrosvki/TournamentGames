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
        const int PlayerWidth = 80;
        const int PlayerHeight = 120;

        public PongGameField(Match match)
        {
           
            
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            Player1 = new PlayerInPongController(CreateRGBImage(50,60,14), match.PlayerOne);
            Player2 = new PlayerInPongController(CreateRGBImage(128, 128, 128), match.PlayerTwo);
            this.DoubleBuffered = true;
            CombineBackgrounds();


        }
        Image CreateRGBImage(int r,int g,int b)
        {
            Bitmap flag = new Bitmap(PlayerWidth,PlayerHeight);

            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.FillRectangle(new SolidBrush(Color.FromArgb(r,g,b)),new Rectangle(0,0,PlayerWidth,PlayerHeight) );

            return flag;
        }

        private void CombineBackgrounds()
        {
            Bitmap flag = new Bitmap(Player2.BackGround.Width + Player1.BackGround.Width, (Player1.BackGround.Height + Player2.BackGround.Height) / 2);

            Graphics flagGraphics = Graphics.FromImage(flag);

            flagGraphics.DrawImage(Player1.BackGround,new Rectangle(0,0,Player1.BackGround.Width, (Player1.BackGround.Height + Player2.BackGround.Height) / 2));
            flagGraphics.DrawImage(Player2.BackGround, new Rectangle(Player1.BackGround.Width, 0, Player2.BackGround.Width, (Player1.BackGround.Height + Player2.BackGround.Height) / 2));

            this.BackgroundImage = flag;
        }

        private void PongGameField_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void PongGameField_KeyDown(object sender, KeyEventArgs e)
        {
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.S))
                Player1.MoveDown();
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.A))
                Player1.MoveLeft();
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.W))
                Player1.MoveUp();
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.D))
                Player1.MoveRight();
            

            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Down))
                Player2.MoveDown();
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Up))
                Player2.MoveUp();
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Left))
                Player2.MoveLeft();
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Right))
                Player2.MoveRight();
            

        }

        private void PongGameField_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImage(Player1.Hero, Player1.Position);
            graphics.DrawImage(Player2.Hero, Player2.Position);

        }

        private void MainGameLoopTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void PongGameField_Resize(object sender, EventArgs e)
        {

            System.Reflection.PropertyInfo propertyInfo = Player2.GetType().GetProperty("Position");
            propertyInfo.SetValue(Player2, Convert.ChangeType(new Point(this.Width - 100, this.Height / 2-Player2.Hero.Height/2), propertyInfo.PropertyType), null);

            propertyInfo = Player1.GetType().GetProperty("Position");
            propertyInfo.SetValue(Player1, Convert.ChangeType(new Point(50, this.Height / 2 - Player1.Hero.Height/2), propertyInfo.PropertyType), null);
        }
    }
}
