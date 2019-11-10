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
        List<Interactable> Interactables = new List<Interactable>(3);
        public Match CurrentMatch { get; }


        public PongGameField(Match match)
        {
           
            
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();

            Player1 = new PlayerInPongController(CreateRGBImage(50,60,14), match.PlayerOne);
            Player2 = new PlayerInPongController(CreateRGBImage(128, 128, 128), match.PlayerTwo);

            CurrentMatch = match;
            match.WinRoundEvent += Match_WinRoundEvent;
            P2ScoreLabel.BackColor = Color.FromArgb(1, 255, 255, 255);
            P1ScoreLabel.BackColor = Color.FromArgb(1, 255, 255, 255);

            this.DoubleBuffered = true;
            CombineBackgrounds();

            match.WinEvent += Match_WinEvent;

           
        }

        private void Match_WinEvent(object sender, WinEventArgs e)
        {
            MainGameLoopTimer.Enabled = false;
            this.Refresh();
            if (e.Winner.Equals(Player1.Account))
            {
                P1ScoreLabel.Text = Player1.Account.Name + " won ";
                this.CreateGraphics().DrawString(Player1.Account.Name + " is Winner", new Font("Arial", 50, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 0, 0)), this.Width / 2 - 100, this.Height / 2 - 50);
            }
            else
            {
                P2ScoreLabel.Text = Player2.Account.Name + " won";
                this.CreateGraphics().DrawString(Player2.Account.Name +  " is Winner", new Font("Arial", 50, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 0, 0)), this.Width / 2 - 100, this.Height / 2 - 50);
            }
            System.Threading.Thread.Sleep(1000);

        }

        private void Match_WinRoundEvent(object sender, WinnedRoundEventArgs e)
        {
            if(e.WinnerOfRound.Equals(Player1.Account))
            {
                P1ScoreLabel.Text = Player1.Account.Name + " won in " + e.WinnedRounds + " rounds";
                this.CreateGraphics().DrawString(Player1.Account.Name + " Scores", new Font("Arial", 50, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), this.Width / 2 - 100, this.Height / 2 - 50);
            }
            else
            {
                P2ScoreLabel.Text = Player2.Account.Name + " won in " + e.WinnedRounds +" rounds";
                this.CreateGraphics().DrawString(Player2.Account.Name + "Scores", new Font("Arial", 50, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), this.Width / 2 - 100, this.Height / 2 - 50);
            }
                System.Threading.Thread.Sleep(500);

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

            foreach (var item in Interactables)
            {
                graphics.DrawImage(item.Skin, item.Location);

            }
        }

        private void MainGameLoopTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            CheckColisions();
        }

        private void CheckColisions()
        {
            var balls = Interactables.Where((p)=>p is Ball).ToList();
            
            var p1Rect = new Rectangle(Player1.Position, Player1.Hero.Size);
            var p2Rect = new Rectangle(Player2.Position, Player2.Hero.Size);


            for (int i = 0; i < balls.Count; i++)
            {
                var item = balls[i];
                item.Move();
                if (p1Rect.Contains(Interactables[0].Location) || p1Rect.Contains(item.Location.X, item.Location.Y + item.Skin.Height))
                {
                    if (item.Location.X  + item.SpeedX < p2Rect.X+p2Rect.Width)
                    {
                        item.OnColision();
                    }
                    else
                    {
                        item.OnColision(Player1, Player2);

                    }

                }
                else if (p2Rect.Contains(item.Location.X + item.Skin.Width, item.Location.Y) || p2Rect.Contains(item.Location.X + item.Skin.Width, item.Location.Y + item.Skin.Height))
                {
                    if (item.Location.X + item.Skin.Width - item.SpeedX>p2Rect.X)
                    {
                        item.OnColision();
                    }
                    else
                    {
                        item.OnColision(Player2, Player1);

                    }

                }

                if (item.Location.Y <= 0)
                    item.OnColision();
                else if (item.Location.Y >= Screen.PrimaryScreen.WorkingArea.Height)
                    item.OnColision();

                if (item.Location.X <= 0)
                {
                    CurrentMatch.AddPoints(Player2.Account.ID);

                    PongGameField_Resize(null, null);
                    break;

                }
                else if (item.Location.X + item.Skin.Width >= this.Width)
                {
                    CurrentMatch.AddPoints(Player1.Account.ID);

                    PongGameField_Resize(null, null);
                    break;
                }
            }
                   
                
           
         
           

        }

        private void PongGameField_Resize(object sender, EventArgs e)
        {

            System.Reflection.PropertyInfo propertyInfo = Player2.GetType().GetProperty("Position");
            propertyInfo.SetValue(Player2, Convert.ChangeType(new Point(this.Width - 100, this.Height / 2-Player2.Hero.Height/2), propertyInfo.PropertyType), null);

            propertyInfo = Player1.GetType().GetProperty("Position");
            propertyInfo.SetValue(Player1, Convert.ChangeType(new Point(50, this.Height / 2 - Player2.Hero.Height / 2), propertyInfo.PropertyType), null);

            Interactables.Clear();
            Interactables.Add(new Ball(new Point(this.Width/2, this.Height / 2)));
           
        }

    }
}
