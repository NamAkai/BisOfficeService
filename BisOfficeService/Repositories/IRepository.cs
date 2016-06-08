
namespace PublishSolution.Service.Repositories
{
    public interface IRepository<T>
    {
        T[] GetAll();

        void Insert(T entity);

        bool Update(T entity);

        bool Delete(int id);
    }
}
