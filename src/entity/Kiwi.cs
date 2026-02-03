using System.Numerics;
using Raylib_cs;

class Kiwi : GameObject
{	
	private Texture2D texture;
	private Vector2 size = new Vector2(100, 75);

	private Vector2 position;

	public Kiwi()
	{
		texture = AssetManager.LoadTexture("./assets/kiwi.png");
	}

	public override void Update()
	{
		// Raylib.DrawTexture(texture, 0, 0, Color.White);
		Graphics.DrawTexture(texture, position, size);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(texture);
	}
}