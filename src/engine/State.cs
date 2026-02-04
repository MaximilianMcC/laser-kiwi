using Raylib_cs;

static class State
{
	public static bool Debug { get; set; }
	public static string WindowTitle { get; set; }

	public static void Update()
	{
		if (Raylib.IsKeyPressed(KeyboardKey.Grave) || Raylib.IsKeyPressed(KeyboardKey.F3))
		{
			// Toggle debug mode
			Debug = !Debug;

			// Update the window title
			const string debugPrefix = "(debug) ";
			Raylib.SetWindowTitle((Debug ? debugPrefix : "") + WindowTitle);
		}
	}
}