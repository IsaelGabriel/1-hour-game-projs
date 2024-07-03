using Raylib_cs;

public class MainScene : IEntity {
    public const int GroundY = Game.WindowHeight - 50;
    public const float MaxObstacleInterval = 2f;
    public const float MinObstacleInterval = 0.5f;
    public const float MaxObstacleHeight = Player.Height;
    public const float MinObstacleHeight = Player.Height / 2;

    private Player player = new Player();

    private List<Rectangle> obstacles = [];
    private float obstacleInterval = 0f;
    private static Random rng = new Random();
    private float obstacleSpeed = 100f;


    public void Update() {
        obstacleInterval -= Raylib.GetFrameTime();
        if(obstacleInterval <= 0f) {
            GenerateObstacle();
            obstacleInterval = (float) rng.NextDouble() * MaxObstacleInterval + MinObstacleInterval;
        }

        for(int i = 0; i < obstacles.Count(); i++) {
            Rectangle rect = obstacles[i];
            rect.X -= obstacleSpeed * Raylib.GetFrameTime();
            obstacles[i] = rect;
        }

        if(obstacles[0].X < -Player.Width) obstacles.RemoveAt(0);

        player.Update();
    }

    private void GenerateObstacle() {
        float height = (float) rng.NextDouble() * MaxObstacleHeight + MinObstacleHeight;
        Rectangle obstacle = new() {
            X = Game.WindowWidth,
            Y = GroundY - height,
            Width = Player.Width,
            Height = height
        };
        obstacles.Add(obstacle);
    }

    public void Render() {
        Raylib.DrawRectangle(0, GroundY, Game.WindowWidth, Game.WindowHeight, Color.Gray);
        player.Render();
        foreach(Rectangle obstacle in obstacles) {
            Raylib.DrawRectangleRec(obstacle, Color.Red);
        }
    }
}