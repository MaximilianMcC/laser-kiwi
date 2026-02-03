using Raylib_cs;

static class SceneManager
{
	public static Scene Scene;
}

abstract class Scene
{
	public List<GameObject> GameObjects = [];
	public Camera Camera;

	// TODO: maybe don't do this
	public abstract void Populate();

	public void Start()
	{
		// Make a default camera for if we forget one
		Camera = new Camera();

		Populate();

		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.Start();
		}	
	}

	public void Update()
	{
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.Update();
		}
	}

	public void Render()
	{
		Camera.Begin();
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.Draw();
		}
		Camera.End();
	}

	public void CleanUp()
	{
		foreach (GameObject gameObject in GameObjects)
		{
			gameObject.CleanUp();
		}	
	}

	public T Get<T>() => GameObjects.OfType<T>().FirstOrDefault();
	public List<T> GetAll<T>() => GameObjects.OfType<T>().ToList();
}