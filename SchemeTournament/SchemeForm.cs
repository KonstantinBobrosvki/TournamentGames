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
            this.WindowState = FormWindowState.Maximized; ;
            this.FormBorderStyle = FormBorderStyle.None;
            if (tournament.AllPlayers.Count > 16 || tournament.AllPlayers.Count < 16)
            {
                throw new ArgumentException("More/Less than 16 players");
            }
            InitializeComponent();
            this.tournament = tournament;
            List<Label> StartLabels = new List<Label>{player1,player2,player3,player4,player5,
                player6,player7,player8,player9,player10,player11,player12,player13,player14,player15,player16};

           
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
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
            name.Show();
        }

        private void SecondGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][1]);
            name.Show();
        }

        private void ThirdGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][2]);
            name.Show();
        }

        private void FourthGrupBoutton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][3]);
            name.Show();
        }

        private void FifthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][4]);
            name.Show();
        }

        private void SixthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][5]);
            name.Show();
        }

        private void SeventhGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][6]);
            name.Show();
        }

        private void EighthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[1][7]);
            name.Show();
        }
        
        private void State2_Grup1Button_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[2][0]);
            name.Show();
        }

        private void State2_Grup2Button_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[2][1]);
            name.Show();
        }

        private void State2_Grup3Button_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[2][2]);
            name.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[2][3]);
            name.Show();
        }
       
        private void State3_Grup1Button_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[3][0]);
            name.Show();
        }

        private void State3_Grup2Button_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[3][1]);
            name.Show();
        }

        private void State4_Grup1Button_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[4][0]);
            name.Show();
        }
    }
}
