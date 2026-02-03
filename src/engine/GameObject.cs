using Raylib_cs;

class GameObject
{
	// private GameObject() { }

	public Rectangle Hitbox;

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