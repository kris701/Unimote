namespace Unimote.Server.API
{
	public static class ButtonsDefinition
	{
		public class VirtualButton
		{
			public string Name { get; set; }
			public Guid ID { get; set; }

			public VirtualButton(string name, Guid iD)
			{
				Name = name;
				ID = iD;
			}
		}

		public static IEnumerable<VirtualButton> Buttons { get; } = new List<VirtualButton>()
		{
			new VirtualButton("up", new Guid("9ec45789-6cf2-4911-abae-3475b1430cd4")),
			new VirtualButton("down", new Guid("39e84a48-d1b9-4e15-a134-370ebe49f3d4")),
			new VirtualButton("left", new Guid("82803903-6c45-481f-a692-b7d77f58ee72")),
			new VirtualButton("right", new Guid("0ffde619-a017-42c1-8964-f19e0f1a219f")),

			new VirtualButton("a", new Guid("bd3a0f95-8f73-40cd-8b53-1e4b4fac7ae5")),
			new VirtualButton("b", new Guid("b721af6c-6fd8-486c-9359-6aefafa6f791")),
			new VirtualButton("c", new Guid("a520871d-2c0d-4408-948a-37566e399577")),
			new VirtualButton("d", new Guid("3c9139d3-65fd-4bf2-9737-c2bae5f8eb62")),
			new VirtualButton("e", new Guid("7deb5be9-809f-4963-9b3d-b23b3476aa10")),
			new VirtualButton("f", new Guid("32b596e6-7473-4874-8636-fe2a727a06eb")),
			new VirtualButton("g", new Guid("6baa572d-b605-4399-9388-7facb56f47b2")),
			new VirtualButton("h", new Guid("24776e53-2e82-42a6-8b09-ab62a60214f6")),
			new VirtualButton("i", new Guid("11def401-4279-4f20-8637-b9c884adbebb")),
			new VirtualButton("j", new Guid("13bdd5a7-127a-4a9b-851f-c5e5150e12a3")),
			new VirtualButton("k", new Guid("9455e491-d0e3-4bd6-a6fb-59259516c903")),
			new VirtualButton("l", new Guid("73c8d18a-d52c-40dc-8695-1b005b0ece04")),
			new VirtualButton("m", new Guid("52b6f0a0-f364-43da-9bb6-4cefffce626b")),
			new VirtualButton("n", new Guid("1f9ab2f1-e739-4365-8701-015833f10eff")),

		};
	}
}
