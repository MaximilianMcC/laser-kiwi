using System.Numerics;
using Raylib_cs;

class GameObject
{
	public Vector2 Size;
	public Vector2 Position;
	public Rectangle Hitbox => new Rectangle(Position, Size);

	public virtual void Start() { }
	public virtual void Update() { }
	public virtual void Draw() { }
	public virtual void CleanUp() { }

	protected void KillMySelf() => Destroy();
	public void Destroy()
	{
		SceneManager.Scene.GameObjects.Remove(this);
		CleanUp();
	}
}