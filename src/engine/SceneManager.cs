using System.Collections.ObjectModel;
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

		for (int i = 0; i < GameObjects.Count; i++)
		{
			GameObjects[i].Start();
		}
	}

	public void Update()
	{
		for (int i = GameObjects.Count - 1; i >= 0 ; i--)
		{
			GameObjects[i].Update();
		}
	}

	public void Render()
	{
		// Segregate the world and screen stuff
		List<GameObject> worldStuff = GameObjects.Where(gameObject => gameObject.DrawInWorldSpace).ToList();
		List<GameObject> screenStuff = GameObjects.Where(gameObject => !gameObject.DrawInWorldSpace).ToList();

		// Draw everything not in the world (no camera)
		for (int i = screenStuff.Count - 1; i >= 0 ; i--)
		{
			screenStuff[i].Draw();
			if (State.Debug) screenStuff[i].DrawHitbox();
		}

		// Draw everything in the world
		Camera.Begin();
		for (int i = worldStuff.Count - 1; i >= 0 ; i--)
		{
			worldStuff[i].Draw();
			if (State.Debug) worldStuff[i].DrawHitbox();
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