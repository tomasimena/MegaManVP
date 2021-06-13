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
    public partial class TwoPlayerGame : Form
    {
        Random rnd = new Random();
        List<Feature> features = new List<Feature>();
        int boostedTimerPlayer2;
        int timeProtectedPlayer2;
        int boostedTimerPlayer1;
        int timeProtectedPlayer1;
        int timeFornewItem;
        //BOLEAN ZA PLAYER 1 (KOMANDI STRELKI)
        public Boolean Right { get; set; }
        public Boolean Left { get; set; }
        public Boolean Up { get; set; }
        public Boolean Down { get; set; }

        //BOLEAN ZA PLAYER 2 (KOMANDI WSAD)
        public Boolean Right1 { get; set; }
        public Boolean Left1 { get; set; }
        public Boolean Up1 { get; set; }
        public Boolean Down1 { get; set; }

        public Player p1 { get; set; }
        public Player p2 { get; set; }
        
        public TwoPlayerGame(String Player1Name, String Player2Name)
        {

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            boostedTimerPlayer2 = 0;
            timeFornewItem = 0;
            timeProtectedPlayer2 = 0;
            timeProtectedPlayer1 = 0;
            boostedTimerPlayer1 = 0;
            p1 = new Player(0, @"..\..\..\ProbaFeatures\bm1.1.png", Player1Name,100, 100);
            p2 = new Player(360, @"..\..\..\ProbaFeatures\bm1.1.1.png", Player2Name,  100, 100);
            pbPlayer1.ForeColor = Color.Green;
            pbPlayer1.Style = ProgressBarStyle.Continuous;
            pbPlayer1.Value = p1.Health;
            pbPlayer2.ForeColor = Color.Green;
            pbPlayer2.Style = ProgressBarStyle.Continuous;
            pbPlayer2.Value = p1.Health;
            var pos = this.PointToScreen(lblPlayer1.Location);
            pbPlayer1.Location = new Point((int)(pbPlayer1.Width*0.95), pbPlayer1.Height);
            pbPlayer2.Location = new Point((int)(this.Width - pbPlayer2.Width*2), pbPlayer2.Height);
            lblPlayer1.Text = p1.Name;
            lblPlayer2.Text = p2.Name;
            lblPlayer1.Location = new Point((int)(lblPlayer1.Width * 0.95), pbPlayer1.Height);
            lblPlayer2.Location= new Point((int)(this.Width - lblPlayer2.Width * 3), pbPlayer2.Height);
        }

        private void TwoPlayerGame_Load(object sender, EventArgs e)
        {
            this.p1.position = new Point(100, this.Height / 2);
            this.p2.position = new Point(this.Width - 130, this.Height / 2);
            Right = false;
            Left = false;
            Up = false;
            Down = false;

            Right1 = false;
            Left1 = false;
            Up1 = false;
            Down1 = false;

            this.DoubleBuffered = true;

            timer1.Start();
            timer2.Start();
            timer3.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (p1.isHit)
            {
                p1.isHit = false;
                timer1.Interval = 15;
                boostedTimerPlayer1 = 0;
            }
            if (timer1.Interval == 15)
            {
                boostedTimerPlayer1++;
                if (boostedTimerPlayer1 == 500)
                {
                    boostedTimerPlayer1 = 0;
                    timer1.Interval = 20;
                }
            }

            //Pridvizi go player 1
            if (Left)
                p1.goLeft(this.Width, this.Height);
            if (Right)
                p1.goRight(this.Width, this.Height);
            if (Down)
                p1.goBack(this.Width, this.Height);
            if (Up)
                p1.goForward(this.Width, this.Height);

            for (int i = features.Count - 1; i >= 0; i--)
            {
                {
                    if (features[i].isHit(p1.positionHoodLeft) || features[i].isHit(p1.positionHoodRight) || features[i].isHit(p1.positionTrunkLeft) ||
                        features[i].isHit(p1.positionTrunkRight))
                    {// 1 = heart; 2 = bomb; 3 = shield
                        int type = features[i].type;
                        if (type == 1)
                        {
                            p1.heal();
                            int healthP1 = p1.Health;
                            if (healthP1 > 50)
                                pbPlayer1.ForeColor = Color.Green;
                            else if (healthP1 > 20)
                                pbPlayer1.ForeColor = Color.Yellow;
                            else
                                pbPlayer1.ForeColor = Color.Red;
                            if(healthP1!=0)
                            pbPlayer1.Value = healthP1;
                        }
                        else if (type == 2)
                        {
                            //p1.isHit = true;
                            p1.Health -= 15;
                        }
                        else
                        {
                            p1.isProtected = true;
                            timeProtectedPlayer1 = 0;
                        }
                        features.RemoveAt(i);
                    }
                }
            }


            Vector outintersection;
            bool imaHit = false;


            //p1 so preden del i p2 so preden del
            if (Vector.LineSegementsIntersect(new Vector(p1.positionHoodLeft.X, p1.positionHoodLeft.Y),
                new Vector(p1.positionHoodRight.X, p1.positionHoodRight.Y),
                new Vector(p2.positionHoodRight.X, p2.positionHoodRight.Y),
                new Vector(p2.positionHoodLeft.X, p2.positionHoodLeft.Y),
                out outintersection, p2.warriorHeight * 2))
            {
                imaHit = true;
                p1.takeDamage(Warrior.frontDamage);
                p2.takeDamage(Warrior.frontDamage);

            }

            //p2 so preden del p1 so leva strana
         

            // p2 so preden del p1 so desna strana
            else if (Vector.LineSegementsIntersect(new Vector(p1.positionHoodRight.X, p1.positionHoodRight.Y),
                new Vector(p1.positionTrunkRight.X, p1.positionTrunkRight.Y),
                new Vector(p2.positionHoodRight.X, p2.positionHoodRight.Y),
                new Vector(p2.positionHoodLeft.X, p2.positionHoodLeft.Y), out outintersection,
                p2.warriorWidth * 1.5))
            {
                p1.takeDamage(Warrior.sideDamage);
                p2.takeDamage(Warrior.frontDamage);
                imaHit = true;
            }
            // p2 so preden del p1 od pozadi
            else if (Vector.LineSegementsIntersect(new Vector(p1.positionTrunkLeft.X, p1.positionTrunkLeft.Y),
                new Vector(p1.positionTrunkRight.X, p1.positionTrunkRight.Y),
                new Vector(p2.positionHoodRight.X, p2.positionHoodRight.Y),
                new Vector(p2.positionHoodLeft.X, p2.positionHoodLeft.Y), out outintersection,
                p2.warriorHeight * 2))
            {
                p1.takeDamage(Warrior.backDamage);
                p2.takeDamage(Warrior.frontDamage);
                imaHit = true;
            }

            //p1 pozadi i p2 pozadi
            else if (Vector.LineSegementsIntersect(new Vector(p1.positionTrunkLeft.X, p1.positionTrunkLeft.Y),
                new Vector(p1.positionTrunkRight.X, p1.positionTrunkRight.Y),
                new Vector(p2.positionTrunkRight.X, p2.positionTrunkRight.Y),
                new Vector(p2.positionTrunkLeft.X, p2.positionTrunkLeft.Y),
                out outintersection, p2.warriorHeight * 2))
            {

                p1.takeDamage(Warrior.backDamage);
                p2.takeDamage(Warrior.backDamage);
                imaHit = true;
            }

            //p1 so preden del p2 so leva strana
            else if (Vector.LineSegementsIntersect(new Vector(p2.positionHoodLeft.X, p2.positionHoodLeft.Y),
                new Vector(p2.positionTrunkLeft.X, p2.positionTrunkLeft.Y),
                new Vector(p1.positionHoodRight.X, p1.positionHoodRight.Y),
                new Vector(p1.positionHoodLeft.X, p1.positionHoodLeft.Y), out outintersection, p2.warriorWidth * 1.5))
            {
                p1.takeDamage(Warrior.frontDamage);
                p2.takeDamage(Warrior.sideDamage);
                imaHit = true;
            }

            // p1 so preden del p2 so desna strana
            else if (Vector.LineSegementsIntersect(new Vector(p2.positionHoodRight.X, p2.positionHoodRight.Y),
                new Vector(p2.positionTrunkRight.X, p2.positionTrunkRight.Y),
                new Vector(p1.positionHoodRight.X, p1.positionHoodRight.Y),
                new Vector(p1.positionHoodLeft.X, p1.positionHoodLeft.Y), out outintersection, p2.warriorWidth * 1.5))
            {
                p1.takeDamage(Warrior.frontDamage);
                p2.takeDamage(Warrior.sideDamage);
                imaHit = true;
            }

            // p1 so preden del p2 od pozadi
            

            //p1 pozadi so p2 desna strana
            else if (Vector.LineSegementsIntersect(new Vector(p2.positionHoodRight.X, p2.positionHoodRight.Y),
               new Vector(p2.positionTrunkRight.X, p2.positionTrunkRight.Y),
               new Vector(p1.positionTrunkRight.X, p1.positionTrunkRight.Y),
               new Vector(p1.positionTrunkLeft.X, p1.positionTrunkLeft.Y), out outintersection, p2.warriorWidth * 1.5))
            {
                p1.takeDamage(Warrior.backDamage);
                p2.takeDamage(Warrior.sideDamage);
                imaHit = true;
            }

            //p1 pozadi so p2 leva strana
         

            //p2 pozadi so p1 desna strana
            else if (Vector.LineSegementsIntersect(new Vector(p1.positionHoodRight.X, p1.positionHoodRight.Y),
               new Vector(p1.positionTrunkRight.X, p1.positionTrunkRight.Y),
               new Vector(p2.positionTrunkRight.X, p2.positionTrunkRight.Y),
               new Vector(p2.positionTrunkLeft.X, p2.positionTrunkLeft.Y), out outintersection, p1.warriorWidth * 1.5))
            {
                p1.takeDamage(Warrior.sideDamage);
                p2.takeDamage(Warrior.backDamage);
                imaHit = true;
            }

            //p2 pozadi so p1 leva strana
            else if (Vector.LineSegementsIntersect(new Vector(p1.positionHoodLeft.X, p1.positionHoodLeft.Y),
              new Vector(p1.positionTrunkLeft.X, p1.positionTrunkLeft.Y),
              new Vector(p2.positionTrunkRight.X, p2.positionTrunkRight.Y),
              new Vector(p2.positionTrunkLeft.X, p2.positionTrunkLeft.Y), out outintersection, p1.warriorWidth * 1.5))
            {
                p1.takeDamage(Warrior.sideDamage);
                p2.takeDamage(Warrior.backDamage);
                imaHit = true;
            }

            if (imaHit == true)
            {
                p1.position = new Point(100,this.Height/2);
                p1.Angle = 0;
                p2.position = new Point(this.Width - 130, this.Height / 2);
                p2.Angle = 180;
            }
            int health = p1.Health;
            if (health > 50)
                pbPlayer1.ForeColor = Color.Green;
            else if (health > 20)
                pbPlayer1.ForeColor = Color.Yellow;
            else
                pbPlayer1.ForeColor = Color.Red;
            if(health!=0)
            pbPlayer1.Value = health;
            health = p2.Health;
            if (health > 50)
                pbPlayer2.ForeColor = Color.Green;
            else if (health > 20)
                pbPlayer2.ForeColor = Color.Yellow;
            else
                pbPlayer2.ForeColor = Color.Red;
            if(health!=0)
            pbPlayer2.Value = health;
            Invalidate(true);
        }

        private void TwoPlayerGame_KeyUp(object sender, KeyEventArgs e)
        {
            //Proverka za player 1 ( da prestane da se dvizi)
            if (e.KeyCode == Keys.Left)
            {
                Left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                Right = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                Up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                Down = false;
            }

            //Proverka za player 2 ( da prestane da se dvizi)
            if (e.KeyCode == Keys.A)
            {
                Left1 = false;
            }
            if (e.KeyCode == Keys.D)
            {
                Right1 = false;
            }
            if (e.KeyCode == Keys.W)
            {
                Up1 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                Down1 = false;
            }
        }

        private void TwoPlayerGame_KeyDown(object sender, KeyEventArgs e)
        {
            //PROVERKA ZA PLAYER 1
            if (e.KeyCode == Keys.Left)
            {
                Left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                Right = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                Up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                Down = true;
            }

            // PROVERKA ZA  PLAYER2
            if (e.KeyCode == Keys.A)
            {
                Left1 = true;
            }
            if (e.KeyCode == Keys.D)
            {
                Right1 = true;
            }
            if (e.KeyCode == Keys.W)
            {
                Up1 = true;
            }
            if (e.KeyCode == Keys.S)
            {
                Down1 = true;
            }
        }

        private void TwoPlayerGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            foreach (Feature f in features)
                f.Draw(e.Graphics);
            if (p1 != null && p2 != null)
            {
                p1.Draw(e.Graphics);
                p2.Draw(e.Graphics);
            }
        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void TwoPlayerGame_Deactivate(object sender, EventArgs e)
        {
            Right = false;
            Right1 = false;
            Left = false;
            Left1 = false;
            Up = false;
            Up1 = false;
            Down = false;
            Down1 = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

    }
}
