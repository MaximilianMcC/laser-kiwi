using System.Numerics;
using Raylib_cs;

class Sky : GameObject
{
	public override bool HasCollision => false;
	public override bool DrawInWorldSpace => false;

	private Texture2D texture;

	public override void Start()
	{
		texture = AssetManager.LoadTexture("./assets/night.png");
	}

	public override void Draw()
	{
		Graphics.DrawTextureOverWholeScreen(texture);
	}
}