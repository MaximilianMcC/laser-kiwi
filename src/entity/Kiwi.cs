using System.Numerics;
using Raylib_cs;

class Kiwi : GameObject
{	
	private Texture2D texture;
	private Rectangle hitbox;

	private readonly float speed = 300f;

	public override void Start()
	{
		// Make the kiwi
		texture = AssetManager.LoadTexture("./assets/kiwi.png");
		hitbox = new Rectangle(0, 0, 100, 75);
	}

	public override void Update()
	{
		// Move around
		Vector2 movement = Input.Get2DMovement() * speed * Raylib.GetFrameTime();
		hitbox.Position += movement;
	}

	public override void Draw()
	{
		SceneManager.Scene.Camera.FocusOn(hitbox);
		Graphics.DrawTexture(texture, hitbox);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(texture);
	}
}