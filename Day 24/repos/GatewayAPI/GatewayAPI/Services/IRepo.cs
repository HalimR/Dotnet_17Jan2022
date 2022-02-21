namespace GatewayAPI.Services
{
    public interface IRepo<K,T>
    {
        Task<T> Get(K key);
        Task<T> Insert(T item);
        Task<T> Update(T item);
        Task<T> Delete(K key);
        Task<IEnumerable<T>> GetAll();
    }
}
