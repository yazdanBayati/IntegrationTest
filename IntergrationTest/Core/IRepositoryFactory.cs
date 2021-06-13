namespace Core
{
    public interface IRepositoryFactory
    {
          T Create<T>(IUintOfWork unitOfWork) where T : class;
    }
}