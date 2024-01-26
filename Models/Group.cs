namespace TemplateAudacesApi.Models;

public class Group
{
    public Group()
    {
        type = "group";
    }
    public string? type { get; set; }
    public string? uid { get; set; }
    public string? name { get; set; }
    public string? reference { get; set; }
    public string? description { get; set; }
    public string? last_modified { get; set; }
}
