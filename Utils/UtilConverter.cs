using System;
using TemplateAudacesApi.Models;

namespace TemplateAudacesApi.Utils;

/// <summary>
/// Representa um objeto genérico do ERP.
/// Substitua esta classe pelo modelo real do seu ERP para cada tipo de dado.
/// </summary>
public class ErpObject
{
    public string? name { get; set; }
    public string? code { get; set; }
    public string? reference { get; set; }
    public double? quantity { get; set; }
}

/// <summary>
/// Responsável por converter os modelos do ERP para os modelos do Audaces IDEA e vice-versa.
/// Este é o ponto central da integração — os DEVs devem implementar os métodos abaixo
/// conforme os modelos reais do seu ERP.
///
/// Convenção dos métodos:
///   ToAudaces(ErpObject, IdeaModel)  — converte dados do ERP para o modelo do Audaces IDEA.
///   AudacesTo(ErpObject, IdeaModel)  — converte dados do Audaces IDEA para o formato do ERP.
///
/// O parâmetro ErpObject deve ser substituído pelo tipo real do ERP correspondente.
///
/// Exemplo de uso no endpoint de query:
///   var material = new Material();
///   UtilConverter.ToAudaces(erpMaterial, material);
///   items.Add(material);
/// </summary>
public static class UtilConverter
{
    // -----------------------------------------------------------------------
    // Material
    // -----------------------------------------------------------------------

    /// <summary>
    /// TODO: Popula o objeto do ERP com dados de um Material do Audaces IDEA.
    /// </summary>
    public static void AudacesTo(ErpObject prod, Material material)
    {
        prod.code = material.uid;
        prod.name = material.name;
        prod.quantity = material.value ?? 0.0;
        prod.reference = material.reference;
    }

    /// <summary>
    /// TODO: Popula um Material do Audaces IDEA com dados do ERP.
    /// </summary>
    public static void ToAudaces(ErpObject prod, Material material)
    {
        material.uid = prod.code;
        material.name = prod.name;
        material.value = prod.quantity;
        material.reference = prod.reference;
    }

    // -----------------------------------------------------------------------
    // FinishedProduct
    // -----------------------------------------------------------------------

    /// <summary>
    /// TODO: Popula o objeto do ERP com dados de um FinishedProduct do Audaces IDEA.
    /// </summary>
    public static void AudacesTo(ErpObject prod, FinishedProduct finishedProduct)
    {
        throw new NotImplementedException("Implemente a conversão do FinishedProduct para o seu ERP.");
    }

    /// <summary>
    /// TODO: Popula um FinishedProduct do Audaces IDEA com dados do ERP.
    /// </summary>
    public static void ToAudaces(ErpObject prod, FinishedProduct finishedProduct)
    {
        throw new NotImplementedException("Implemente a conversão do seu ERP para FinishedProduct.");
    }

    // -----------------------------------------------------------------------
    // Garment
    // -----------------------------------------------------------------------

    /// <summary>
    /// TODO: Popula o objeto do ERP com dados de um Garment do Audaces IDEA.
    /// </summary>
    public static void AudacesTo(ErpObject prod, Garment garment)
    {
        prod.code = garment.uid;
        prod.name = garment.name;
        prod.quantity = garment.value ?? 0.0;
        prod.reference = garment.reference;
    }

    /// <summary>
    /// TODO: Popula um Garment do Audaces IDEA com dados do ERP.
    /// </summary>
    public static void ToAudaces(ErpObject prod, Garment garment)
    {
        garment.uid = prod.code;
        garment.name = prod.name;
        garment.value = prod.quantity;
        garment.reference = prod.reference;
    }

    // -----------------------------------------------------------------------
    // Activity
    // -----------------------------------------------------------------------

    /// <summary>
    /// TODO: Popula o objeto do ERP com dados de uma Activity do Audaces IDEA.
    /// </summary>
    public static void AudacesTo(ErpObject prod, Activity activity)
    {
        throw new NotImplementedException("Implemente a conversão da Activity para o seu ERP.");
    }

    /// <summary>
    /// TODO: Popula uma Activity do Audaces IDEA com dados do ERP.
    /// </summary>
    public static void ToAudaces(ErpObject prod, Activity activity)
    {
        throw new NotImplementedException("Implemente a conversão do seu ERP para Activity.");
    }

    // -----------------------------------------------------------------------
    // Measure
    // -----------------------------------------------------------------------

    /// <summary>
    /// TODO: Popula o objeto do ERP com dados de uma Measure do Audaces IDEA.
    /// </summary>
    public static void AudacesTo(ErpObject prod, Measure measure)
    {
        throw new NotImplementedException("Implemente a conversão da Measure para o seu ERP.");
    }

    /// <summary>
    /// TODO: Popula uma Measure do Audaces IDEA com dados do ERP.
    /// </summary>
    public static void ToAudaces(ErpObject prod, Measure measure)
    {
        throw new NotImplementedException("Implemente a conversão do seu ERP para Measure.");
    }
}
