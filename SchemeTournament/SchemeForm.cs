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
using Pong;
namespace SchemeTournament
{
    public partial class SchemeForm : Form
    {
        public Tournament tournament;
        public SchemeForm(Tournament tournament)
        {
            
            this.WindowState = FormWindowState.Maximized;
            //TODO: Delete this befroe competition
            //Ако  ще изтриеш този ред венци ще ти навра чадъра на габито отзад // НЯМА ДА ПОСМЕЕЕЕЕШШШШШШ АЗ ПЪРВИ ЩЕ ТИ ГО НАВРА.
            
            InitializeComponent();
            this.tournament = tournament;
            List<Label> StartLabels = new List<Label>{player1,player2,player3,player4,player5,
                player6,player7,player8,player9,player10,player11,player12,player13,player14,player15,player16};
            foreach (Control item in Controls)
            {
                if(item is GroupBox group)
                {
                    foreach (Control it in group.Controls)
                    {
                        if (it.Width == 0)
                        {
                         
                            it.Size = new Size( 79, item.Height);
                            it.Text = "Player";
                        }
                    }
                }
            }
            tournament.CreateRound();
            for (int i = 0; i <16; i++)
            {
                if(i%2==0)
                StartLabels[i].Text = this.tournament.Rounds[1][i/2].PlayerOne.ToString();
                else
                StartLabels[i].Text = this.tournament.Rounds[1][i/2].PlayerTwo.ToString();

            }
            tournament.RoundFinishedEvent += Tournament_RoundFinishedEvent;
        }

        private void Tournament_RoundFinishedEvent(object sender, EventArgs e)
        {
            tournament.FinishRound();
            tournament.CreateRound();
            if (tournament.CurrentRound == 2)
            {
                List<Label> next = new List<Label> { State2_P1, State2_P2, State2_P3, State2_P4, State2_P5, State2_P6, State2_P7, State2_P8 };
                for (int i = 0; i < 8; i++)
                {
                    if (i % 2 == 0)
                        next[i].Text = this.tournament.Rounds[2][i / 2].PlayerOne.ToString();
                    else
                        next[i].Text = this.tournament.Rounds[2][i / 2].PlayerTwo.ToString();

                }
            }
            else if (tournament.CurrentRound == 3)
            {
                List<Label> next = new List<Label> { State3_P1, State3_P2, State3_P3, State3_P4};
                for (int i = 0; i < 4; i++)
                {
                    if (i % 2 == 0)
                        next[i].Text = this.tournament.Rounds[3][i / 2].PlayerOne.ToString();
                    else
                        next[i].Text = this.tournament.Rounds[3][i / 2].PlayerTwo.ToString();

                }
            }
            else if (tournament.CurrentRound == 4)
            {
                List<Label> next = new List<Label> { State4_P1, State4_P2 };
                for (int i = 0; i < 2; i++)
                {
                    if (i % 2 == 0)
                        next[i].Text = this.tournament.Rounds[4][i / 2].PlayerOne.ToString();
                    else
                        next[i].Text = this.tournament.Rounds[4][i / 2].PlayerTwo.ToString();

                }
            }
            FirstState.Location = new System.Drawing.Point(12, 3);
            this.FirstState.Name = "FirstState";
            this.FirstState.Size = new System.Drawing.Size(319, 1046);
            this.SecondState.Location = new System.Drawing.Point(404, 179);
            this.SecondState.Name = "SecondState";
            this.SecondState.Size = new System.Drawing.Size(336, 693);
            this.FourthState.Location = new System.Drawing.Point(1191, 420);
            this.FourthState.Name = "FourthState";
            this.FourthState.Size = new System.Drawing.Size(350, 212);
            this.ThirdState.Location = new System.Drawing.Point(807, 357);
            this.ThirdState.Name = "ThirdState";
            this.ThirdState.Size = new System.Drawing.Size(298, 340);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FirstState.Location = new System.Drawing.Point(12, 3);
            this.FirstState.Name = "FirstState";
            this.FirstState.Size = new System.Drawing.Size(319, 1046);
            this.SecondState.Location = new System.Drawing.Point(404, 179);
            this.SecondState.Name = "SecondState";
            this.SecondState.Size = new System.Drawing.Size(336, 693);
            this.FourthState.Location = new System.Drawing.Point(1191, 420);
            this.FourthState.Name = "FourthState";
            this.FourthState.Size = new System.Drawing.Size(350, 212);
            this.ThirdState.Location = new System.Drawing.Point(807, 357);
            this.ThirdState.Name = "ThirdState";
            this.ThirdState.Size = new System.Drawing.Size(298, 340);
            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
           
            vScrollBar1.Scroll += (sender1, e1) => {


                FirstState.Top = 3-vScrollBar1.Value*6;
                SecondState.Top = 179-vScrollBar1.Value*6;
                ThirdState.Top = 357 - vScrollBar1.Value * 6;
                FourthState.Top = 420 - vScrollBar1.Value * 6;

            };
            ScrollBar hScrollBar = new HScrollBar();
            hScrollBar.Dock = DockStyle.Bottom;
            hScrollBar.Scroll += (sender1, e1) => {


                 FirstState.Left = 12 - hScrollBar.Value * 6;
                 SecondState.Left = 404 - hScrollBar.Value * 6;
                 ThirdState.Left = 807 - hScrollBar.Value * 6;
                 FourthState.Left = 1191 - hScrollBar.Value * 6;

             };
            Controls.Add(vScrollBar1);
            Controls.Add(hScrollBar);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void player1_Click(object sender, EventArgs e)
        {

        }

        private void player2_Click(object sender, EventArgs e)
        {

        }
        private void FirstGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][0]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
            name.Show();
        }

        private void SecondGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][1]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
            name.Show();
        }

        private void ThirdGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][2]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
            name.Show();
        }

        private void FourthGrupBoutton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][3]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;

            name.Show();
        }

        private void FifthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][4]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;

            name.Show();
        }

        private void SixthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][5]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
            name.Show();
        }

        private void SeventhGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][6]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
            name.Show();
        }

        private void EighthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][7]);
            name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
            name.Show();
        }
        
        private void State2_Grup1Button_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[2][0]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }

        private void State2_Grup2Button_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[2][1]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }

        private void State2_Grup3Button_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[2][2]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[2][3]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }
       
        private void State3_Grup1Button_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[3][0]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }

        private void State3_Grup2Button_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[3][1]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }

        private void State4_Grup1Button_Click(object sender, EventArgs e)
        {
            try
            {
                PongGameField name = new PongGameField(tournament.Rounds[4][0]);
                name.CurrentMatch.WinEvent += (s, a) => ((Button)sender).Enabled = false;
                name.Show();
            }
            catch
            {
                MessageBox.Show("Mach is not created already !");
            }
        }
    }
}
