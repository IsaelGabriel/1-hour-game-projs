
using Raylib_cs;

public class Player : IEntity
{
    public static readonly Color PlayerColor = Color.Lime;

    public const int Width = 48;
    public const int Height = 2*Width;

    private const float Gravity = 1200f;
    private const float JumpVelocity = 700f;
    private static readonly float defaultY = MainScene.GroundY - Height;

    public const int x = 50;
    public float y = defaultY;

    private float yVelocity = 0f;
    private bool canJump = true;
    private float jumpCount = 0f;

    public void Update()
    {

        if(Raylib.IsKeyPressed(KeyboardKey.Space) && canJump) {
            yVelocity = -JumpVelocity;
            canJump = false;
        }

        float mult = 1f;

        if(yVelocity > 0f && Raylib.IsKeyDown(KeyboardKey.Down)) {
            mult = 4f;
        }
        yVelocity += mult * Gravity * Raylib.GetFrameTime();
        


        y += yVelocity * Raylib.GetFrameTime();

        if(y > defaultY) {
            y = defaultY;
            yVelocity = 0f;
            canJump = true;
        }
    }
    
    public void Render()
    {
        Raylib.DrawRectangle(x, (int) y, Width, Height, PlayerColor);
    }
}