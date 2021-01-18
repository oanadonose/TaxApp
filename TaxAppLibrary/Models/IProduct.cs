namespace TaxAppLibrary.Models
{
    public interface IProduct
    {
        decimal BasePrice { get; set; }
        string Name { get; set; }
    }
}