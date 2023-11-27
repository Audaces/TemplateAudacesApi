using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Material
{
    public Material()
    {
        type = "raw_material";
    }
    public string type { get; set; }
    public string uid { get; set; }
    public string name { get; set; }
    public string reference { get; set; }
    public string description { get; set; }
    public double value { get; set; }
    public string measure_unit { get; set; }
    public string last_modified { get; set; }
    public string collection { get; set; }
    public string product_group { get; set; }
    public string currency { get; set; }
    public string supplier { get; set; }
    public string notes { get; set; }
    public ICollection<Color> colors { get; set; }
    public string composition { get; set; }
    public ICollection<Image> images { get; set; }
    public ICollection<Price> prices { get; set; }
    public string gender { get; set; }
    public string grid_size { get; set; }
    public string griffe { get; set; }
    public string sub_group { get; set; }
    public string designer { get; set; }
    public string date_register { get; set; }
    public ICollection<Variant> variants { get; set; }
    public string usage { get; set; }
    public ICollection<Size> sizes { get; set; }
    public string composicao { get; set; }
    public string Tamanho { get; set; }
    public string variant { get; set; }
    public Dictionary<string, string> internal_custom_fields { get; set; }
    public Dictionary<string, JObject> internal_custom_fields_object { get; set; }

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
