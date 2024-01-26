using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Item
{
    public string? type { get; set; }
    public string? uid { get; set; }
    public string? name { get; set; }
    public string? reference { get; set; }
    public string? description { get; set; }
    public double? value { get; set; }
    public string? measure_unit { get; set; }
    public string? last_modified { get; set; }
    public string? collection { get; set; }
    public string? product_group { get; set; }
    public string? currency { get; set; }
    public string? supplier { get; set; }
    public string? notes { get; set; }
    public double? time { get; set; }
    public string? sector { get; set; }
    public string? machine { get; set; }
    public ICollection<CustomField>? custom_fields { get; set; }
    public ICollection<Color>? colors { get; set; }
    public ICollection<Size>? sizes { get; set; }
    public ICollection<Price>? prices { get; set; }
    public ICollection<Image>? images { get; set; }
    public string? gender { get; set; }
    public string? grid_size { get; set; }
    public string? griffe { get; set; }
    public string? sub_group { get; set; }
    public string? designer { get; set; }
    public string? date_register { get; set; }
    public string? usage { get; set; }
    public string? composicao { get; set; }
    public string? Tamanho { get; set; }
}
