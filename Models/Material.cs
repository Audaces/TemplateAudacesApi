using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Material
{
    public Material()
    {
        type = "raw_material";
    }
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
    public ICollection<Image>? images { get; set; }
    public ICollection<Variant>? variants { get; set; }

    public bool Filter(string _reference, string _product_group, string _supplier, string _description)
    {
        if (string.IsNullOrEmpty(_reference) && string.IsNullOrEmpty(_product_group) &&
            string.IsNullOrEmpty(_supplier) && string.IsNullOrEmpty(_description))
            return true;

        bool haveReference = false;
        bool haveProductGroup = false;
        bool haveSupplier = false;
        bool haveDescription = false;

        if (!string.IsNullOrEmpty(_reference))
        {
            _reference = _reference.ToLower();
            if (!string.IsNullOrEmpty(uid))
            {
                if (uid.ToLower().Contains(_reference))
                {
                    haveReference = true;
                }
            }
            if (!string.IsNullOrEmpty(reference))
            {
                if (reference.ToLower().Contains(_reference))
                    haveReference = true;
            }
        }

        if (!string.IsNullOrEmpty(_product_group))
        {
            _product_group = _product_group.ToLower();
            if (!string.IsNullOrEmpty(product_group))
            {
                if (product_group.ToLower().Contains(_product_group))
                {
                    haveProductGroup = true;
                }
            }
        }

        if (!string.IsNullOrEmpty(_supplier))
        {
            _supplier = _supplier.ToLower();
            if (!string.IsNullOrEmpty(supplier))
            {
                if (supplier.ToLower().Contains(_supplier))
                {
                    haveSupplier = true;
                }
            }
        }

        if (!string.IsNullOrEmpty(_description))
        {
            _description = _description.ToLower();
            if (!string.IsNullOrEmpty(description))
            {
                if (description.ToLower().Contains(_description))
                {
                    haveDescription = true;
                }
            }
        }

        return haveReference || haveProductGroup || haveSupplier || haveDescription;
    }
}
