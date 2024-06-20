namespace ECart.Web.Utility;
public interface IUtilityHelper
{
    public Task<HttpResponseMessage> CallApiAsync(string endPoint, HttpMethod httpMethod, dynamic payload = null);
    public Task<HttpResponseMessage> MakeApiCallAsync(string endPoint, HttpMethod httpMethod, HttpContext httpContext, dynamic payload = null);
}
