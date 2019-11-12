using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace naskoMENU
{
    public partial class Form1 : Form
    {
        private List<TextBox> play;
        private List<TextBox> points;
        public Form1()
        {
            InitializeComponent();

            TextBox[] play = new TextBox[32];
            play[0] = textBox1;
            play[1] = textBox3;
            play[2] = textBox5;
            play[3] = textBox7;
            play[4] = textBox9;
            play[5] = textBox11;
            play[6] = textBox13;
            play[7] = textBox15;
            play[8] = textBox17;
            play[9] = textBox19;
            play[10] = textBox21;
            play[11] = textBox23;
            play[12] = textBox25;
            play[13] = textBox27;
            play[14] = textBox29;
            play[15] = textBox31;
            play[16] = textBox33;
            play[17] = textBox35;
            play[18] = textBox37;
            play[19] = textBox39;
            play[20] = textBox41;
            play[21] = textBox43;
            play[22] = textBox45;
            play[23] = textBox47;
            play[24] = textBox49;
            play[25] = textBox51;
            play[26] = textBox53;
            play[27] = textBox55;
            play[28] = textBox57;
            play[29] = textBox59;
            play[30] = textBox61;
            play[31] = textBox63;
            this.play = new List<TextBox>();
            this.play.AddRange(play);

            TextBox[] points = new TextBox[32];
            points[0] = textBox2;
            points[1] = textBox4;
            points[2] = textBox6;
            points[3] = textBox8;
            points[4] = textBox10;
            points[5] = textBox12;
            points[6] = textBox14;
            points[7] = textBox16;
            points[8] = textBox18;
            points[9] = textBox20;
            points[10] = textBox22;
            points[11] = textBox24;
            points[12] = textBox26;
            points[13] = textBox28;
            points[14] = textBox30;
            points[15] = textBox32;
            points[16] = textBox34;
            points[17] = textBox36;
            points[18] = textBox38;
            points[19] = textBox40;
            points[20] = textBox42;
            points[21] = textBox44;
            points[22] = textBox46;
            points[23] = textBox48;
            points[24] = textBox50;
            points[25] = textBox52;
            points[26] = textBox54;
            points[27] = textBox56;
            points[28] = textBox58;
            points[29] = textBox60;
            points[30] = textBox62;
            points[31] = textBox64;
            this.points = new List<TextBox>();
            this.points.AddRange(points);
        }
        private void Save()
        {
            
            string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
            {
                for (int i = 0; i < points.Count; i++)
                {
                    outputFile.WriteLine(points[i].Text);
                }
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"players.txt")))
            {
                for (int i = 0; i < points.Count; i++)
                {
                    outputFile.WriteLine(play[i].Text);
                }
            }
        } 
        
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Save();
            string[] players = File.ReadAllLines(@"players.txt");
            string[] midT = File.ReadAllLines("midT.txt");
            foreach (var item in midT)
            {
                if(item != null)
                {
                    Process.Start(@"nasko.exe");
                    Application.Exit();
                    return;
                }
            }
            StreamWriter streamWriter = new StreamWriter(@"midT.txt");
            for (int i = 0; i < players.Length; i++)
            {
                streamWriter.WriteLine(players[i]);
            }
            streamWriter.Close();
            Process.Start(@"nasko.exe");
            Application.Exit();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            string[] plas = File.ReadAllLines(@"players.txt");
            string[] lines = File.ReadAllLines(@"ranklist.txt");
            for (int j = 0; j < 50; j++)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    if (int.Parse(lines[i - 1]) < int.Parse(lines[i]))
                    {
                        string temp;
                        string koki;

                        temp = lines[i];
                        koki = plas[i];

                        lines[i] = lines[i - 1];
                        plas[i] = plas[i - 1];

                        lines[i - 1] = temp;
                        plas[i - 1] = koki;
                    }
                }
            }
            for (int i = 0; i < plas.Length; i++)
            {
                play[i].Text = plas[i];
            }
            for (int i = 0; i < lines.Length; i++)
            {
                points[i].Text = lines[i];
            }
            this.Save();
            string[] plas1 = File.ReadAllLines(@"players.txt");
            string[] lines1 = File.ReadAllLines(@"ranklist.txt");
            for (int i = 0; i < plas1.Length; i++)
            {
                play[i].Text = plas1[i];
            }
            for (int i = 0; i < lines1.Length; i++)
            {
                points[i].Text = lines1[i];
            }
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void TextBox22_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox38_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox57_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox59_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox63_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
