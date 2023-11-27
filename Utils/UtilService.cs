using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateAudacesApi.Utils
{
    public class UtilService
    {
        public static string GetTokenWithouBearer(string tokenIn)
        {
            string tokenOut;
            tokenOut = tokenIn.Remove(0, 7); // "bearer ", size 7
            return tokenOut;
        }
    }
}
