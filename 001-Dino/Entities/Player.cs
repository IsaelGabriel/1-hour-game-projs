
using Raylib_cs;

public class Player : IEntity
{
    public static readonly Color PlayerColor = Color.Lime;

    public const int Width = 48;
    public const int Height = 2*Width;

    private const float Gravity = 98f;
    private const float JumpForce = 200f;
    private static readonly float defaultY = MainScene.GroundY - Height;

    public const int x = 50;
    public float y = defaultY;

    private float yVelocity = 0f;
    private bool canJump = true;

    public void Update()
    {
        if(Raylib.IsKeyPressed(KeyboardKey.Space) && canJump) {
            yVelocity = -JumpForce;
            canJump = false;
        }else {
            float mult = (yVelocity < 0f)? 2f : 1f;
            yVelocity += Gravity * Raylib.GetFrameTime() * mult;
        }

        float velMult = (yVelocity > 0f)? 2f : 1f;
        y += velMult * yVelocity * Raylib.GetFrameTime();

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