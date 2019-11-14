using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RangeList
{
    public partial class RangeListForm : Form
    {
        Size StandartSize ;
        public RangeListForm()
        {
            InitializeComponent();
            StandartSize = new Size(Width, Height);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RangeListForm_Load(object sender, EventArgs e)
        {
            var newSize = new Size(Width, Height);
            var widthUp = (newSize.Width+0.0) / StandartSize.Width;
            var heightUp = (newSize.Height + 0.0) / StandartSize.Height;

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
            }  
        }

        private void RangeListForm_Resize(object sender, EventArgs e)
        {
           

        }
    }
}
