namespace Repo.Public.DTO
{
	public class EmployeeDto
	{
        public long Id { get; set; }
		public string? Name { get; set; }
        public List<JobDto>? Jobs { get; set; }
        public List<JobTaskDto>? Tasks { get; set; }

        public override string ToString()
            => $"{nameof(EmployeeDto)} | {Id} | {Name}";
    }
}
