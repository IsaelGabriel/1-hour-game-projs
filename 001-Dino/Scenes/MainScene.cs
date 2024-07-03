using Raylib_cs;

public class MainScene : IEntity {
    public const int GroundY = Game.WindowHeight - 50;


    private Player player = new Player();

    public void Update() {
        player.Update();
    }

    public void Render() {
        Raylib.DrawRectangle(0, GroundY, Game.WindowWidth, Game.WindowHeight, Color.Gray);
        player.Render();
    }
}