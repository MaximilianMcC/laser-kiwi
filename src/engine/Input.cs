using System.Numerics;
using Raylib_cs;

class Input
{
	public static Vector2 Get2DMovement()
	{
		Vector2 movement = Vector2.Zero;
		if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left)) movement.X--;
		if (Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right)) movement.X++;
		return movement;
	}
}