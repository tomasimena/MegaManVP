using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaMan
{
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
            //this.Controls.Add(pictureBox2);
            //pictureBox2.BackColor = Color.Transparent;
            //pictureBox2.BringToFront();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            var pos = this.PointToScreen(lblName.Location);
            pos = pictureBox1.PointToClient(pos);
            lblName.Parent = pictureBox1;
            lblName.Location = pos;
            lblName.BackColor = Color.Transparent;
            lblName.Location = new Point(this.Width / 2 - lblName.Width / 2, this.Height/6-lblName.Height/2);
            btnMultiPlayer.Location = new Point(this.Width / 2 - btnMultiPlayer.Width / 2, (int)(this.Height / 1.8) - btnMultiPlayer.Height/2);
            btnExit.Location = new Point(this.Width / 2 - btnExit.Width / 2, (int)(this.Height / 1.4) - btnExit.Height/2);
            btnHelp.Location = new Point((int)(this.Width - btnHelp.Width * 2), this.Height - btnHelp.Height * 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TwoPlayers sp = new TwoPlayers(this); 
            sp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help hp = new Help();
            hp.ShowDialog();
        }

    }
}
