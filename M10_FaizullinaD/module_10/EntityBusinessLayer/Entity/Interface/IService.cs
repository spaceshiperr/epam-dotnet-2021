namespace Entity.Interface
{
    public interface IService<T>
    {
        void Add(T obj);

        void Remove(int id);
        
        void Edit(int id, T obj);

        T Search(int id);
    }
}
