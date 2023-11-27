using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TemplateAudacesApi.Models;

public class Activity
{
    public Activity()
    {
        type = "activity";
    }
    public string type { get; set; }
    public string uid { get; set; }
    public string name { get; set; }
    public string reference { get; set; }
    public string description { get; set; }
    public double value { get; set; }
    public double time { get; set; }
    public string notes { get; set; }
    public string sector { get; set; }
    public string machine { get; set; }
    public string measure_unit { get; set; }
    public Dictionary<string, JObject> activivty_internal_custom_fields { get; set; }
    public bool Filter(string _reference)
    {
        if (string.IsNullOrEmpty(_reference))
            return true;

        _reference = _reference.ToLower();
        if (!string.IsNullOrEmpty(uid))
        {
            if (uid.ToLower().Contains(_reference))
            {
                return true;
            }
        }
        if (!string.IsNullOrEmpty(reference))
        {
            if (reference.ToLower().Contains(_reference))
                return true;
        }

        return false;
    }
}
