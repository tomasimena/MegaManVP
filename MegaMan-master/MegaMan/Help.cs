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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            var pos = this.PointToScreen(lblHelp.Location);
            pos = pictureBox1.PointToClient(pos);
            lblHelp.Parent = pictureBox1;
            lblHelp.Location = pos;
            lblHelp.BackColor = Color.Transparent;
            var pos1 = this.PointToScreen(lblPlayer1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            lblPlayer1.Parent = pictureBox1;
            lblPlayer1.Location = pos;
            lblPlayer1.BackColor = Color.Transparent;
            var pos2 = this.PointToScreen(lblPlayer2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lblPlayer2.Parent = pictureBox1;
            lblPlayer2.Location = pos;
            lblPlayer2.BackColor = Color.Transparent;
            var pos3 = this.PointToScreen(lblOptions1.Location);
            pos3 = pictureBox1.PointToClient(pos3);
            lblOptions1.Parent = pictureBox1;
            lblOptions1.Location = pos;
            lblOptions1.BackColor = Color.Transparent;
            var pos4 = this.PointToScreen(lblOptions2.Location);
            pos4 = pictureBox1.PointToClient(pos4);
            lblOptions2.Parent = pictureBox1;
            lblOptions2.Location = pos;
            lblOptions2.BackColor = Color.Transparent;
            //var pos5 = this.PointToScreen(lblDescription.Location);
            lblHelp.Location = new Point(this.Width / 2 - lblHelp.Width / 2, (int)(this.Height /7.4) - lblHelp.Height / 2);
            lblPlayer1.Location=new Point(this.Width / 4 - lblPlayer1.Width/2, (int)(this.Height / 4) -lblPlayer1.Height / 2);
            lblPlayer2.Location = new Point((int)(this.Width / 1.4) - lblPlayer2.Width / 2, this.Height / 4 - lblPlayer2.Height / 2);
            lblOptions1.Location = new Point((int)(this.Width / 3.9) - lblOptions1.Width / 2, (int)(this.Height / 1.8) - lblOptions1.Height / 2);
            lblOptions2.Location = new Point((int)(this.Width / 1.34) - lblOptions2.Width / 2, (int)(this.Height / 1.8) - lblOptions2.Height / 2);
            btnBack.Location=new Point((int)(this.Width - btnBack.Width*1.7), this.Height - btnBack.Height*2);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }


    }
}
