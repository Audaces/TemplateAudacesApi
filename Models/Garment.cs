using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

/// <summary>
/// Modelo de saída (GET). Representa um produto acabado retornado pelo Audaces IDEA.
/// Utilizado para serializar a resposta nos endpoints de consulta.
///
/// Campos fixos (reconhecidos e processados pelo Audaces IDEA):
///   uid, name, reference, type, value, collection, product_group, description
///
/// Campos sugeridos (opcionais, enriquecem a visualização no IDEA):
///   notes, responsible, currency, last_modified, filename, revision, author, images, variants
///
/// Campos customizados: utilizar custom_fields.
///
/// Importante — Cor em finished_product:
///   A cor NÃO deve ser informada pelo objeto Color da variante.
///   Deve ser representada como CustomField no nível do Garment/FinishedProduct:
///   Ex: custom_fields = [{ name="Cor", type="string", value="White", options=["White","Black"] }]
///   As variantes devem carregar os items correspondentes a cada combinação de cor/tamanho.
/// </summary>
public class Garment
{
    public Garment()
    {
        type = "finished_product";
    }
    public string? type { get; set; }
    public string? uid { get; set; }
    public string? name { get; set; }
    public string? reference { get; set; }
    public string? description { get; set; }
    public double? value { get; set; }
    public string? measure_unit { get; set; }
    public string? last_modified { get; set; }
    public string? filename { get; set; }
    public int? revision { get; set; }
    public string? author { get; set; }
    public string? collection { get; set; }
    public string? notes { get; set; }
    public string? product_group { get; set; }
    public string? supplier { get; set; }
    public string? usage { get; set; }
    public ICollection<Color>? colors { get; set; }
    public ICollection<Image>? images { get; set; }
    public string? currency { get; set; }
    public ICollection<string>? composition { get; set; }
    public string? responsible { get; set; }
    public ICollection<CustomField>? custom_fields { get; set; }
    public ICollection<Size>? sizes { get; set; }
    public ICollection<Price>? prices { get; set; }
    public ICollection<Variant>? variants { get; set; }
    public ICollection<Item>? items { get; set; }
    public string? color_1 { get; set; }
    public string? color_2 { get; set; }
    public string? external_uid { get; set; }

    public bool Filter(string _reference, string _collection, string _description)
    {
        if (string.IsNullOrEmpty(_reference) && string.IsNullOrEmpty(_collection) && string.IsNullOrEmpty(_description))
            return true;

        bool haveReference = false;
        bool haveCollection = false;
        bool haveDescription = false;

        if (!string.IsNullOrEmpty(_reference))
        {
            _reference = _reference.ToLower();
            if (!string.IsNullOrEmpty(this.uid))
            {
                if (this.uid.ToLower().Contains(_reference))
                    haveReference = true;
            }
            if (!string.IsNullOrEmpty(this.reference))
            {
                if (this.reference.ToLower().Contains(_reference))
                    haveReference = true;
            }
        }

        if (!string.IsNullOrEmpty(_collection))
        {
            _collection = _collection.ToLower();
            if (!string.IsNullOrEmpty(collection))
            {
                if (collection.ToLower().Contains(_collection))
                    haveCollection = true;
            }
        }

        if (!string.IsNullOrEmpty(_description))
        {
            _description = _description.ToLower();
            if (!string.IsNullOrEmpty(description))
            {
                if (description.ToLower().Contains(_description))
                    haveDescription = true;
            }
        }

        return haveReference || haveCollection || haveDescription;
    }
}
