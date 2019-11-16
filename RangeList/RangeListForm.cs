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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RangeList
{
    public partial class RangeListForm : Form
    {
        Size StandartSize ;
        List<Player> Players = new List<Player>(32);

        public RangeListForm()
        {
            InitializeComponent();
            StandartSize = new Size(Width, Height);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += RangeListForm_Load;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RangeListForm_Load(object sender, EventArgs e)
        {
           #region Drawing things
            var newSize = new Size(Width, Height);
            var widthUp = (newSize.Width+0.0) / StandartSize.Width;
            var heightUp = (newSize.Height + 0.0) / StandartSize.Height;
            var toAdd = new List<Control>(32);
            Bitmap deleteImage = new Bitmap(20, 20);
            {
                
                Graphics flagGraphics = Graphics.FromImage(deleteImage);
                

                var color = Color.Red;
                flagGraphics.DrawLine(new Pen(color), 0, 0, 20,20);
                flagGraphics.DrawLine(new Pen(color), 0, 20, 20, 0);


            }
            ToolTip toolTip = new ToolTip();
            
            for (int i = 0; i < this.Controls.Count; i++)
            {
                var item = Controls[i];
                item.Location = new Point(
                    Convert.ToInt32(Math.Round(item.Location.X * widthUp)),
                    Convert.ToInt32(Math.Round(item.Location.Y * heightUp))
                    );
                item.Size = new Size(
                    Convert.ToInt32(Math.Round(item.Size.Width * widthUp)),
                    Convert.ToInt32(Math.Round(item.Size.Height * heightUp))
                    );
                if (item is TextBox)
                {
                    if (int.Parse(item.Name.Trim("textBox".ToArray())) % 2 == 0)
                    {
                        ((TextBox)item).Enabled = false;
                        var delelteButton = new Button();

                        toolTip.SetToolTip(delelteButton, "Delete player");

                        delelteButton.Location = new Point(item.Location.X + item.Width + 30, item.Location.Y);
                        delelteButton.Size = new Size(20, 20);
                        delelteButton.Image = deleteImage;
                       
                        toAdd.Add(delelteButton);
                        item.Tag = int.Parse(item.Name.Trim("textBox".ToArray())) /2;
                        delelteButton.Tag = item.Tag;
                        delelteButton.Click += DeletePlayerButton_Click;
                      
                    }
                    else
                    {
                        var f = (int.Parse(item.Name.Trim("textBox".ToArray())) + 1) / 2;
                        item.Tag = f;
                        item.LostFocus += NameChange;

                    }

                }

                if (item is CheckBox)
                {
                    item.Tag = int.Parse(item.Name.Remove(0, 8));
                }
            }

            Controls.AddRange(toAdd.ToArray());
            #endregion

            if(File.Exists(Directory.GetCurrentDirectory()+"\\peoples.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("people.dat", FileMode.Open, FileAccess.ReadWrite))
                {
                   Players= formatter.Deserialize(fs) as List<Player>;
                }
            }
            else
            {

                FillRandomNames();
            }


        }

        private void NameChange(object sender,EventArgs e)
        {
           
         
        }

        private void DeletePlayerButton_Click(object sender,EventArgs e)
        {
            var obj = sender as Control;

           

            var c = Controls.OfType<Control>().Where(x => x.Tag!=null && (int)x.Tag == (int)obj.Tag);
    
            for (int i=0;i<c.Count();i++)
            {
               if( c.ElementAt(i) is TextBox box)
               {
                    if(int.TryParse(box.Text,out int g))
                    {
                        box.Text = "0";
                    }
                    else
                        box.Text = "";
               }
                else
                {

                }
            }
            
           
            

            
        }

        private void RangeListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.Create,FileAccess.ReadWrite))
            {
                formatter.Serialize(fs, Players);
            }
        }

        private void NewTournamentButton_Click(object sender, EventArgs e)
        {
            var c = Controls.OfType<CheckBox>().Where(x =>x.Checked).Select(x=> (int)x.Tag);
            var pl = new List<Player>(16);
            if (c.Count() != 16)
            {
                MessageBox.Show("Players must be 16");
                return;
            }
            for (int i = 0; i < 16; i++)
            {
                pl.Add(Players[c.ElementAt(i)]);
            }
            SchemeTournament.SchemeForm scheme = new SchemeTournament.SchemeForm(new Tournament(pl));
            scheme.Closing += (s, a) => { this.Show(); this.ShowInTaskbar = true; };
            scheme.Show();
            this.Hide();
            this.ShowInTaskbar = false;
            
        }

        private void FillRandomNames()
        {
            Random random = new Random();
           List<string> names = new List<string>() { "Kontantin", "Ventsi", "Avraam", "Gosho", "Pesho", "Niki", "Gabi", "Kati", "Maq",
               "Zia", "Valq", "Vicroriq", "Desi", "Aleksei", "Stefan", "Marin", "Jaff",
           "Iliqn","Maxim","Jeffrey Richter","Olga","Adolf","Daniil","Fedq","Armen","Orkide","Raq","Zuska","Georg",
           "Denitsa","Sandera"};
            var c = Controls.OfType<TextBox>().Where(x =>x.Enabled);
            foreach (var item in c)
            {
                item.Text = names[random.Next(0, names.Count)];
            }

        }
    }
}
