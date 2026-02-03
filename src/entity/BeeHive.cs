using System.Numerics;
using Raylib_cs;

class BeeHive : GameObject
{	
	private Texture2D texture;
	private Rectangle hitbox;

	public override void Start()
	{
		// Make the b
		texture = AssetManager.LoadTexture("./assets/b.png");
		hitbox = new Rectangle(0, 0, texture.Dimensions);
	}

	public override void Draw()
	{
		Graphics.DrawTexture(texture, hitbox);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(texture);
	}
}