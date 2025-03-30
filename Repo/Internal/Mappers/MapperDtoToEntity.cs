using Repo.Internal.Entities;
using Repo.Public.DTO;

namespace Repo.Mappers
{
	internal static class DtoToEntityMappers
	{
		internal static Job ToEntity(this JobDto jobDto)
		{
			return new Job
			{
				Id = jobDto.Id,
				Name = jobDto.Name,
				Employees = [],
				JobTasks = []
			};
		}

		internal static JobTask ToEntity(this JobTaskDto jobTaskDto)
		{
			return new JobTask
			{
				Id = jobTaskDto.Id,
				Name = jobTaskDto.Name
			};
		}

		internal static Employee ToEntity(this EmployeeDto employeeDto)
		{
			return new Employee
			{
				Id = employeeDto.Id,
				Name = employeeDto.Name
			};
		}

		internal static IEnumerable<Job> ToEntities(this IEnumerable<JobDto> jobDtos)
		{
			return jobDtos.Select(j => j.ToEntity());
		}

		internal static IEnumerable<JobTask> ToEntities(this IEnumerable<JobTaskDto> jobTaskDtos)
		{
			return jobTaskDtos.Select(j => j.ToEntity());
		}

		internal static IEnumerable<Employee> ToEntities(this IEnumerable<EmployeeDto> employeeDtos)
		{
			return employeeDtos.Select(e => e.ToEntity());
		}
	}
}
