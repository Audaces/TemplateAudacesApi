namespace TemplateAudacesApi.Models;

public class Image
{
    public string? description { get; set; }
    public string? uid { get; set; }
    public int? size { get; set; }
    public string? extension { get; set; }

    public string get_image_name()
    {
        return "Images\\" + uid + "." + extension;
    }
}
