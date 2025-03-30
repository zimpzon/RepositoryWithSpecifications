namespace Repo.Internal.Entities
{
	internal class JobTask
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public Job? Job { get; set; }
		public ICollection<Employee>? Employees { get; set; }
	}
}
