using System.Numerics;
using Raylib_cs;

class Kiwi : Sprite
{	
	private readonly float speed = 300f;

	public override void Start()
	{
		// Make the kiwi
		InitSprite("./assets/kiwi.png", new Vector2(100, 75));
	}

	public override void Update()
	{
		// Move around
		Vector2 movement = Input.Get2DMovement() * speed * Raylib.GetFrameTime();
		Hitbox.Position += movement;
	}
}