class TestScene : Scene
{
	public override void Populate()
	{
		GameObjects.Add(new Kiwi());
		// GameObjects.Add(new BeeHive());
		GameObjects.Add(new LemonAndPaeroa());
		GameObjects.Add(new SunAndMoon());
		GameObjects.Add(new Grass());
		GameObjects.Add(new Sky());
	}
}