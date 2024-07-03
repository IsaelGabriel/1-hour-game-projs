
using Raylib_cs;

public class Player : IEntity
{
    public static readonly Color PlayerColor = Color.Lime;

    public const int Width = 48;
    public const int Height = 2*Width;

    private const float Gravity = 1200f;
    private const float JumpVelocity = 700f;
    private const float JumpDuration = 0.01f;
    private static readonly float defaultY = MainScene.GroundY - Height;

    public const int x = 50;
    public float y = defaultY;

    private float yVelocity = 0f;
    private bool canJump = true;
    private float jumpCount = 0f;

    public void Update()
    {
        jumpCount -= Raylib.GetFrameTime();

        if(Raylib.IsKeyPressed(KeyboardKey.Space) && canJump) {
            yVelocity = -JumpVelocity;
            jumpCount = JumpDuration;
            canJump = false;
        }else if(jumpCount <= 0f) {
            yVelocity += Gravity * Raylib.GetFrameTime();
        }

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