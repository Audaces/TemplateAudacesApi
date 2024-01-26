using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class FinishedProduct
{
    public FinishedProduct()
    {
        type = "finished_product";
    }
    public string? type { get; set; }
    public string? uid { get; set; }
    public string? name { get; set; }
    public string? reference { get; set; }
    public string? description { get; set; }
    public string? notes { get; set; }
    public string? collection { get; set; }
    public string? responsible { get; set; }
    public double? value { get; set; }
    public ICollection<Image>? images { get; set; }
    public ICollection<CustomField>? custom_fields { get; set; }
    public ICollection<Variant>? variants { get; set; }
    public ICollection<Item>? items { get; set; }
    public string? product_group { get; set; }

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
