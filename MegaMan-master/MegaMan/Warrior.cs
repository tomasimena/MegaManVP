using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan
{
    public abstract class Warrior
    {
         public String ImagePath { get; set; }
         public Bitmap img { get; set; }
         public int Health { get; set; }
         public bool isHit { get; set; }
         public bool isProtected { get; set; }
         public abstract void Draw(Graphics g);
         public Point position { get; set; }
         public Point positionTrunkLeft { get; set; }
         public Point positionTrunkRight { get; set; }
         public Point positionHoodRight { get; set; }
         public Point positionHoodLeft { get; set; }
         public float Angle { get; set; }
         public String Name { get; set; }
         public int warriorHeight { get; set; }
         public int warriorWidth { get; set; }
         public int warriorSpeed { get; set; }
         public static int sideDamage = 7;
         public static int backDamage = 10;
         public static int frontDamage = 3;

        public Boolean isValidMove(float rotatedXRightTrunk1,float rotatedYRightTrunk1,float rotatedXLeftTrunk1,float rotatedYLeftTrunk1,float rotatedXLeftHood1,float rotatedYLeftHood1,float rotatedXRightHood1,float rotatedYRightHood1,float Width, float Height)
        {
            bool t = false;
            if ((rotatedXRightTrunk1 >= 0 && rotatedXRightTrunk1 <= Width) && (rotatedXLeftTrunk1 >= 0 && rotatedXLeftTrunk1 <= Width) && (rotatedXLeftHood1 >= 0 && rotatedXLeftHood1 <= Width) && (rotatedXRightHood1 >= 0 && rotatedXRightHood1 <= Width) &&
               (rotatedYRightTrunk1 >= 0 && rotatedYRightTrunk1 <= Height) && (rotatedYLeftTrunk1 >= 0 && rotatedYLeftTrunk1 <= Height) && (rotatedYLeftHood1 >= 0 && rotatedYLeftHood1 <= Height) && (rotatedYRightHood1 >= 0 && rotatedYRightHood1 <= Height))
                t = true;
            return t;
        }
         public void goRight(int Width, int Height)
        {
            float anglepom = Angle + 6;
            float X1 = position.X;
            float Y1 = position.Y;

            float tempX1 = X1 - (X1 + warriorWidth/2);
            float tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = X1 - (X1 + warriorWidth/2);
            tempY1 = Y1 + warriorHeight - (Y1 + warriorHeight/2);
            float rotatedXRightTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = (Y1 + warriorHeight) - (Y1 + warriorHeight/2);
            float rotatedXRightHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);
            if (isValidMove(rotatedXRightTrunk1,rotatedYRightTrunk1,rotatedXLeftTrunk1,rotatedYLeftTrunk1,rotatedXLeftHood1,rotatedYLeftHood1,rotatedXRightHood1,rotatedYRightHood1,Width,Height))
            {
                Angle += 6;
                if (Angle == 360)
                    Angle = 0;
            }
        }
         public void goLeft(int Width, int Height)
        {
            float anglepom = Angle - 6;
            float X1 = position.X;
            float Y1 = position.Y;

            float tempX1 = X1 - (X1 + warriorWidth/2);
            float tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = X1 - (X1 + warriorWidth/2);
            tempY1 = Y1 + warriorHeight - (Y1 + warriorHeight/2);
            float rotatedXRightTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = (Y1 + warriorHeight) - (Y1 + warriorHeight/2);
            float rotatedXRightHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);
            if (isValidMove(rotatedXRightTrunk1, rotatedYRightTrunk1, rotatedXLeftTrunk1, rotatedYLeftTrunk1, rotatedXLeftHood1, rotatedYLeftHood1, rotatedXRightHood1, rotatedYRightHood1, Width, Height))
            {
                Angle -= 6;
                if (Angle == -360)
                    Angle = 0;
            }
        }
         public void goForward(int Width, int Height)
        {

            float anglepom = -Angle;
            float X1 = position.X + (int)(Math.Cos(anglepom * Math.PI / 180) * warriorSpeed);
            float Y1 = position.Y - (int)(Math.Sin(anglepom * Math.PI / 180) * warriorSpeed);

            float tempX1 = X1 - (X1 + warriorWidth/2);
            float tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = X1 - (X1 + warriorWidth/2);
            tempY1 = Y1 + warriorHeight - (Y1 + warriorHeight/2);
            float rotatedXRightTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = (Y1 + warriorHeight) - (Y1 + warriorHeight/2);
            float rotatedXRightHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);
            if (isValidMove(rotatedXRightTrunk1, rotatedYRightTrunk1, rotatedXLeftTrunk1, rotatedYLeftTrunk1, rotatedXLeftHood1, rotatedYLeftHood1, rotatedXRightHood1, rotatedYRightHood1, Width, Height))
            {
                float angP = -Angle;
                int X = position.X;
                int Y = position.Y;
                X += (int)(Math.Cos(angP * Math.PI / 180) * warriorSpeed);
                Y -= (int)(Math.Sin(angP * Math.PI / 180) * warriorSpeed);
                //label1.Text +=" agol "+ angle.ToString() + " X: " + X.ToString() + " Y: " + Y.ToString();
                position = new Point(X, Y);
            }
        }
         public void goBack(int Width, int Height)
        {
            float anglepom = -Angle;
            float X1 = position.X - (int)(Math.Cos(anglepom * Math.PI / 180) * warriorSpeed);
            float Y1 = position.Y + (int)(Math.Sin(anglepom * Math.PI / 180) * warriorSpeed);

            float tempX1 = X1 - (X1 + warriorWidth/2);
            float tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = X1 - (X1 + warriorWidth/2);
            tempY1 = Y1 + warriorHeight - (Y1 + warriorHeight/2);
            float rotatedXRightTrunk1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightTrunk1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = Y1 - (Y1 + warriorHeight/2);
            float rotatedXLeftHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYLeftHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);

            tempX1 = (X1 + warriorWidth) - (X1 + warriorWidth/2);
            tempY1 = (Y1 + warriorHeight) - (Y1 + warriorHeight/2);
            float rotatedXRightHood1 = tempX1 * (float)(Math.Cos(anglepom * Math.PI / 180)) - tempY1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + (X1 + warriorWidth/2);
            float rotatedYRightHood1 = tempX1 * (float)(Math.Sin(anglepom * Math.PI / 180)) + tempY1 * (float)(Math.Cos(anglepom * Math.PI / 180)) + (Y1 + warriorHeight/2);
            if (isValidMove(rotatedXRightTrunk1, rotatedYRightTrunk1, rotatedXLeftTrunk1, rotatedYLeftTrunk1, rotatedXLeftHood1, rotatedYLeftHood1, rotatedXRightHood1, rotatedYRightHood1, Width, Height))
            {
                float angP = -Angle;
                int X = position.X;
                int Y = position.Y;
                X -= (int)(Math.Cos(angP * Math.PI / 180) * warriorSpeed);
                Y += (int)(Math.Sin(angP * Math.PI / 180) * warriorSpeed);
                position = new Point(X, Y);
            }
        }
        public void heal()
        {
            this.Health += 25;
            if(this.Health > 100)
            {
                this.Health = 100;
            }
        }
        public void takeDamage(int dmg)
        {
            if(!this.isProtected)
            this.Health -= dmg;
        }
    }
}

