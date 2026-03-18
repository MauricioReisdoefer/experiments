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

    foreach (var wall in walls)
    {
        Vector2[] finalPoints = new Vector2[2];
        Vector2[] vertices = new Vector2[] { wall.A, wall.B };

        for (int i = 0; i < 2; i++)
        {
            Vector2 vertex = vertices[i];
            Vector2 dir = Vector2.Normalize(vertex - mouse);

            float distToVertex = Vector2.Distance(mouse, vertex);

            Vector2? bestHit = null;
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
                        bestHit = hit;
                    }
                }
            }

            if (bestHit != null && minDist < distToVertex - 0.1f)
                finalPoints[i] = bestHit.Value;
            else
                finalPoints[i] = vertex;

            Raylib.DrawLineV(mouse, finalPoints[i], Color.Red);
            Raylib.DrawCircleV(finalPoints[i], 4, Color.Green);
        }

        if (true)
        {
            Raylib.DrawTriangle(mouse, finalPoints[0], finalPoints[1], new Color(255, 255, 100, 80));
        }
    }

    foreach (var wall in walls)
    {
        wall.Draw();
    }

    Raylib.DrawCircleV(mouse, 5, Color.Yellow);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();