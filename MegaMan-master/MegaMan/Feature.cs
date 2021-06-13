using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan
{
    public class Feature
    {
        public Bitmap img { set; get; }
        public int type { set; get; } // 1 = heart; 2 = lightning; 3 = shield
        public Point location { set; get; }
        public Feature(Bitmap img, int type, Point location)
        {
            this.img = img;
            this.type = type;
            this.location = location;
        }
        public void Draw(Graphics g)
        {
            Rectangle rc = new Rectangle(location.X, location.Y, 50, 50);
            g.DrawImage(img, rc);
        }
        public bool isTouching(Feature f)
        {
            if (type != 1)
                return (f.location.X >= location.X && f.location.X <= location.X + 60) || (f.location.Y >= location.Y && f.location.Y <= location.Y + 60);
            else
                return (f.location.X >= location.X && f.location.X <= location.X + 80) || (f.location.Y >= location.Y && f.location.Y <= location.Y + 80);
        }
        public bool isHit(Point loc)
        {
            if (type == 2) // lightning
                return (loc.X >= location.X + 10 && loc.X <= location.X + 50) && (loc.Y >= location.Y && loc.Y <= location.Y + 50);

            else // heart or shield
                return (loc.X >= location.X && loc.X <= location.X + 50) && (loc.Y >= location.Y && loc.Y <= location.Y + 50);
        }
    }
}
