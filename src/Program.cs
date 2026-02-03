using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(512, 512, "laser kiwi");

		SceneManager.Scene = new TestScene();
		SceneManager.Scene.Start();

		while (!Raylib.WindowShouldClose())
		{
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