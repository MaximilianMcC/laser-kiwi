using System.Numerics;
using Raylib_cs;

class Grass : GameObject
{
	public override bool HasCollision => true;
	public override bool CollisionBlocksMovement => true;

	public override void Start()
	{
		Size = new Vector2(400, 30);
		Position = new Vector2(-100, 100);
	}

	public override void Draw()
	{
		Raylib.DrawRectangleRec(Hitbox, Color.DarkGreen);
	}
}