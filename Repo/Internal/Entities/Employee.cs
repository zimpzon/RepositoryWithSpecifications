namespace Repo.Internal.Entities
{
	internal class Employee
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public ICollection<Job>? Jobs { get; set; }
		public ICollection<JobTask>? Tasks { get; set; }
	}
}
