using LiteralLinq.Expression.Design;
using LiteralLinqTests.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteralLinq.Linq.Tests
{
    [LiteralConverter(typeof(LLPointConverter2))]
    internal struct GeoPoint2
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public GeoPoint2(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static bool operator ==(GeoPoint2 a, GeoPoint2 b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(GeoPoint2 a, GeoPoint2 b)
        {
            return !(a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }
    }
}