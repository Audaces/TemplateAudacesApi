namespace TemplateAudacesApi.Utils;

public class UtilService
{
    public static string GetTokenWithoutBearer(string tokenIn)
    {
        string tokenOut;
        tokenOut = tokenIn.Remove(0, 7); // "bearer ", size 7
        return tokenOut;
    }
}
