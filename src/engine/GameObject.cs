using System.Numerics;
using Raylib_cs;

class GameObject
{
	public Vector2 Size;
	public Vector2 Position;
	public Rectangle Hitbox => new Rectangle(Position, Size);

	public virtual bool HasCollision => true;
	public virtual bool CollisionBlocksMovement => false;

	public virtual void Start() { }
	public virtual void Update() { }
	public virtual void Draw() { }
	public virtual void CleanUp() { }

	public void DrawHitbox()
	{
		// TODO: Generate a random color based on the hash
		Raylib.DrawRectangleLinesEx(Hitbox, 3f, Color.Magenta);
	}

	protected void KillMySelf() => Destroy();
	public void Destroy()
	{
		SceneManager.Scene.GameObjects.Remove(this);
		CleanUp();
	}

	// TODO: Evaluate
	// TODO: Make it return the new movement vector
	protected (GameObject, GameObject) MoveWithCollision(Vector2 newMovement)
	{
		// Check for X collision
		Position.X += newMovement.X;
		GameObject xCollision = Collision.HitAnything(this);
		if (xCollision?.CollisionBlocksMovement == true)
		{
			// If we hit something then undo the movement
			Position.X -= newMovement.X;
		}

		// Check for Y collision
		Position.Y += newMovement.Y;
		GameObject yCollision = Collision.HitAnything(this);
		if (yCollision?.CollisionBlocksMovement == true)
		{
			// If we hit something then undo the movement
			Position.Y -= newMovement.Y;
		}

		// Give back the collisions
		return (xCollision, yCollision);
	}
}