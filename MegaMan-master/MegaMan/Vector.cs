using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMan
{

        public class Vector
        {
            public double X;
            public double Y;

            // Constructors.
            public Vector(double x, double y) { X = x; Y = y; }
            public Vector() : this(double.NaN, double.NaN) { }

            public static Vector operator -(Vector v, Vector w)
            {
                return new Vector(v.X - w.X, v.Y - w.Y);
            }

            public static Vector operator +(Vector v, Vector w)
            {
                return new Vector(v.X + w.X, v.Y + w.Y);
            }

            public static double operator *(Vector v, Vector w)
            {
                return v.X * w.X + v.Y * w.Y;
            }

            public static Vector operator *(Vector v, double mult)
            {
                return new Vector(v.X * mult, v.Y * mult);
            }

            public static Vector operator *(double mult, Vector v)
            {
                return new Vector(v.X * mult, v.Y * mult);
            }

            public double Cross(Vector v)
            {
                return X * v.Y - Y * v.X;
            }

            public override bool Equals(object obj)
            {
                var v = (Vector)obj;
                return (X - v.X).IsZero() && (Y - v.Y).IsZero();
            }

            public static bool LineSegementsIntersect(Vector p, Vector p2, Vector q, Vector q2,
        out Vector intersection, double sporedbaParalel, bool considerCollinearOverlapAsIntersect = false)
            {
                intersection = new Vector();

                var r = p2 - p;
                var s = q2 - q;
                var rxs = r.Cross(s);
                var qpxr = (q - p).Cross(r);

                // If r x s = 0 and (q - p) x r = 0, then the two lines are collinear.
                if (rxs.IsZero() && qpxr.IsZero())
                {
                    // 1. If either  0 <= (q - p) * r <= r * r or 0 <= (p - q) * s <= * s
                    // then the two lines are overlapping,
                    if (considerCollinearOverlapAsIntersect)
                        if ((0 <= (q - p) * r && (q - p) * r <= r * r) || (0 <= (p - q) * s && (p - q) * s <= s * s))
                            return true;

                    // 2. If neither 0 <= (q - p) * r = r * r nor 0 <= (p - q) * s <= s * s
                    // then the two lines are collinear but disjoint.
                    // No need to implement this expression, as it follows from the expression above.
                    return false;
                }


                // 3. If r x s = 0 and (q - p) x r != 0, then the two lines are parallel and non-intersecting.
                //if ((rxs.IsZero() && !qpxr.IsZero()))
                if (rxs >= -70 && rxs <= 70 && !qpxr.IsZero())
                {
                    //if (Math.Abs(p.X - q.X) <= 4 && Math.Abs(p.Y - q.Y) <= sporedbaParalel)
                    //{
                    //    return true;
                    //}
                    double[] distance = new double[4];
                    distance[0] = Math.Sqrt(((p.X - q.X) * (p.X - q.X)) + ((p.Y - q.Y) * (p.Y - q.Y)));
                    distance[1] = Math.Sqrt(((p2.X - q2.X) * (p2.X - q2.X)) + ((p2.Y - q2.Y) * (p2.Y - q2.Y)));
                    distance[2] = Math.Sqrt(((p2.X - q.X) * (p2.X - q.X)) + ((p2.Y - q.Y) * (p2.Y - q.Y)));
                    distance[3] = Math.Sqrt(((p.X - q2.X) * (p.X - q2.X)) + ((p.Y - q2.Y) * (p.Y - q2.Y)));
                    Array.Sort(distance);
                    double minDist = distance[0];
                    double maxDist = distance[3];
                    //if (minDist <= 4 && maxDist < 2*sporedbaParalel)
                    //{
                    //    return true;
                    //}
                    //Console.WriteLine("PARALEL");
                    //Console.WriteLine("dist0  " + distance[0]);
                    //Console.WriteLine("dist1  " + distance[1]);
                    //Console.WriteLine("dist2  " + distance[2]);
                    //Console.WriteLine("dist3  " + distance[3]);
                    //Console.WriteLine("qxr: " + qpxr + " rxs: " + rxs);

                    if ((qpxr >= -1.5 * sporedbaParalel && qpxr <= 1.5 * sporedbaParalel) && maxDist <= sporedbaParalel)
                    {
                       // Console.WriteLine("HIT");
                        return true;
                    }


                    return false;
                }
                //Console.WriteLine("qxr: " + qpxr + " rxs: " + rxs);
                // t = (q - p) x s / (r x s)
                var t = (q - p).Cross(s) / rxs;

                // u = (q - p) x r / (r x s)

                var u = (q - p).Cross(r) / rxs;

                // 4. If r x s != 0 and 0 <= t <= 1 and 0 <= u <= 1
                // the two line segments meet at the point p + t r = q + u s.
                if (!rxs.IsZero() && (0 <= t && t <= 1) && (0 <= u && u <= 1))
                {
                    // We can calculate the intersection point using either t or u.
                    intersection = p + t * r;

                    // An intersection was found.
                    return true;
                }

                // 5. Otherwise, the two line segments are not parallel but do not intersect.
                return false;
            }
        }
    
}
