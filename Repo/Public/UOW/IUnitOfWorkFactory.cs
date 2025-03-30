namespace Repo.Public.UOW
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork CreateUnitOfWork();
	}
}
