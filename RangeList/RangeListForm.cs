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
        Point RightColumnFirstPos;

        public RangeListForm()
        {
            this.Icon = Resourcses.Icon1;
            KeyPreview = true;

            InitializeComponent();
            
            StandartSize = new Size(Width, Height);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += RangeListForm_Load;
        }

        private void GenerateNewBoxes(int i)
        {
            var textBox1 = LinkedItems(25).Item2;
            var textBox2 = LinkedItems(25).Item3;
            var checkBox1 = LinkedItems(25).Item1;
            for (; i < Players.Count; i++)
            {
                int yForControls = NewPlayerButton.Location.Y;
               
                var checkBox = new CheckBox()
                {
                    Size = checkBox1.Size,
                    Location = new Point(checkBox1.Location.X, yForControls),
                    Tag = i
                };
                var nameBox = new TextBox() { Size = textBox1.Size, Location = new Point(textBox1.Location.X, yForControls), Tag = i };
                var pointsBox = new TextBox() { Size = textBox2.Size, Location = new Point(textBox2.Location.X, yForControls), Tag = i, Enabled = false };
                var deletebut = new Button() { Tag = i };
                nameBox.Text = Players[i].Name;
                pointsBox.Text = Players[i].WinsGames.ToString();
                Bitmap deleteImage = new Bitmap(20, 20);
                {

                    Graphics flagGraphics = Graphics.FromImage(deleteImage);


                    var color = Color.Red;
                    flagGraphics.DrawLine(new Pen(color), 0, 0, 20, 20);
                    flagGraphics.DrawLine(new Pen(color), 0, 20, 20, 0);


                }
                ToolTip toolTip = new ToolTip();



                toolTip.SetToolTip(deletebut, "Delete player");

                deletebut.Location = new Point(pointsBox.Location.X + pointsBox.Width + 30, pointsBox.Location.Y);
                deletebut.Size = new Size(20, 20);
                deletebut.Image = deleteImage;
                deletebut.Click += DeletePlayerButton_Click;


                nameBox.LostFocus += NameChange;

                Controls.Add(nameBox);
                Controls.Add(deletebut);
                Controls.Add(pointsBox);
                Controls.Add(checkBox);

                
                NewPlayerButton.Location = new Point(NewPlayerButton.Location.X,
                    LinkedItems(i-25).Item2.Location.Y);

            }
            NewPlayerButton.Location = new Point(NewPlayerButton.Location.X,
                   LinkedItems(i - 25).Item2.Location.Y);

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

            RightColumnFirstPos = checkBox26.Location;

            if (File.Exists(Directory.GetCurrentDirectory()+"\\peoples.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\peoples.dat", FileMode.Open, FileAccess.ReadWrite))
                {
                   Players= formatter.Deserialize(fs) as List<Player>;
                    var max = Players.Select(x => x.ID).Max();
                    for (int i = 0; i <max+1; i++)
                    {
                        new Player("GG");
                    }
                    var temp = new Player("GG");
                }
                if (Players.Count >= 32)
                    GenerateNewBoxes(32);
                else
                {
                    var temp = LinkedItems(Players.Count);
                    NewPlayerButton.Location=LinkedItems(Players.Count).Item2.Location;
                    for (int i = Players.Count; i < 32; i++)
                    {
                        var t = LinkedItems(i);
                        Controls.Remove(t.Item1);
                        Controls.Remove(t.Item2);
                        Controls.Remove(t.Item3);
                        Controls.Remove(t.Item4);
                    }
                }
                for (int i = 0; i < Players.Count; i++)
                {
                    var item = Players[i];
                    var r = LinkedItems(i);
                    r.Item2.Text = item.Name;
                    r.Item3.Text = item.WinsGames.ToString();
                }            
            }
            else
            {

                FillRandomNames();
            }

        }

        private void NameChange(object sender,EventArgs e)
        {
            var name = sender as TextBox;
            Players[(int)name.Tag] = new Player(name.Text);
            LinkedItems((int)name.Tag).Item3.Text = "0";
         
        }

        private void DeletePlayerButton_Click(object sender,EventArgs e)
        {
            if(Players.Count==16)
            {
                MessageBox.Show("Minimum players are 16");
                return;
            }

            var obj = sender as Control;

           
            
            var c = Controls.OfType<Control>().Where(x => x.Tag!=null && (int)x.Tag == (int)obj.Tag ).ToList();
            var toReplace = Controls.OfType<Control>()
                .Where(x => x.Location.X > obj.Location.X+1 || (x.Location.Y>obj.Location.Y+obj.Height && x.Location.X>=LinkedItems((int)obj.Tag).Item1.Location.X))
                .OrderBy(x=>x.Location.X)
                .ThenBy(x=>x.Location.Y)
                .Where(x=>x is Label ==false).ToList();
            toReplace.Remove(NewTournamentButton);
            toReplace.Remove(NewPlayerButton);
            c[0] = LinkedItems((int)obj.Tag).Item1;
            c[1] = LinkedItems((int)obj.Tag).Item3;
            c[2] = LinkedItems((int)obj.Tag).Item2;
            c[3] = LinkedItems((int)obj.Tag).Item4;

            Point[] previous = new Point[4] { c[0].Location, c[1].Location, c[2].Location, c[3].Location };

            Players.RemoveAt((int)obj.Tag);


            for (int i = 0; i < toReplace.Count; i++)
            {
                var item = toReplace[i];             
                if(item is CheckBox)
                {
                    var temp = previous[0];
                    previous[0] = item.Location;

                    item.Location =temp;

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
                    item.Location = temp;
                    
                }
                else if(item is Button)
                {
                    var temp = previous[3];
                    previous[3] = item.Location;

                    item.Location = temp;

                }
                else
                {
                    throw new Exception();
                }
                if(item.Tag!=null)
                item.Tag = (int)item.Tag - 1;
                
            }

           


            for (int i=0;i<c.Count;i++)
            {
                Controls.Remove(c[i]);
            }
            NewPlayerButton.Location = previous[2];

            

        }

        private void RangeListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\peoples.dat", FileMode.Create,FileAccess.ReadWrite))
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
                pl.Add(Players[c[i]]);
            }
          


            Tournament tour = new Tournament(pl);
            
          
           
            ShowInTaskbar = false;
            
           var scheme = new SchemeTournament.SchemeForm(tour);
            scheme.Closing += (s, a) => {

                this.Show(); this.ShowInTaskbar = true;
                for (int i = 0; i < Players.Count; i++)
                {
                    LinkedItems(i).Item3.Text = Players[i].WinsGames.ToString();
                }
                Sort();
                WindowState = FormWindowState.Maximized;
            };
            this.Hide();
            scheme.Show();


        }
       

        private void FillRandomNames()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
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

        /// <summary>
        /// Get four controls responding for player
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>IsPlaying,Name,Points,DeleteButton</returns>
        private (CheckBox,TextBox,TextBox,Button) LinkedItems(int tag)
        {
            
            var c = Controls.OfType<Control>().Where(x => x.Tag != null && (int)x.Tag == tag)
                .ToList();
            if (c.Count != 4)
                throw new Exception();
            var check = c.OfType<CheckBox>().First();
            var name = c.OfType<TextBox>().Where(x => x.Enabled).First();
            var points = c.OfType<TextBox>().Where(x => !x.Enabled).First();
            var but = c.OfType<Button>().First();
            return (check, name, points, but);
        }

        private void RangeListForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;
            var res = MessageBox.Show("Do you want to exit app", "Exit window", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
                this.Close();
            else
                MessageBox.Show("Good choice");
        }

        private void RangeListForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != (char)Keys.Escape)
            //    return;
            //var res = MessageBox.Show("Do you want to exit app", "Exit window", MessageBoxButtons.YesNo);
            //if (res == DialogResult.Yes)
            //    this.Close();
            //else
            //    MessageBox.Show("Good choice");
        }

        private void NewPlayerButton_Click(object sender, EventArgs e)
        {
            

           if(Players.Count<25)
           {

                Players.Add(new Player("Unnamed"));
                int yForControls = NewPlayerButton.Location.Y;

                var checkBox = new CheckBox() { Size = checkBox1.Size,
                    Location = new Point(checkBox1.Location.X, yForControls),
                    Tag = Players.Count - 1 };
                var nameBox = new TextBox() { Size = textBox1.Size, Location = new Point(textBox1.Location.X, yForControls), Tag = Players.Count - 1 };
                var pointsBox = new TextBox() { Size = textBox2.Size, Location = new Point(textBox2.Location.X, yForControls), Tag = Players.Count - 1, Enabled = false };
                var deletebut = new Button() { Tag = Players.Count - 1 };
                nameBox.Text = Players[Players.Count - 1].Name;
                pointsBox.Text = "0";
                Bitmap deleteImage = new Bitmap(20, 20);
                {

                    Graphics flagGraphics = Graphics.FromImage(deleteImage);


                    var color = Color.Red;
                    flagGraphics.DrawLine(new Pen(color), 0, 0, 20, 20);
                    flagGraphics.DrawLine(new Pen(color), 0, 20, 20, 0);


                }
                ToolTip toolTip = new ToolTip();



                toolTip.SetToolTip(deletebut, "Delete player");

                deletebut.Location = new Point(pointsBox.Location.X + pointsBox.Width + 30, pointsBox.Location.Y);
                deletebut.Size = new Size(20, 20);
                deletebut.Image = deleteImage;
                deletebut.Click += DeletePlayerButton_Click;


                nameBox.LostFocus += NameChange;

                Controls.Add(nameBox);
                Controls.Add(deletebut);
                Controls.Add(pointsBox);
                Controls.Add(checkBox);

                var temp = LinkedItems(Players.Count - 2).Item2;
                NewPlayerButton.Location = new Point(NewPlayerButton.Location.X,
                    NewPlayerButton.Location.Y+ (NewPlayerButton.Location.Y - temp.Location.Y));


            }
            else if(Players.Count == 25)
            {
               
                Players.Add(new Player("Unnamed"));
                int yForControls = NewPlayerButton.Location.Y;

                var checkBox = new CheckBox() { Size = checkBox1.Size,
                    Location = RightColumnFirstPos,
                    Tag=Players.Count-1
                };

                var nameBox = new TextBox() { Size = textBox1.Size,
                    Location = new Point(checkBox.Location.X+( textBox1.Location.X-checkBox1.Location.X), checkBox.Location.Y),
                    Tag = Players.Count - 1 };

                var pointsBox = new TextBox() { Size = textBox2.Size,
                    Location = new Point(checkBox.Location.X + (textBox2.Location.X - checkBox1.Location.X), checkBox.Location.Y),
                    Tag = Players.Count - 1,
                    Enabled = false };

                var deletebut = new Button() { Tag = Players.Count - 1 };

                nameBox.Text = Players[Players.Count - 1].Name;
                pointsBox.Text = "0";
                Bitmap deleteImage = new Bitmap(20, 20);
                {

                    Graphics flagGraphics = Graphics.FromImage(deleteImage);


                    var color = Color.Red;
                    flagGraphics.DrawLine(new Pen(color), 0, 0, 20, 20);
                    flagGraphics.DrawLine(new Pen(color), 0, 20, 20, 0);


                }
                ToolTip toolTip = new ToolTip();



                toolTip.SetToolTip(deletebut, "Delete player");

                deletebut.Location = new Point(pointsBox.Location.X + pointsBox.Width + 30, pointsBox.Location.Y);
                deletebut.Size = new Size(20, 20);
                deletebut.Image = deleteImage;
                deletebut.Click += DeletePlayerButton_Click;


                nameBox.LostFocus += NameChange;

                Controls.Add(nameBox);
                Controls.Add(deletebut);
                Controls.Add(pointsBox);
                Controls.Add(checkBox);

                var temp = LinkedItems(1).Item2;
                NewPlayerButton.Location = new Point(nameBox.Location.X,
                   temp.Location.Y);


            }
           else if(Players.Count<49)
            {
                Players.Add(new Player("Unnamed"));
                int yForControls = NewPlayerButton.Location.Y;
                var textBox1 = LinkedItems(25).Item2;
                var textBox2 = LinkedItems(25).Item3;
                var checkBox1 = LinkedItems(25).Item1;
                var checkBox = new CheckBox()
                {
                    Size = checkBox1.Size,
                    Location = new Point(checkBox1.Location.X, yForControls),
                    Tag = Players.Count - 1
                };
                var nameBox = new TextBox() { Size = textBox1.Size, Location = new Point(textBox1.Location.X, yForControls), Tag = Players.Count - 1 };
                var pointsBox = new TextBox() { Size = textBox2.Size, Location = new Point(textBox2.Location.X, yForControls), Tag = Players.Count - 1, Enabled = false };
                var deletebut = new Button() { Tag = Players.Count - 1 };
                nameBox.Text = Players[Players.Count - 1].Name;
                pointsBox.Text = "0";
                Bitmap deleteImage = new Bitmap(20, 20);
                {

                    Graphics flagGraphics = Graphics.FromImage(deleteImage);


                    var color = Color.Red;
                    flagGraphics.DrawLine(new Pen(color), 0, 0, 20, 20);
                    flagGraphics.DrawLine(new Pen(color), 0, 20, 20, 0);


                }
                ToolTip toolTip = new ToolTip();



                toolTip.SetToolTip(deletebut, "Delete player");

                deletebut.Location = new Point(pointsBox.Location.X + pointsBox.Width + 30, pointsBox.Location.Y);
                deletebut.Size = new Size(20, 20);
                deletebut.Image = deleteImage;
                deletebut.Click += DeletePlayerButton_Click;


                nameBox.LostFocus += NameChange;

                Controls.Add(nameBox);
                Controls.Add(deletebut);
                Controls.Add(pointsBox);
                Controls.Add(checkBox);

                var temp = LinkedItems(Players.Count - 2).Item2;
                NewPlayerButton.Location = new Point(NewPlayerButton.Location.X,
                    NewPlayerButton.Location.Y + (NewPlayerButton.Location.Y - temp.Location.Y));
            }
           else
            {
                MessageBox.Show("Max are 49 players");
                return;
            }
        }

        private void Sort()
        {
            //For future
            return;
            var point = new List<Point[]>(Players.Count);
            var scores = new Dictionary<int,int>();
            for (int i = 0; i < Players.Count; i++)
            {
                var res = LinkedItems(i);
                point.Add( new Point[4] { res.Item1.Location, res.Item2.Location, res.Item3.Location, res.Item4.Location });
                scores.Add(i,int.Parse(res.Item3.Text));
            }
            var NScores = scores.ToList().OrderByDescending(x=>x.Value).ToList();

            for (int i = 0; i < Players.Count; i++)
            {
                var res = LinkedItems(NScores[i].Key);
                res.Item1.Location = point[i][0];
                res.Item2.Location = point[i][1];
                res.Item3.Location = point[i][2];
                res.Item4.Location = point[i][3];

            }


        }
    }
}
