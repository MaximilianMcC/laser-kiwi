using System.Numerics;
using Raylib_cs;

class Sprite : GameObject
{	
	private Texture2D texture;

	protected void InitSprite(string path, Vector2 size)
	{
		texture = AssetManager.LoadTexture(path);
		Hitbox = new Rectangle(0, 0, size);
	}

	protected void InitSprite(string path)
	{
		texture = AssetManager.LoadTexture(path);
		Hitbox = new Rectangle(0, 0, texture.Dimensions);
	}

	public override void Draw()
	{
		Graphics.DrawTexture(texture, Hitbox);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(texture);
	}
}