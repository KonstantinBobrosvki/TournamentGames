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
        const int PlayerHeight = 220;
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
            match.AddLog("START");

            P2ScoreLabel.BackColor = Color.FromArgb(1, 255, 255, 255);
            P1ScoreLabel.BackColor = Color.FromArgb(1, 255, 255, 255);


            this.DoubleBuffered = true;
            CombineBackgrounds();

            match.WinEvent += Match_WinEvent;

            Timer timer = new Timer();
            timer.Tick += BonusTimerTIck;

            timer.Interval = 10000;
            timer.Start();
           
        }

        private void BonusTimerTIck(object sender,EventArgs e)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            var x = random.Next(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Width / 3 * 2);
            var y = random.Next(100, Screen.PrimaryScreen.WorkingArea.Height -100);
            Interactable bonus = null ;
            if(random.Next(0,2)==0)
            {
                bonus = new SmallerBonus(new Point(x, y));
            }
            else
            {
                bonus = new BiggerBonus(new Point(x, y));
            }
            Interactables.Add(bonus);
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
            System.Threading.Thread.Sleep(6000);

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

            var ball = Interactables.Where((p) => p is Ball).First();

            var p1Rect = new Rectangle(Player1.Position, Player1.Hero.Size);
            var p2Rect = new Rectangle(Player2.Position, Player2.Hero.Size);

            ball.Move();



            for (int i = 0; i < Interactables.Count; i++)
            {
                var temp = Interactables[i];
                if (temp is Ball)
                    continue;
                var tempBounds = new Rectangle(temp.Location, temp.Skin.Size);
                var points = FourAngles(new Rectangle(ball.Location, ball.Skin.Size));
                if (tempBounds.Contains(points[0]) || tempBounds.Contains(points[1]) || tempBounds.Contains(points[2]) || tempBounds.Contains(points[3]))
                {
                    if (ball.SpeedX < 0)
                    {
                        temp.OnColision(Player2, Player1);

                    }
                    else
                    {
                        temp.OnColision(Player1, Player2);

                    }
                    Interactables.RemoveAt(i);
                    i--;
                }
            }


            if (p1Rect.Contains(ball.Location) || p1Rect.Contains(ball.Location.X, ball.Location.Y + ball.Skin.Height))
            {
                if (ball.Location.X - ball.SpeedX < p1Rect.X + p1Rect.Width)
                {
                    ball.OnColision();
                }
                else
                {
                    ball.OnColision(Player1, Player2);

                }

            }
            else if (p2Rect.Contains(ball.Location.X + ball.Skin.Width, ball.Location.Y) || p2Rect.Contains(ball.Location.X + ball.Skin.Width, ball.Location.Y + ball.Skin.Height))
            {
                if (ball.Location.X + ball.Skin.Width - ball.SpeedX > p2Rect.X)
                {
                    ball.OnColision();
                }
                else
                {
                    ball.OnColision(Player2, Player1);

                }

            }

            if (ball.Location.Y <= 0)
            {
                ball.OnColision();
                
            }
            else if (ball.Location.Y+ball.Skin.Height >= Size.Height)
            {
                
                ball.OnColision();
                

            }
            if (ball.Location.X <= 0)
                {
                    CurrentMatch.AddPoints(Player2.Account.ID);
                    NewRound();

                    PongGameField_Resize(null, null);
                    return;

                }
                else if (ball.Location.X + ball.Skin.Width >= this.Width)
                {
                    CurrentMatch.AddPoints(Player1.Account.ID);

                    NewRound();
                    return;
                }
           
                   
                
           
         
           

        }

        private void NewRound()
        {
            System.Reflection.PropertyInfo propertyInfo = Player2.GetType().GetProperty("Position");
            propertyInfo.SetValue(Player2, Convert.ChangeType(new Point(this.Width - 100, this.Height / 2 - Player2.Hero.Height / 2), propertyInfo.PropertyType), null);

            propertyInfo = Player1.GetType().GetProperty("Position");
            propertyInfo.SetValue(Player1, Convert.ChangeType(new Point(50, this.Height / 2 - Player2.Hero.Height / 2), propertyInfo.PropertyType), null);
            

            Interactables.Clear();
            Interactables.Add(new Ball(new Point(this.Width / 2, this.Height / 2)));
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


        /// <summary>
        /// Returns 4 points of rect.0 is Top left 3 is Bot right
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Point[] FourAngles(Rectangle rect)
        {
            var res = new Point[4];
            res[0] = rect.Location;
            res[1] = new Point(rect.Location.X + rect.Width, rect.Location.Y);
            res[2] = new Point(rect.Location.X, rect.Location.Y + rect.Height);
            res[3] = new Point(rect.Location.X + rect.Width, rect.Location.Y + rect.Height);

            return res;
        }

        private void PongGameField_Load(object sender, EventArgs e)
        {

        }
    }
}
