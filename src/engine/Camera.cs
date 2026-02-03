using System.Numerics;
using Raylib_cs;

class Camera
{
	public Vector2 Position;
	public float Rotation;

	public void Begin()
	{
		// TODO: Don't make a new one each time maybe
		Camera2D camera = new Camera2D()
		{
			Offset = Raylib.GetScreenCenter() / 2f,
			Target = Position,
			Rotation = Rotation
		};

		Raylib.BeginMode2D(camera);
	}

	public void End() => Raylib.EndMode2D();
}