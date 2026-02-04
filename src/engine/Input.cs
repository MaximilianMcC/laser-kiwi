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

	public static bool Jumping() => Raylib.IsKeyDown(KeyboardKey.Space) || Raylib.IsKeyDown(KeyboardKey.Up);
	public static bool Debug() => Raylib.IsKeyPressed(KeyboardKey.F3) || Raylib.IsKeyPressed(KeyboardKey.Grave);
}