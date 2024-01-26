using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Size
{
    public string? uid { get; set; }
    public string? type { get; set; }
    public bool? editable { get; set; }
    public ICollection<string>? options { get; set; }
}
