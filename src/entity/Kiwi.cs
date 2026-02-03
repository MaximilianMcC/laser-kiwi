using System.Numerics;
using Raylib_cs;

class Kiwi : GameObject
{	
	private Texture2D texture;
	private Rectangle hitbox;

	public override void Start()
	{
		// Make the kiwi
		texture = AssetManager.LoadTexture("./assets/kiwi.png");
		hitbox = new Rectangle(0, 0, 100, 75);

		// Make the camera
		// TODO: Don't do this here
		SceneManager.Scene.Camera = new Camera();
	}

	public override void Update()
	{
		
	}

	public override void Draw()
	{
		SceneManager.Scene.Camera.Position = hitbox.Position;
		Graphics.DrawTexture(texture, hitbox);
	}

	public override void CleanUp()
	{
		Raylib.UnloadTexture(texture);
	}
}