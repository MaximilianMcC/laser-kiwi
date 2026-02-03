using System.Numerics;
using Raylib_cs;

static class Graphics
{
	public static Rectangle GetTextureRectangle(Texture2D texture)
	{
		return new Rectangle(0, 0, texture.Dimensions);
	}

	public static void DrawTexture(Texture2D texture, Vector2 position, Vector2 size)
	{
		Raylib.DrawTexturePro(
			texture,
			GetTextureRectangle(texture),
			new Rectangle(position, size),
			Vector2.Zero,
			0f,
			Color.White
		);
	}
}