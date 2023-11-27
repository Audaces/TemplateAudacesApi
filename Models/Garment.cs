using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Garment
{
    public Garment()
    {
        type = "finished_product";
    }
    public string type { get; set; }
    public string uid { get; set; }
    public string name { get; set; }
    public string reference { get; set; }
    public string description { get; set; }
    public double value { get; set; }
    public string measure_unit { get; set; }
    public string last_modified { get; set; }
    public string filename { get; set; }
    public int revision { get; set; }
    public string author { get; set; }
    public string collection { get; set; }
    public string notes { get; set; }
    public string product_group { get; set; }
    public string supplier { get; set; }
    public string usage { get; set; }
    public ICollection<Color> colors { get; set; } = new List<Color>();
    public ICollection<Image> images { get; set; } = new List<Image>();
    public string currency { get; set; }
    public ICollection<string> composition { get; set; }
    public string responsible { get; set; }
    public ICollection<CustomField> custom_fields { get; set; } = new List<CustomField>();
    public ICollection<Size> sizes { get; set; } = new List<Size>();
    public ICollection<Price> prices { get; set; } = new List<Price>();
    public ICollection<Variant> variants { get; set; } = new List<Variant>();
    public ICollection<Item> items { get; set; } = new List<Item>();
    public string color_1 { get; set; }
    public string color_2 { get; set; }
    public string external_uid { get; set; }
    public Dictionary<string, string> internal_custom_fields { get; set; }
    public Dictionary<string, JObject> internal_custom_fields_object { get; set; }

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
