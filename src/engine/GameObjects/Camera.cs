using System.Numerics;
using Raylib_cs;

class Camera
{
	public Vector2 Position;
	public float Rotation;

	public void FocusOn(Rectangle thing)
	{
		Position = thing.Position + (thing.Size / 2);
	}

	public void Begin()
	{
		// TODO: Don't make a new one each time maybe
		Camera2D camera = new Camera2D()
		{
			// TODO: Use 0 offset
			Offset = State.GameSize / 2f,
			Target = Position,
			Rotation = Rotation,
			Zoom = 1
		};

		Raylib.BeginMode2D(camera);
	}

	public void End() => Raylib.EndMode2D();
}