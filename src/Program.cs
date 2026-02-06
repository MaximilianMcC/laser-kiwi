using System.Numerics;
using Raylib_cs;

class Program
{
	public static void Main(string[] args)
	{
		State.Init("laser kiwi", new Vector2(840, 512));

		SceneManager.Scene = new TestScene();
		SceneManager.Scene.Start();

		RenderTexture2D output = Raylib.LoadRenderTexture((int)State.GameSize.X, (int)State.GameSize.Y);

		while (!Raylib.WindowShouldClose())
		{
			State.Update();
			SceneManager.Scene.Update();

			Raylib.BeginTextureMode(output);
			Raylib.ClearBackground(Color.Black);
			SceneManager.Scene.Render();
			Raylib.EndTextureMode();

			Raylib.BeginDrawing();
			Raylib.ClearBackground(Color.Black);
			Graphics.DrawRenderTextureOverWholeScreen(output);
			TextDrawer.BeginDrawing();
			Raylib.EndDrawing();
		}

		Raylib.UnloadRenderTexture(output);
		SceneManager.Scene.CleanUp();
		Raylib.CloseWindow();
	}
}