namespace SampleMVCApplication.Services
{
    public interface IRepo<K, T> //key, object type
    {
        ICollection<T> GetAll();
        T Get(K id);
        bool Add(T item);
        bool Remove(K id);
        bool Update(T item);
    }
}
