using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConfThailand.Features.Demos
{
    public class ReadOnlyMemberDemo
    {
        public static void Demo()
        {
            GraphPoint(new Point(10, 15));
        }

        private static void GraphPoint(in Point point)
        {
            // do something with point
            point.Negate();
        }
    }

    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set;  }

        public override readonly string ToString() =>
            $"Point({X},{Y})";

        public void Negate()
        {
            X *= -1;
            Y *= -1;
        }
    }
}
