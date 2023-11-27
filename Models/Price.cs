namespace TemplateAudacesApi.Models;

public class Price
{
    public string color { get; set; }
    public double price { get; set; }
    public string size { get; set; }
    public Garment garment { get; set; }
    public Item item { get; set; }
}
