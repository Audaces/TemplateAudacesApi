namespace TemplateAudacesApi.Models;

public class LoginRetorno
{
    public string access_token { get; set; }
    public int expires_in { get; set; }
    public string token_type { get; set; }
    public string error { get; set; }
}
