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

namespace nasko
{
    public partial class Sheme : Form
    {
        private List<TextBox> members;
        public List<CheckBox> checkBoxes;
        public Sheme()
        {
            InitializeComponent();
           
            TextBox[] members = new TextBox[63];
            members[0] = text1;
            members[1] = text2;
            members[2] = text3;
            members[3] = text4;
            members[4] = text5;
            members[5] = text6;
            members[6] = text7;
            members[7] = text8;
            members[8] = text9;
            members[9] = text10;
            members[10] = text11;
            members[11] = text12;
            members[12] = text13;
            members[13] = text14;
            members[14] = text15;
            members[15] = text16;
            members[16] = text17;
            members[17] = text18;
            members[18] = text19;
            members[19] = text20;
            members[20] = text21;
            members[21] = text22;
            members[22] = text23;
            members[23] = text24;
            members[24] = text25;
            members[25] = text26;
            members[26] = text27;
            members[27] = text28;
            members[28] = text29;
            members[29] = text30;
            members[30] = text31;
            members[31] = text32;
            members[32] = text33;
            members[33] = text34;
            members[34] = text35;
            members[35] = text36;
            members[36] = text37;
            members[37] = text38;
            members[38] = text39;
            members[39] = text40;
            members[40] = text41;
            members[41] = text42;
            members[42] = text43;
            members[43] = text44;
            members[44] = text45;
            members[45] = text46;
            members[46] = text47;
            members[47] = text48;
            members[48] = text49;
            members[49] = text50;
            members[50] = text51;
            members[51] = text52;
            members[52] = text53;
            members[53] = text54;
            members[54] = text55;
            members[55] = text56;
            members[56] = text57;
            members[57] = text58;
            members[58] = text59;
            members[59] = text60;
            members[60] = text61;
            members[61] = text62;
            members[62] = text63;
            this.members = new List<TextBox>();
            this.members.AddRange(members);
        }
        private void MakeThem0()
        {
            if (members[62].Text != null)
            {
                button4.Show();
                string[] bla = File.ReadAllLines(@"midT.txt");
                using (StreamWriter outputFile = new StreamWriter(@"midT.txt"))
                {
                    for (int i = 0; i < bla.Length; i++)
                    {
                        members[i].Text = null;
                        outputFile.WriteLine("");
                    }
                }
            }
        }
        private void Shake()
        {
            
            TextBox[] member = new TextBox[33];
            member[0] = text1;
            member[1] = text2;
            member[2] = text3;
            member[3] = text4;
            member[4] = text5;
            member[5] = text6;
            member[6] = text7;
            member[7] = text8;
            member[8] = text9;
            member[9] = text10;
            member[10] = text11;
            member[11] = text12;
            member[12] = text13;
            member[13] = text14;
            member[14] = text15;
            member[15] = text16;
            member[16] = text17;
            member[17] = text18;
            member[18] = text19;
            member[19] = text20;
            member[20] = text21;
            member[21] = text22;
            member[22] = text23;
            member[23] = text24;
            member[24] = text25;
            member[25] = text26;
            member[26] = text27;
            member[27] = text28;
            member[28] = text29;
            member[29] = text30;
            member[30] = text31;
            member[31] = text32;
            Random bn = new Random();
            for (int i = 0; i < member.Length; i++)
            {
                int swaper = bn.Next(0, 32);
                if (swaper != i)
                {
                    string a = member[i].Text;
                    member[i].Text = member[swaper].Text;
                    member[swaper].Text = a;
                }
                else
                {
                    break; ;
                }
            }
        }
        private void Save()
        {
            string[] lines = {
            members[0].Text,
            members[1].Text,
            members[2].Text,
            members[3].Text,
            members[4].Text,
            members[5].Text,
            members[6].Text,
            members[7].Text,
            members[8].Text,
            members[9].Text,
            members[10].Text,
            members[11].Text,
            members[12].Text,
            members[14].Text,
            members[15].Text,
            members[16].Text,
            members[17].Text,
            members[18].Text,
            members[19].Text,
            members[20].Text,
            members[21].Text,
            members[22].Text,
            members[23].Text,
            members[24].Text,
            members[25].Text,
            members[26].Text,
            members[27].Text,
            members[28].Text,
            members[29].Text,
            members[30].Text,
            members[31].Text,
            members[32].Text,
            members[33].Text,
            members[34].Text,
            members[35].Text,
            members[36].Text,
            members[37].Text,
            members[38].Text,
            members[39].Text,
            members[40].Text,
            members[41].Text,
            members[42].Text,
            members[43].Text,
            members[44].Text,
            members[45].Text,
            members[46].Text,
            members[47].Text,
            members[48].Text,
            members[49].Text,
            members[50].Text,
            members[51].Text,
            members[52].Text,
            members[53].Text,
            members[54].Text,
            members[55].Text,
            members[56].Text,
            members[57].Text,
            members[58].Text,
            members[59].Text,
            members[60].Text,
            members[61].Text,
            members[62].Text,
            };
            StreamWriter outputFile = new StreamWriter(@"midT.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == null)
                {
                    Console.WriteLine();
                }
                else
                {
                    outputFile.WriteLine(lines[i]);
                }
            }
            outputFile.Close();
        }
        // до 32 първи къг          до 48 2ри кръг        до 56 3ти ктъг   
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Hide();
            string[] were = new string[100];
            were = File.ReadAllLines("wereShaked.txt");
            try
            {
                if (were[0] != null)
                {
                    button1.Hide();
                }
            }
            catch (Exception)
            {
                
            }
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                string[] lines = File.ReadAllLines(@"midT.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    members[i].Text = lines[i];
                }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Shake();
                StreamWriter writer = new StreamWriter("wereShaked.txt");
                    writer.WriteLine("1");
            writer.Close();
            button1.Hide();
        }
            private void Check1_CheckedChanged(object sender, EventArgs e)
            {
                text33.Text = text1.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[0]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 0)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Text1_TextChanged(object sender, EventArgs e)
            {

            }
            private void Check2_CheckedChanged(object sender, EventArgs e)
            {
                text33.Text = text2.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[1]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 1)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check3_CheckedChanged(object sender, EventArgs e)
            {
                text34.Text = text3.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[2]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 2)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox4_CheckedChanged(object sender, EventArgs e)
            {
                text34.Text = text4.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[3]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 3)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox5_CheckedChanged(object sender, EventArgs e)
            {
                text35.Text = text5.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[4]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 4)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox6_CheckedChanged(object sender, EventArgs e)
            {
                text35.Text = text6.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[5]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 5)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox7_CheckedChanged(object sender, EventArgs e)
            {
                text36.Text = text7.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[6]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 6)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox8_CheckedChanged(object sender, EventArgs e)
            {
                text36.Text = text8.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[7]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 7)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox9_CheckedChanged(object sender, EventArgs e)
            {
                text37.Text = text9.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[8]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 8)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox10_CheckedChanged(object sender, EventArgs e)
            {
                text37.Text = text10.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[9]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 9)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox11_CheckedChanged(object sender, EventArgs e)
            {
                text38.Text = text11.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[10]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 10)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox12_CheckedChanged(object sender, EventArgs e)
            {
                text38.Text = text12.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[11]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 11)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox13_CheckedChanged(object sender, EventArgs e)
            {
                text39.Text = text13.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[12]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 12)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox14_CheckedChanged(object sender, EventArgs e)
            {
                text39.Text = text14.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[13]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 13)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox15_CheckedChanged(object sender, EventArgs e)
            {
                text40.Text = text15.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[14]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 14)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox16_CheckedChanged(object sender, EventArgs e)
            {
                text40.Text = text16.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[15]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 15)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox17_CheckedChanged(object sender, EventArgs e)
            {
                text41.Text = text17.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[16]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 16)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void CheckBox18_CheckedChanged(object sender, EventArgs e)
            {
                text41.Text = text18.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[17]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 17)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check19_CheckedChanged(object sender, EventArgs e)
            {
                text42.Text = text19.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[18]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 18)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check20_CheckedChanged(object sender, EventArgs e)
            {
                text42.Text = text20.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[19]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 19)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check21_CheckedChanged(object sender, EventArgs e)
            {
                text43.Text = text21.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[20]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 20)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check22_CheckedChanged(object sender, EventArgs e)
            {
                text43.Text = text22.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[21]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 21)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check23_CheckedChanged(object sender, EventArgs e)
            {
                text44.Text = text23.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[22]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 22)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check24_CheckedChanged(object sender, EventArgs e)
            {
                text44.Text = text24.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[23]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 23)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check25_CheckedChanged(object sender, EventArgs e)
            {
                text45.Text = text25.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[24]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 24)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check26_CheckedChanged(object sender, EventArgs e)
            {
                text45.Text = text26.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[25]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 25)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check27_CheckedChanged(object sender, EventArgs e)
            {
                text46.Text = text27.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[26]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 26)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check28_CheckedChanged(object sender, EventArgs e)
            {
                text46.Text = text28.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[27]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 27)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check29_CheckedChanged(object sender, EventArgs e)
            {
                text47.Text = text29.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[28]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 28)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check30_CheckedChanged(object sender, EventArgs e)
            {
                text47.Text = text30.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[29]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 29)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check31_CheckedChanged(object sender, EventArgs e)
            {
                text48.Text = text31.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[30]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 30)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check32_CheckedChanged(object sender, EventArgs e)
            {
                text48.Text = text32.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    int a = int.Parse(lines[31]);
                    a += 10;
                    for (int i = 0; i <= 31; i++)
                    {
                        if (i == 31)
                        {
                            outputFile.WriteLine(a);
                        }
                        else
                        {
                            outputFile.WriteLine(lines[i]);
                        }

                    }
                }
            }
            private void Check33_CheckedChanged(object sender, EventArgs e)
            {
                text49.Text = text33.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check1.Checked)
                    {
                        int a = int.Parse(lines[0]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 0)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[1]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 1)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check34_CheckedChanged(object sender, EventArgs e)
            {
                text49.Text = text34.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check3.Checked)
                    {
                        int a = int.Parse(lines[2]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 2)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[3]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 3)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check35_CheckedChanged(object sender, EventArgs e)
            {
                text50.Text = text35.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox5.Checked)
                    {
                        int a = int.Parse(lines[4]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 4)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[5]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 5)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check36_CheckedChanged(object sender, EventArgs e)
            {
                text50.Text = text36.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox7.Checked)
                    {
                        int a = int.Parse(lines[6]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 6)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[7]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 7)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check37_CheckedChanged(object sender, EventArgs e)
            {
                text51.Text = text37.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox9.Checked)
                    {
                        int a = int.Parse(lines[8]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 8)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[9]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 9)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check38_CheckedChanged(object sender, EventArgs e)
            {
                text51.Text = text38.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox11.Checked)
                    {
                        int a = int.Parse(lines[10]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 10)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[11]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 11)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check39_CheckedChanged(object sender, EventArgs e)
            {
                text52.Text = text39.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox13.Checked)
                    {
                        int a = int.Parse(lines[12]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 12)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[13]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 13)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check40_CheckedChanged(object sender, EventArgs e)
            {
                text52.Text = text40.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox15.Checked)
                    {
                        int a = int.Parse(lines[14]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 14)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[15]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 15)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check41_CheckedChanged(object sender, EventArgs e)
            {
                text53.Text = text41.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (checkBox17.Checked)
                    {
                        int a = int.Parse(lines[16]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 16)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[17]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 17)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check42_CheckedChanged(object sender, EventArgs e)
            {
                text53.Text = text42.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check19.Checked)
                    {
                        int a = int.Parse(lines[18]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 18)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[19]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 19)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check43_CheckedChanged(object sender, EventArgs e)
            {
                text54.Text = text43.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check21.Checked)
                    {
                        int a = int.Parse(lines[20]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 20)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[21]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 21)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check44_CheckedChanged(object sender, EventArgs e)
            {
                text54.Text = text44.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check23.Checked)
                    {
                        int a = int.Parse(lines[22]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 22)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[23]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 23)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check45_CheckedChanged(object sender, EventArgs e)
            {
                text55.Text = text45.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check25.Checked)
                    {
                        int a = int.Parse(lines[24]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 24)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[25]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 25)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check46_CheckedChanged(object sender, EventArgs e)
            {
                text55.Text = text46.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check27.Checked)
                    {
                        int a = int.Parse(lines[26]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 26)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[27]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 27)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check47_CheckedChanged(object sender, EventArgs e)
            {
                text56.Text = text47.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check29.Checked)
                    {
                        int a = int.Parse(lines[28]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 28)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[29]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 29)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            private void Check48_CheckedChanged(object sender, EventArgs e)
            {
                text56.Text = text48.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check31.Checked)
                    {
                        int a = int.Parse(lines[30]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 30)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                    else
                    {
                        int a = int.Parse(lines[31]);
                        a += 10;
                        for (int i = 0; i <= 31; i++)
                        {
                            if (i == 31)
                            {
                                outputFile.WriteLine(a);
                            }
                            else
                            {
                                outputFile.WriteLine(lines[i]);
                            }

                        }
                    }
                }
            }
            //1/8final
            private void Check49_CheckedChanged(object sender, EventArgs e)
            {
                text57.Text = text49.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check33.Checked)
                    {
                        if (check1.Checked)
                        {
                            int a = int.Parse(lines[0]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 0)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[1]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 1)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (check3.Checked)
                        {
                            int a = int.Parse(lines[2]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 2)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[3]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 3)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }

                }
            }
            private void Check50_CheckedChanged(object sender, EventArgs e)
            {
                text57.Text = text50.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check35.Checked)
                    {
                        if (checkBox5.Checked)
                        {
                            int a = int.Parse(lines[4]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 4)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[5]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 5)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (checkBox7.Checked)
                        {
                            int a = int.Parse(lines[6]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 6)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[7]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 7)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }
            }
            private void Check51_CheckedChanged(object sender, EventArgs e)
            {
                text58.Text = text51.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check37.Checked)
                    {
                        if (checkBox9.Checked)
                        {
                            int a = int.Parse(lines[8]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 8)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[9]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 9)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (checkBox11.Checked)
                        {
                            int a = int.Parse(lines[10]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 10)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[11]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 11)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }

            }
            private void Check52_CheckedChanged(object sender, EventArgs e)
            {
                text58.Text = text52.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check39.Checked)
                    {
                        if (checkBox13.Checked)
                        {
                            int a = int.Parse(lines[12]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 12)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[13]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 13)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (checkBox15.Checked)
                        {
                            int a = int.Parse(lines[14]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 14)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[15]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 15)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }
            }
            private void Check53_CheckedChanged(object sender, EventArgs e)
            {
                text59.Text = text53.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check41.Checked)
                    {
                        if (checkBox17.Checked)
                        {
                            int a = int.Parse(lines[16]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 16)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[17]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 17)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (check19.Checked)
                        {
                            int a = int.Parse(lines[18]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 18)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[19]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 19)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }
            }
            private void Check54_CheckedChanged(object sender, EventArgs e)
            {
                text59.Text = text54.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check43.Checked)
                    {
                        if (check21.Checked)
                        {
                            int a = int.Parse(lines[20]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 20)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[21]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 21)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (check23.Checked)
                        {
                            int a = int.Parse(lines[22]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 22)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[23]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 23)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }
            }
            private void Check55_CheckedChanged(object sender, EventArgs e)
            {
                text60.Text = text55.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check45.Checked)
                    {
                        if (check25.Checked)
                        {
                            int a = int.Parse(lines[24]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 24)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[25]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 25)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (check27.Checked)
                        {
                            int a = int.Parse(lines[26]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 26)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[27]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 27)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }
            }
            private void Check56_CheckedChanged(object sender, EventArgs e)
            {
                text60.Text = text56.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check47.Checked)
                    {
                        if (check29.Checked)
                        {
                            int a = int.Parse(lines[28]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 28)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[29]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 29)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (check31.Checked)
                        {
                            int a = int.Parse(lines[30]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 30)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                        else
                        {
                            int a = int.Parse(lines[31]);
                            a += 10;
                            for (int i = 0; i <= 31; i++)
                            {
                                if (i == 31)
                                {
                                    outputFile.WriteLine(a);
                                }
                                else
                                {
                                    outputFile.WriteLine(lines[i]);
                                }

                            }
                        }
                    }
                }
            }
            //1/2 final
            private void Check57_CheckedChanged(object sender, EventArgs e)
            {
                text61.Text = text57.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check49.Checked)
                    {
                        if (check33.Checked)
                        {
                            if (check1.Checked)
                            {
                                int a = int.Parse(lines[0]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 0)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[1]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 1)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (check3.Checked)
                            {
                                int a = int.Parse(lines[2]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 2)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[3]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 3)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        if (check35.Checked)
                        {
                            if (checkBox5.Checked)
                            {
                                int a = int.Parse(lines[4]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 4)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[5]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 5)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (checkBox7.Checked)
                            {
                                int a = int.Parse(lines[6]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 6)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[7]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 7)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            private void Check58_CheckedChanged(object sender, EventArgs e)
            {
                text61.Text = text58.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check51.Checked)
                    {
                        if (check37.Checked)
                        {
                            if (checkBox9.Checked)
                            {
                                int a = int.Parse(lines[8]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 8)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[9]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 9)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (checkBox11.Checked)
                            {
                                int a = int.Parse(lines[10]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 10)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[11]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 11)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        if (check39.Checked)
                        {
                            if (checkBox13.Checked)
                            {
                                int a = int.Parse(lines[12]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 12)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[13]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 13)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (checkBox15.Checked)
                            {
                                int a = int.Parse(lines[14]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 14)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[15]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 15)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }

                }
            }
            private void Check59_CheckedChanged(object sender, EventArgs e)
            {
                text62.Text = text59.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check53.Checked)
                    {
                        if (check41.Checked)
                        {
                            if (checkBox17.Checked)
                            {
                                int a = int.Parse(lines[16]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 16)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[17]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 17)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (check19.Checked)
                            {
                                int a = int.Parse(lines[18]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 18)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[19]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 19)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        if (check43.Checked)
                        {
                            if (check21.Checked)
                            {
                                int a = int.Parse(lines[20]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 20)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[21]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 21)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (check23.Checked)
                            {
                                int a = int.Parse(lines[22]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 22)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[23]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 23)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }

                    }

                }
            }
            private void Check60_CheckedChanged(object sender, EventArgs e)
            {
                text62.Text = text60.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check55.Checked)
                    {
                        if (check45.Checked)
                        {
                            if (check25.Checked)
                            {
                                int a = int.Parse(lines[24]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 24)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[25]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 25)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (check27.Checked)
                            {
                                int a = int.Parse(lines[26]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 26)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[27]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 27)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        if (check47.Checked)
                        {
                            if (check29.Checked)
                            {
                                int a = int.Parse(lines[28]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 28)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[29]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 29)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                        else
                        {
                            if (check31.Checked)
                            {
                                int a = int.Parse(lines[30]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 30)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                            else
                            {
                                int a = int.Parse(lines[31]);
                                a += 10;
                                for (int i = 0; i <= 31; i++)
                                {
                                    if (i == 31)
                                    {
                                        outputFile.WriteLine(a);
                                    }
                                    else
                                    {
                                        outputFile.WriteLine(lines[i]);
                                    }

                                }
                            }
                        }
                    }

                }
            }
            //final
            private void Check61_CheckedChanged(object sender, EventArgs e)
            {
                text63.Text = text61.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check57.Checked)
                    {
                        if (check49.Checked)
                        {
                            if (check33.Checked)
                            {
                                if (check1.Checked)
                                {
                                    int a = int.Parse(lines[0]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 0)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[1]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 1)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (check3.Checked)
                                {
                                    int a = int.Parse(lines[2]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 2)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[3]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 3)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            if (check35.Checked)
                            {
                                if (checkBox5.Checked)
                                {
                                    int a = int.Parse(lines[4]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 4)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[5]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 5)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (checkBox7.Checked)
                                {
                                    int a = int.Parse(lines[6]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 6)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[7]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 7)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (check51.Checked)
                        {
                            if (check37.Checked)
                            {
                                if (checkBox9.Checked)
                                {
                                    int a = int.Parse(lines[8]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 8)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[9]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 9)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (checkBox11.Checked)
                                {
                                    int a = int.Parse(lines[10]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 10)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[11]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 11)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            if (check39.Checked)
                            {
                                if (checkBox13.Checked)
                                {
                                    int a = int.Parse(lines[12]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 12)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[13]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 13)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (checkBox15.Checked)
                                {
                                    int a = int.Parse(lines[14]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 14)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[15]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 15)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
            }
            private void Check62_CheckedChanged(object sender, EventArgs e)
            {
                text63.Text = text62.Text;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                string[] lines = File.ReadAllLines(@"ranklist.txt");
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @"ranklist.txt")))
                {
                    if (check59.Checked)
                    {
                        if (check53.Checked)
                        {
                            if (check41.Checked)
                            {
                                if (checkBox17.Checked)
                                {
                                    int a = int.Parse(lines[16]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 16)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[17]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 17)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (check19.Checked)
                                {
                                    int a = int.Parse(lines[18]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 18)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[19]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 19)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            if (check43.Checked)
                            {
                                if (check21.Checked)
                                {
                                    int a = int.Parse(lines[20]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 20)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[21]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 21)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (check23.Checked)
                                {
                                    int a = int.Parse(lines[22]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 22)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[23]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 23)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }

                        }

                    }
                    else
                    {
                        if (check55.Checked)
                        {
                            if (check45.Checked)
                            {
                                if (check25.Checked)
                                {
                                    int a = int.Parse(lines[24]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 24)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[25]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 25)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (check27.Checked)
                                {
                                    int a = int.Parse(lines[26]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 26)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[27]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 27)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            if (check47.Checked)
                            {
                                if (check29.Checked)
                                {
                                    int a = int.Parse(lines[28]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 28)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[29]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 29)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                if (check31.Checked)
                                {
                                    int a = int.Parse(lines[30]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 30)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                                else
                                {
                                    int a = int.Parse(lines[31]);
                                    a += 10;
                                    for (int i = 0; i <= 31; i++)
                                    {
                                        if (i == 31)
                                        {
                                            outputFile.WriteLine(a);
                                        }
                                        else
                                        {
                                            outputFile.WriteLine(lines[i]);
                                        }

                                    }
                                }
                            }
                        }

                    }
                }
            }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Save();   
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Save();
            Process.Start(@"naskoMENU.exe");
            Application.Exit();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            File.Delete("wereShaked.txt");
            File.Create("wereShaked.txt");
            this.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
