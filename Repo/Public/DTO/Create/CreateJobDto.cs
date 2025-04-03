namespace Repo.Public.DTO.Update
{
	public class CreateJobDto
    {
		public long Id { get; set; }
		public string? Name { get; set; }

		public override string ToString()
            => $"{nameof(JobDto)} | {Id} | {Name}";
    }
}
