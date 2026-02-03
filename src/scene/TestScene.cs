class TestScene : Scene
{
	public override void Populate()
	{
		GameObjects.Add(new BeeHive());
		GameObjects.Add(new Kiwi());
	}
}