using System.Numerics;
using Raylib_cs;

class Kiwi : Sprite
{	
	private readonly float speed = 300f;

	private readonly float maxLaserLength = 150f;
	private float currentLaserLength;
	private Vector2 laserAngle;
	public bool UsingLaserEyes = false;

	public override void Start()
	{
		// Make the kiwi
		InitSprite("./assets/kiwi.png", new Vector2(100, 75));
	}

	public override void Update()
	{
		// Move around
		Vector2 movement = (Input.Get2DMovement() * speed) * Raylib.GetFrameTime();
		Position += movement;
		SceneManager.Scene.Camera.FocusOn(Hitbox);

		LaserEyes();
	}

	public override void Draw()
	{
		// Draw the sprite
		base.Draw();

		// Draw the laser
		Vector2 eyeOrigin = new Vector2(0.88f, 0.6f);
		Vector2 laserStartPosition = Position + eyeOrigin * Size;

		float wobble = MathF.Sin((float)Raylib.GetTime() * 40f) * 2f;
		Vector2 laserEndPosition = laserStartPosition + laserAngle * (currentLaserLength + wobble);

		Raylib.DrawLineEx(
			laserStartPosition,
			laserEndPosition,
			2f,
			Color.Green
		);
	}

	private void LaserEyes()
	{
		// Check for if we're turning the laser on/off
		UsingLaserEyes = Raylib.IsKeyDown(KeyboardKey.LeftControl);

		// Animate the laser (all the time so we get extend/retract)
		float targetLength = UsingLaserEyes ? maxLaserLength : 0f;
		float laserAnimationSpeed = UsingLaserEyes ? 20f : 40f;
		currentLaserLength = Maths.Lerp(
			currentLaserLength,
			targetLength,
			laserAnimationSpeed * Raylib.GetFrameTime()
		);

		// Get the new angle of the laser
		if (UsingLaserEyes)
		{
			Vector2 eyeOrigin = new Vector2(0.88f, 0.6f);
			Vector2 eyePosition = Position + eyeOrigin * Size;
			laserAngle = Vector2.Normalize(Raylib.GetMousePosition() - eyePosition);
		}
	}
}