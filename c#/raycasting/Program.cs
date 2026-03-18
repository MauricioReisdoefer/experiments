using raycasting;
using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Base Window");

var raycast = new RaycastIntersection();

List<Wall> walls = new List<Wall>()
{
    new Wall(200, 30, 200, 300),
    new Wall(400, 100, 600, 100),
    new Wall(500, 200, 700, 400)
};

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    Vector2 mouse = Raylib.GetMousePosition();
    List<Vector2> hits = new List<Vector2>();

    float epsilon = 0.0001f;

    foreach (var wall in walls)
    {
        List<Vector2> vertices = new List<Vector2>() { wall.A, wall.B };
        foreach (var vertex in vertices)
        {
            float baseAngle = MathF.Atan2(vertex.Y - mouse.Y, vertex.X - mouse.X);
            for (int i = -1; i <= 1; i++)
            {
                float angle = baseAngle + i * epsilon;

                Vector2 dir = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
                Vector2? closestHit = null;
                float minDist = float.MaxValue;

                foreach (var w in walls)
                {
                    var hit = raycast.RaySegmentIntersection(mouse, dir, w.A, w.B);
                    if (hit != null)
                    {
                        float dist = Vector2.Distance(mouse, hit.Value);
                        if (dist < minDist)
                        {
                            minDist = dist;
                            closestHit = hit;
                        }
                    }
                }

                if (closestHit != null)
                {
                    hits.Add(closestHit.Value);
                    Raylib.DrawLineV(mouse, closestHit.Value, Color.Red);
                }
            }
        }
    }
    foreach (var wall in walls)
    {
        wall.Draw();
    }
    foreach (var h in hits)
    {
        Raylib.DrawCircleV(h, 4, Color.Green);
    }

    Raylib.DrawCircleV(mouse, 5, Color.Yellow);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();