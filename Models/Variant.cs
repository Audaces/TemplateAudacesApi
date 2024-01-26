using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Variant
{
    public string? name { get; set; }
    public string? description { get; set; }
    public string? value { get; set; }
    public string? notes { get; set; }
    public ICollection<Material>? materials { get; set; }
    public ICollection<Measure>? measures { get; set; }
    public ICollection<Activity>? activity { get; set; }
    public string? label { get; set; }
    public Color? color { get; set; }
    public string? size { get; set; }
    public string? composition { get; set; }
    public ICollection<Item>? items { get; set; }
    public ICollection<CustomField>? custom_fields { get; set; }
}
