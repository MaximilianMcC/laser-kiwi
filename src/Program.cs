using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		Raylib.InitWindow(512, 512, "laser kiwi");

		Scene scene = new TestScene();

		while (!Raylib.WindowShouldClose())
		{
			scene.Update();

			Raylib.BeginDrawing();
			TextDrawer.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			scene.Render();
			Raylib.EndDrawing();
		}

		scene.CleanUp();
		Raylib.CloseWindow();
	}
}