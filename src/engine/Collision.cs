using Raylib_cs;

static class Collision
{
	public static bool Hit(GameObject target, GameObject victim)
	{
		// Check for if either have collision
		if (!target.HasCollision || !victim.HasCollision) return false;

		// Check for simple collision
		return Raylib.CheckCollisionRecs(target.Hitbox, victim.Hitbox);
	}

	public static GameObject HitAnything(GameObject target)
	{
		// TODO: use .Where(HasCollision)
		foreach (GameObject victim in SceneManager.Scene.GameObjects)
		{
			// Can't hit ourself
			if (victim == target) continue;

			// Check for if we've hit the other thing
			if (Hit(victim, target)) return victim;
		}

		// Didn't hit anything
		return null;
	}
}