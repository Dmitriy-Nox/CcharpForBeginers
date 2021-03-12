namespace Shop.ModelShop.Interfaces
{
    public interface  IParams
    {
       int Id { get; set; }
       string Name { get; set; }
       double Vol { get; set; }
       decimal Price { get; set; }
       string Cathegory { get; set; }
    }
}
