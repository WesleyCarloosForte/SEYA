namespace SEYA.APP.Server.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int Id);
        Task<ICollection<T>> GetAsync(string txt);
        Task SaveAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
