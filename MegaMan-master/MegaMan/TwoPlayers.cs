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
    public partial class TwoPlayers : Form
    {
        public String PalyerOne;
        public String PlayerTwo;
        public Form f { set; get; }
        public TwoPlayers( Form f)
        {
            InitializeComponent();
            this.f = f;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            var pos = this.PointToScreen(lblPlayerName.Location);
            pos = pictureBox1.PointToClient(pos);
            lblPlayerName.Parent = pictureBox1;
            lblPlayerName.Location = pos;
            lblPlayerName.BackColor = Color.Transparent;
            var pos1 = this.PointToScreen(lblPlayer1.Location);
            pos1 = pictureBox1.PointToClient(pos1);
            lblPlayer1.Parent = pictureBox1;
            lblPlayer1.Location = pos1;
            lblPlayer1.BackColor = Color.Transparent;
            var pos2 = this.PointToScreen(lblPlayer2.Location);
            pos2 = pictureBox1.PointToClient(pos2);
            lblPlayer2.Parent = pictureBox1;
            lblPlayer2.Location = pos2;
            lblPlayer2.BackColor = Color.Transparent;
            lblPlayerName.Location = new Point(this.Width / 2 - lblPlayerName.Width/2, this.Height / 10);
            lblPlayer1.Location = new Point(this.Width / 2 - 2*lblPlayer1.Width - 5, this.Height*2 / 10);
            lblPlayer2.Location = new Point(this.Width / 2 - 2 * lblPlayer1.Width - 5, this.Height * 3 / 10);
            txtPlayer1.Location = new Point(this.Width / 2, this.Height * 2 / 10);
            txtPlayer2.Location = new Point(this.Width / 2 , this.Height * 3 / 10);

            btnBack.Location = new Point(this.Width / 2 - btnBack.Width - 10, this.Height * 4 / 10);
            button1.Location = new Point(this.Width / 2 + 10, this.Height * 4 / 10);
        }

        private void TwoPlayers_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TwoPlayerGame twG = new TwoPlayerGame(txtPlayer1.Text,txtPlayer2.Text);
            twG.ShowDialog();
            this.Hide();
        }
    }
}
