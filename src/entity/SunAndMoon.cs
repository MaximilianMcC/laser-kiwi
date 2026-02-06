using System.Numerics;
using Raylib_cs;

class SunAndMoon : GameObject
{
	public override bool HasCollision => false;
	public override bool DrawInWorldSpace => false;

	private Texture2D texture;
	private float rotation;
	private readonly float rotationSpeed = 20f;

	public override void Start()
	{
		texture = AssetManager.LoadTexture("./assets/sun-and-moon.png");
		Size = new Vector2(State.GameSize.Y);
		Position = State.GameSize / 2f;
	}

	public override void Draw()
	{
		// TODO: Use modulo
		rotation += rotationSpeed * Raylib.GetFrameTime();
		if (rotation > 360) rotation = 0;

		Graphics.DrawRotatedTextureFromCentre(texture, Hitbox, rotation);
	}
}