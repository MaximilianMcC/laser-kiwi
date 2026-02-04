using System.Numerics;
using Raylib_cs;

class LemonAndPaeroa : Sprite
{
	//! debug
	public override bool CollisionBlocksMovement => true;

	public override void Start()
	{
		// Make the b
		InitSprite("./assets/l&p.png", new Vector2(30, 80));
		Position = new Vector2(300, -20);
	}

	public override void Update()
	{
		// Check for if the player collides with us
		Kiwi player = SceneManager.Scene.Get<Kiwi>();
		if (Collision.Hit(this, player))
		{
			Console.WriteLine("drunken");
			KillMySelf();
		}
	}
}