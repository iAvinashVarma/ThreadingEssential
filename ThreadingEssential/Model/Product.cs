namespace ThreadingEssential.Model
{
	internal class Product
	{
		private int id;

		public int Id
		{
			get => id;
			set => id = value;
		}

		private string name;

		public string Name
		{
			get => name;
			set => name = value;
		}

		public override string ToString() => $"Product id: {id} and name: {name}.";
	}
}