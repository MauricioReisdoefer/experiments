using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace raycasting
{
    internal class Wall
    {
        public Vector2 A;
        public Vector2 B;

        public Wall(float x1, float y1, float x2, float y2)
        {
            A = new Vector2(x1, y1);
            B = new Vector2(x2, y2);
        }
        public void Draw()
        {
            Raylib.DrawLineV(A, B, Color.White);
        }
    }
}
