using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentBL;

namespace FrontEnd
{
    public partial class Form1 : Form
    {
        public Tournament tournament;
        public Form1(Tournament tournament)
        {
            if (tournament.AllPlayers.Count > 16 || tournament.AllPlayers.Count < 16)
            {
                throw new ArgumentException("More/Less than 16 players");
            }
            InitializeComponent();
            this.tournament = tournament;
            List<Label> StartLabels = new List<Label>{player1,player2,player3,player4,player5,
                player6,player7,player8,player9,player10,player11,player12,player13,player14,player15,player16};

            for (int i = 0; i < tournament.AllPlayers.Count; i++)
            {
                StartLabels[i].Text = this.tournament.AllPlayers[i].ToString();
            }
            tournament.CreateRound();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
            PongGameField name = new PongGameField(tournament.Rounds[2][1]);
            name.Show();
        }

        private void ThirdGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[3][2]);
            name.Show();
        }

        private void FourthGrupBoutton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[4][3]);
            name.Show();
        }

        private void FifthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[5][4]);
            name.Show();
        }

        private void SixthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[6][5]);
            name.Show();
            name.Show();
        }

        private void SeventhGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[7][6]);
            name.Show();
        }

        private void EighthGrupButton_Click(object sender, EventArgs e)
        {
            PongGameField name = new PongGameField(tournament.Rounds[8][7]);
            name.Show();
        }
    }
}
}
