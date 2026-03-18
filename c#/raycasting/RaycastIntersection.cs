using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raycasting
{
    internal class RaycastIntersection
    {
        public Vector2? RaySegmentIntersection(Vector2 rayOrigin, Vector2 rayDir, Vector2 a, Vector2 b)
        {
            // Cross Product
            float den =
                (a.X - b.X) * (rayOrigin.Y - (rayOrigin.Y + rayDir.Y)) -
                (a.Y - b.Y) * (rayOrigin.X - (rayOrigin.X + rayDir.X));

            if (MathF.Abs(den) < 0.00001f)
                return null;

            float t =
                ((a.X - rayOrigin.X) * (rayOrigin.Y - (rayOrigin.Y + rayDir.Y)) -
                 (a.Y - rayOrigin.Y) * (rayOrigin.X - (rayOrigin.X + rayDir.X))) / den;

            float u =
                -((a.X - b.X) * (a.Y - rayOrigin.Y) -
                  (a.Y - b.Y) * (a.X - rayOrigin.X)) / den;

            if (t >= 0 && t <= 1 && u >= 0)
            {
                return new Vector2(
                    a.X + t * (b.X - a.X),
                    a.Y + t * (b.Y - a.Y)
                );
            }

            return null;
        }
    }   
}
