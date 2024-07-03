
using Raylib_cs;

public static class Game {
    public const int WindowWidth = 800;
    public const int WindowHeight = 400;
    public const string Title = "Dino";
    public static readonly Color ClearColor = Color.RayWhite;
    public static IEntity currentScene = new MainScene();
    static void Main() {
        Raylib.InitWindow(WindowWidth, WindowHeight, Title);

        Raylib.SetTargetFPS(300);

        while(!Raylib.WindowShouldClose()) {
            currentScene.Update();
            Raylib.ClearBackground(ClearColor);
            Raylib.BeginDrawing();
                currentScene.Render();
                Raylib.DrawFPS(0, 0);
            Raylib.EndDrawing();
        }


        Raylib.CloseWindow();
    }
}