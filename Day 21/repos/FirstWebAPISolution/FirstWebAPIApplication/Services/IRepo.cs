namespace FirstWebAPIApplication.Services
{
    public interface IRepo<K, T>
    {
        ICollection<T> GetAll();
        T Get(K id);
        T GetById(object id);
        bool Insert(T item);
        bool Delete(T item);
        bool Update(T item);
    }
}
