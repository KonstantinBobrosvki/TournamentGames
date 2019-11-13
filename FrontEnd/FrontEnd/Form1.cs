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
        public Form1(Tournament tournament)
        {
            if (tournament.AllPlayers.Count > 16 || tournament.AllPlayers.Count < 16)
            {
                throw new ArgumentException("More/Less than 16 players");
            }
            List<Label> StartLabels = new List<Label>{player1,player2,player3,player4,player5,
                player6,player7,player8,player9,player10,player11,player12,player13,player14,player15,player16};
            List<Player> players = tournament.AllPlayers;
            for (int i = 0; i < StartLabels.Count; i++)
            {
                StartLabels[i].Text = players[i].Name;
            }
            InitializeComponent();
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
            
        }
    }
}
