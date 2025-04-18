﻿namespace Repo.Public.DTO
{
	public class JobDto
	{
		public long Id { get; set; }
		public string? Name { get; set; }
        public List<EmployeeDto> Employees { get; set; } = [];
        public List<JobTaskDto> JobTasks { get; set; } = [];

        public override string ToString()
            => $"{nameof(JobDto)} | {Id} | {Name}";
    }
}
