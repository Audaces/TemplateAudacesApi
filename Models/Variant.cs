using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

/// <summary>
/// Representa uma variante de um produto. O uso dos campos varia conforme o tipo do produto pai:
///
/// raw_material:
///   - color : objeto estruturado com uid, rgb e value (ex: variação de cor do botão).
///   - items : não utilizado.
///
/// finished_product:
///   - color : NÃO utilizado. A cor é informada como CustomField no próprio Garment/FinishedProduct pai.
///   - items : lista de componentes/materiais por combinação de cor e tamanho.
/// </summary>
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
