using Repo.Internal.Entities;
using Repo.Public.DTO;

namespace Repo.Mappers
{
	internal static class EntityToDtoMappers
	{
		internal static JobDto ToDto(this Job job)
		{
			return new JobDto
			{
				Id = job.Id,
				Name = job.Name
			};
		}

		internal static JobTaskDto ToDto(this JobTask jobTask)
		{
			return new JobTaskDto
			{
				Id = jobTask.Id,
				Name = jobTask.Name
			};
		}

		internal static EmployeeDto ToDto(this Employee employee)
		{
			return new EmployeeDto
			{
				Id = employee.Id,
				Name = employee.Name
			};
		}

		internal static IEnumerable<JobDto> ToDtos(this IEnumerable<Job> jobs)
		{
			return jobs.Select(j => j.ToDto());
		}

		internal static IEnumerable<JobTaskDto> ToDtos(this IEnumerable<JobTask> jobTasks)
		{
			return jobTasks.Select(j => j.ToDto());
		}

		internal static IEnumerable<EmployeeDto> ToDtos(this IEnumerable<Employee> employees)
		{
			return employees.Select(e => e.ToDto());
		}
	}
}
