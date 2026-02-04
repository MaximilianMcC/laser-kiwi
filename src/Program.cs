using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		State.WindowTitle = "laser kiwi";
		Raylib.SetConfigFlags(ConfigFlags.ResizableWindow | ConfigFlags.AlwaysRunWindow);
		Raylib.InitWindow(840, 512, State.WindowTitle);

		SceneManager.Scene = new TestScene();
		SceneManager.Scene.Start();

		while (!Raylib.WindowShouldClose())
		{
			State.Update();
			SceneManager.Scene.Update();

			Raylib.BeginDrawing();
			TextDrawer.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			SceneManager.Scene.Render();
			Raylib.EndDrawing();
		}

		SceneManager.Scene.CleanUp();
		Raylib.CloseWindow();
	}
}