namespace Aspose.Models;

public class TableData
{
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<ProductOption> Materials { get; set; }
    public IEnumerable<ProductOption> Optionals { get; set; }
}
public class Product
{
    public string Id { get; set; }
    public string Label { get; set; }
    public string Amount { get; set; }
}
public class ProductOption
{
    public string Id { get; set; }
    public string SetId { get; set; }
    public string Label { get; set; }
    public string Amount { get; set; }
}