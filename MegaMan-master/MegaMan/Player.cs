using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan
{
    public class Player : Warrior
    {
        public Player(float Angle, String ImagePath, String Name, int X, int Y)
        {
            this.Angle = Angle;
            this.ImagePath = ImagePath;
            this.Name = Name;

            this.position = new Point(X, Y);
            img = new Bitmap(ImagePath);
            this.warriorWidth = 65;
            this.warriorHeight = 50;
            this.warriorSpeed = 5;
            this.Health = 100;
        }

        public override void Draw(Graphics g)
        {
            int X = position.X;
            int Y = position.Y;

            // X i Y se samo za crtanje, za sporedba treba da se presmetaat pak kako rotated i isto za sudir
            float tempX = X - (X + warriorWidth / 2);
            float tempY = Y - (Y + warriorHeight / 2);
            float rotatedXLeftTrunk = tempX * (float)(Math.Cos(Angle * Math.PI / 180)) - tempY * (float)(Math.Sin(Angle * Math.PI / 180)) + (X + warriorWidth / 2);
            float rotatedYLeftTrunk = tempX * (float)(Math.Sin(Angle * Math.PI / 180)) + tempY * (float)(Math.Cos(Angle * Math.PI / 180)) + (Y + warriorHeight / 2);

            tempX = X - (X + warriorWidth / 2);
            tempY = Y + warriorHeight - (Y + warriorHeight / 2);
            float rotatedXRightTrunk = tempX * (float)(Math.Cos(Angle * Math.PI / 180)) - tempY * (float)(Math.Sin(Angle * Math.PI / 180)) + (X + warriorWidth / 2);
            float rotatedYRightTrunk = tempX * (float)(Math.Sin(Angle * Math.PI / 180)) + tempY * (float)(Math.Cos(Angle * Math.PI / 180)) + (Y + warriorHeight / 2);

            tempX = (X + warriorWidth) - (X + warriorWidth / 2);
            tempY = Y - (Y + warriorHeight / 2);
            float rotatedXLeftHood = tempX * (float)(Math.Cos(Angle * Math.PI / 180)) - tempY * (float)(Math.Sin(Angle * Math.PI / 180)) + (X + warriorWidth / 2);
            float rotatedYLeftHood = tempX * (float)(Math.Sin(Angle * Math.PI / 180)) + tempY * (float)(Math.Cos(Angle * Math.PI / 180)) + (Y + warriorHeight / 2);

            tempX = (X + warriorWidth) - (X + warriorWidth / 2);
            tempY = (Y + warriorHeight) - (Y + warriorHeight / 2);
            float rotatedXRightHood = tempX * (float)(Math.Cos(Angle * Math.PI / 180)) - tempY * (float)(Math.Sin(Angle * Math.PI / 180)) + (X + warriorWidth / 2);
            float rotatedYRightHood = tempX * (float)(Math.Sin(Angle * Math.PI / 180)) + tempY * (float)(Math.Cos(Angle * Math.PI / 180)) + (Y + warriorHeight / 2);

            this.position = new Point(X, Y);
            this.positionHoodLeft = new Point((int)rotatedXLeftHood, (int)rotatedYLeftHood);
            this.positionHoodRight = new Point((int)rotatedXRightHood, (int)rotatedYRightHood);
            this.positionTrunkLeft = new Point((int)rotatedXLeftTrunk, (int)rotatedYLeftTrunk);
            this.positionTrunkRight = new Point((int)rotatedXRightTrunk, (int)rotatedYRightTrunk);

            Matrix myMatrix = new Matrix();
            myMatrix.RotateAt(Angle, new Point(position.X + warriorWidth / 2, position.Y + warriorHeight / 2));
            g.Transform = myMatrix;

            g.DrawImage(img, new Rectangle(position.X, position.Y, this.warriorWidth, this.warriorHeight));
            if (this.isProtected)
            {
                g.DrawRectangle(new Pen(Color.Blue), new Rectangle(position.X, position.Y, this.warriorWidth, this.warriorHeight));
            }

        }

    }
}
