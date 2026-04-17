using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

/// <summary>
/// Campo customizado associado a um produto. Utilizado para atributos adicionais
/// que não fazem parte dos campos fixos dos modelos.
///
/// Tipos suportados (campo type):
///   "string"   — texto livre.          Ex: { type="string",   value="Algodão" }
///   "number"   — número como string.   Ex: { type="number",   value="42" }
///   "Date"     — data ISO 8601.        Ex: { type="Date",     value="2024-01-15" }
///   "Currency" — valor monetário.      Ex: { type="Currency", value="29.90" }
///
/// Regras:
///   - O campo value é SEMPRE string, independente do tipo.
///   - Quando o campo permite seleção, preencher options com os valores válidos.
///   - Em finished_product, a cor da peça deve ser informada como CustomField (tipo "string" com options)
///     e NÃO pelo objeto Color da variante.
/// </summary>
public class CustomField
{
    public string? name { get; set; }
    public string? type { get; set; }
    public string? value { get; set; }
    public bool? editable { get; set; }
    public ICollection<string>? options { get; set; }
}
