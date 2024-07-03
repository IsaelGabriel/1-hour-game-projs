using Raylib_cs;

public class MainScene : IEntity {
    public const int GroundY = Game.WindowHeight - 50;
    public void Render() {
        Raylib.DrawRectangle(0, GroundY, Game.WindowWidth, Game.WindowHeight, Color.Gray);
    }
}