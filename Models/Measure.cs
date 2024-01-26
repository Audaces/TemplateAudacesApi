namespace TemplateAudacesApi.Models;

public class Measure
{
    public Measure()
    {
        type = "measure";
    }
    public string? type { get; set; }
    public string? uid { get; set; }
    public string? name { get; set; }
    public string? reference { get; set; }
    public string? description { get; set; }
    public double? value { get; set; }
    public string? measure_unit { get; set; }
    public string? last_modified { get; set; }
    public string? notes { get; set; }
    public MeasureValues? values { get; set; }

    public bool Filter(string _reference, string _description)
    {
        if (string.IsNullOrEmpty(_reference) && string.IsNullOrEmpty(_description))
            return true;

        bool haveReference = false;
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

        if (!string.IsNullOrEmpty(_description))
        {
            _description = _description.ToLower();
            if (!string.IsNullOrEmpty(description))
            {
                if (description.ToLower().Contains(_description))
                    haveDescription = true;
            }
        }

        return haveReference || haveDescription;
    }
}

public class MeasureValues
{
    public double? P { get; set; }
    public double? M { get; set; }
    public double? G { get; set; }
    public string? order { get; set; }
}
