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

            for (int i = 0; i < 16; i++)
            {
                Controls.OfType<CheckBox>().ElementAt(i).Checked = true;
            }
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
                        item.Tag = (int.Parse(item.Name.Trim("textBox".ToArray())) /2)-1;
                        delelteButton.Tag = (int)item.Tag ;
                        delelteButton.Click += DeletePlayerButton_Click;
                      
                    }
                    else
                    {
                        var f = ((int.Parse(item.Name.Trim("textBox".ToArray())) + 1) / 2)-1;
                        item.Tag = f;
                        item.LostFocus += NameChange;

                    }

                }

                if (item is CheckBox)
                {
                    item.Tag = int.Parse(item.Name.Remove(0, 8))-1;
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

           
            
            var c = Controls.OfType<Control>().Where(x => x.Tag!=null && (int)x.Tag == (int)obj.Tag ).ToList();
            var toReplace = Controls.OfType<Control>().
                Where(x => x.Location.X >= 457 * Width / StandartSize.Width && x.Location.X <= obj.Location.X && x.Location.Y>obj.Location.Y+obj.Height)
                .OrderBy(x=>x.Location.Y).ToList();
            Point[] previous = new Point[4] { c[0].Location, c[1].Location, c[2].Location, c[3].Location };

         
            for (int i = 0; i < toReplace.Count; i++)
            {
                var item = toReplace[i];
                if(item is CheckBox)
                {
                    var temp = previous[0];
                    previous[0] = item.Location;

                    item.Location =new Point(item.Location.X, temp.Y);

                }
                else if(item is TextBox box)
                {
                    Point temp;
                    if (int.TryParse(box.Text, out int t))
                    {
                        temp = previous[1];
                        previous[1] = item.Location;
                    }
                    else
                    {
                        temp = previous[2];

                        previous[2] = item.Location;
                    }
                    item.Location = new Point(item.Location.X, temp.Y);
                    
                }
                else if(item is Button)
                {
                    var temp = previous[3];
                    previous[3] = item.Location;

                    item.Location = new Point(item.Location.X, temp.Y);

                }
            }

            for (int i=0;i<c.Count;i++)
            {
                Controls.Remove(c[i]);
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
            var c = Controls.OfType<CheckBox>().Where(x =>x.Checked).Select(x=> (int)x.Tag).ToList();
            List<Player> pl = new List<Player>(16);
            if (c.Count != 16)
            {
                MessageBox.Show("Players must be 16");
                return;
            }
            for (int i = 0; i < 16; i++)
            {
                pl.Add(new Player("FF"));
            }

            Tournament tour = new Tournament(pl);
            SchemeTournament.SchemeForm scheme = new SchemeTournament.SchemeForm(tour);
            scheme.Closing += (s, a) => { this.Show(); this.ShowInTaskbar = true; };
            this.Hide();
            ShowInTaskbar = false;
            scheme.Show();
          
            
        }

        private void FillRandomNames()
        {
            Random random = new Random();
           List<string> names = new List<string>() { "Kontantin", "Ventsi", "Avraam", "Gosho", "Pesho", "Niki", "Gabi", "Kati", "Maq",
               "Zia", "Valq", "Vicroriq", "Desi", "Aleksei", "Stefan", "Marin", "Jaff",
           "Iliqn","Maxim","Jeffrey Richter","Olga","Adolf","Daniil","Fedq","Armen","Orkide","Raq","Zuska","Georg",
           "Denitsa","Sandera","Elif","Virdjiniq","John","Bill","Naruto"};
            var c = Controls.OfType<TextBox>().Where(x =>x.Enabled).Reverse();
            foreach (var item in c)
            {
                var name = names[random.Next(0, names.Count)];
                item.Text = name;
                Players.Add(new Player(name));
            }

        }
    }
}
