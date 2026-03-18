using raycasting;
using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Base Window");

var raycast = new RaycastIntersection();
Wall wall = new Wall(200, 30, 200, 300);

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    Vector2 mouse = Raylib.GetMousePosition();

    Vector2 dir = new Vector2(1, 0);
    var hit = raycast.RaySegmentIntersection(mouse, dir, wall.A, wall.B);

    wall.Draw();
    Raylib.DrawLineV(mouse, mouse + dir * 1000, Color.Red);

    if (hit != null)
    {
        Raylib.DrawCircleV(hit.Value, 6, Color.Green);
    }

    Raylib.DrawCircleV(mouse, 5, Color.Yellow);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();