namespace SUT23_Projekt___Avancerad_.NET.Services
{
    public interface IAppData<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
