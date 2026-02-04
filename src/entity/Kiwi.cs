using System.Numerics;
using Raylib_cs;

class Kiwi : Sprite
{	
	private readonly float speed = 300f;
	private readonly float jumpForce = 600f;
	private readonly float gravity = 2000f;
	private Vector2 velocity;
	private bool onTheGround;

	private readonly float maxLaserLength = 150f;
	private float currentLaserLength;
	private Vector2 laserAngle;
	public bool UsingLaserEyes = false;

	private Animation animation;

	public override void Start()
	{
		// Make the kiwi
		InitSprite("./assets/kiwi.png", new Vector2(100, 75));

		animation = new Animation("./assets/kiwi.png", 136, 5);
	}

	public override void Update()
	{
		Move();
		SceneManager.Scene.Camera.FocusOn(Hitbox);

		LaserEyes();
	}

	public void Move()
	{
		// Move around
		Vector2 movement = (Input.Get2DMovement() * speed) * Raylib.GetFrameTime();

		if (Maths.MovingRight(movement)) facingRight = !true;
		if (Maths.MovingLeft(movement)) facingRight = !false;

		// Add gravity
		velocity.Y += gravity * Raylib.GetFrameTime();

		// Move
		movement += velocity * Raylib.GetFrameTime();
		(_, GameObject hitY) = MoveWithCollision(movement);
		onTheGround = (hitY != null) && Maths.MovingDownwards(velocity);

		// Check for if we've landed and reset velocity
		if (onTheGround) velocity.Y = 0f;

		// Jump
		if (Input.Jumping() && onTheGround) velocity.Y = -jumpForce;
	}

	public override void Draw()
	{
		// Draw the sprite
		// base.Draw();
		animation.Animate();
		Graphics.DrawTexture(animation.GetFrame(), Hitbox, !facingRight);
		

		// Draw the laser
		float wobble = MathF.Sin((float)Raylib.GetTime() * 40f) * 2f;
		Vector2 laserEndPosition = GetLaserEyePosition() + laserAngle * (currentLaserLength + wobble);

		Raylib.DrawLineEx(
			GetLaserEyePosition(),
			laserEndPosition,
			2f,
			Color.Green
		);
	}

	private Vector2 GetLaserEyePosition()
	{
		Vector2 eyeOrigin = new Vector2(0.88f, 0.6f);
		if (!facingRight) eyeOrigin.X = 1f - eyeOrigin.X;
		return Position + eyeOrigin * Size;
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
			laserAngle = Vector2.Normalize(Raylib.GetMousePosition() - GetLaserEyePosition());
		}
	}

	public override void CleanUp()
	{
		animation.Unload();
	}
}