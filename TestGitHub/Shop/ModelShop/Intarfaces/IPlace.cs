namespace Shop.ModelShop.Interfaces
{
    public interface IPlace<T>
    {
        bool RemoveItem(int id);
        bool AddItem(T item);
    }
}
