using raycasting;
using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(800, 600, "Base Window");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    Vector2 mouse = Raylib.GetMousePosition();

    Wall wall = new Wall(30, 30, 100, 30);


    wall.Draw();
    Raylib.DrawCircleV(mouse, 5, Color.Yellow);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();