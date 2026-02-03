class Scene
{
	public List<GameObject> gameObjects = [];

	public void Update()
	{
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Update();
		}
	}

	public void Render()
	{
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.Draw();
		}	
	}

	public void CleanUp()
	{
		foreach (GameObject gameObject in gameObjects)
		{
			gameObject.CleanUp();
		}	
	}
}