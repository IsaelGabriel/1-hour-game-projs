
using Raylib_cs;

public class Game {
    public const int WindowWidth = 800;
    public const int WindowHeight = 400;
    public const string Title = "Dino";
    public static readonly Color ClearColor = Color.RayWhite;
    static void Main() {
        Raylib.InitWindow(WindowWidth, WindowHeight, Title);

        Raylib.SetTargetFPS(300);

        while(!Raylib.WindowShouldClose()) {
            Raylib.ClearBackground(ClearColor);
            Raylib.BeginDrawing();

                Raylib.DrawFPS(0, 0);
            Raylib.EndDrawing();
        }


        Raylib.CloseWindow();
    }
}