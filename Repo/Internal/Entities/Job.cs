namespace Repo.Internal.Entities
{
	internal class Job
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public ICollection<Employee> Employees { get; set; } = [];
		public ICollection<JobTask> JobTasks { get; set; } = [];
	}
}
