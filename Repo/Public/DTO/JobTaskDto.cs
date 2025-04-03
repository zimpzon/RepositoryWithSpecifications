namespace Repo.Public.DTO
{
	public class JobTaskDto
	{
        public long Id { get; set; }
		public string? Name { get; set; }
        public JobDto? Job { get; set; }
        public List<EmployeeDto>? Employees { get; set; }

        public override string ToString()
            => $"{nameof(JobDto)} | {Id} | {Name}";
    }
}
