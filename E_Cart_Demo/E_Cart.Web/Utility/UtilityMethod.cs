using Newtonsoft.Json;
using ECart.Web.Models;

namespace ECart.Web.Utility;
public class UtilityMethod
{
    /// <summary>
    /// Description: To handle API response 
    /// </summary>
    /// <param name="responseMessage"></param>    
    public static async Task<APIResponse<T>> ConvertApiResponseAsync<T>(
        HttpResponseMessage responseMessage)
    {
        var result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        var response = JsonConvert.DeserializeObject<APIResponse<T>>(result);
        return response;
    }
}
