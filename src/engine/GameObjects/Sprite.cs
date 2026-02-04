using System.Numerics;
using Raylib_cs;

class Sprite : GameObject
{	
	private Texture2D texture;
	protected bool facingRight = true;

	protected void InitSprite(string path, Vector2 size)
	{
		texture = AssetManager.LoadTexture(path);
		Size = size;
	}

	protected void InitSprite(string path)
	{
		texture = AssetManager.LoadTexture(path);
		Size = texture.Dimensions;
	}

	public override void Draw()
	{
		Graphics.DrawTexture(texture, Hitbox, !facingRight);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(texture);
	}
}